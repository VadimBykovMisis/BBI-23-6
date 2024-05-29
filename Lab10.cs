using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

[JsonDerivedType(typeof(ScheduleItem), typeDiscriminator: "base")]
[JsonDerivedType(typeof(Break), typeDiscriminator: "break")]
[JsonDerivedType(typeof(Class), typeDiscriminator: "class")]
[JsonDerivedType(typeof(Lecture), typeDiscriminator: "lecture")]
class ScheduleItem {
    private string title = "";
    private string description = "";
    private DateTime startTime = new DateTime();
    private DateTime endTime = new DateTime();
    
    
    public string Title {
        get => title;
        protected set => title = value;
    }
    public string Description {
        get => description;
        protected set => description = value;
    }
    public DateTime StartTime {
        get => startTime;
        protected set => startTime = value;
    }
    public DateTime EndTime {
        get => endTime;
        protected set => endTime = value;
    }
    
    public ScheduleItem(string title, string description) {
        this.title = title;
        this.description = description;
    }
    
    public void ChangeStartTime(DateTime startTime) {
        this.startTime = startTime;
    }
    public void ChangeEndTime(DateTime endTime) {
        this.endTime = endTime;
    }
    
    public override string ToString() {
        return String.Format("{0}\n{1}\nНачинается {2} и заканчивается {3}",this.title,this.description,this.startTime.ToString(),this.endTime.ToString());
    }
    
}

class Class : ScheduleItem {
    private string classRoom = "";
    private int durationInMinutes = 45;
    
    public string ClassRoom {
        get => classRoom;
        protected set => classRoom = value;
    }
    public int DurationInMinutes {
        get => durationInMinutes;
        protected set => durationInMinutes = value;
    }
    public Class (string title, string description, string classRoom, DateTime startTime) : base(title, description) {
        this.classRoom = classRoom;
        this.StartTime = startTime;
        this.EndTime = this.StartTime.AddMinutes(this.durationInMinutes);
    }
    public override string ToString() {
        return String.Format("Класс {0}\n{1}\nНачинается {2} и заканчивается {3} в кабинете {4}",Title,Description,StartTime.ToString(),EndTime.ToString(), classRoom);
    }
}
class Lecture : Class {
    public Lecture (string title, string description, string classRoom, DateTime startTime) : base (title, description, classRoom, startTime) {
        this.DurationInMinutes *= 2;

        this.EndTime = this.StartTime.AddMinutes(this.DurationInMinutes);
    }
    public override string ToString() {
        return String.Format("Лекция {0}\n{1}\nНачинается {2} и заканчивается {3} в кабинете {4}",Title,Description,StartTime.ToString(),EndTime.ToString(), ClassRoom);
    }
}
class Break : ScheduleItem {
    
    private bool isLunch = false;
    private int durationInMinutes = 45;
    
    public bool IsLunch {
        get => isLunch;
        protected set => isLunch = value;
    }
    public int DurationInMinutes {
        get => durationInMinutes;
        protected set => durationInMinutes = value;
    }
    
    public Break (string title, string description, bool isLunch, DateTime startTime, int durationInMinutes = 45) : base(title, description) {
        this.isLunch = isLunch;
        this.durationInMinutes = durationInMinutes;
        this.StartTime = startTime;
        this.EndTime = this.StartTime.AddMinutes(this.durationInMinutes);

    }
    public void ChangeDuration(int duratuinInMinutes) {
        this.durationInMinutes = duratuinInMinutes;
    }
    public override string ToString() {
        string breakType = "Перемена";
        if (isLunch) {
            breakType = "Обед";
        }
        return String.Format("{0} {1}\n{2}\nНачинается {3} и заканчивается {4}",breakType, Title,Description,StartTime.ToString(),EndTime.ToString());
    }
    
}

interface ISettleable {
    bool Add(ScheduleItem x);
    void Remove();
    void ChangeStart(DateTime x);
    void ChangeEnd(DateTime x);
    
}

partial class Schedule : ISettleable {
    private List<ScheduleItem> items = new List<ScheduleItem>();
    
    public List<ScheduleItem> Items {
        get => items;
    }
    [JsonConstructor]
    public Schedule(List<ScheduleItem> Items) {
        this.items = Items;
    }
    public Schedule() {

    }
    public bool Add(ScheduleItem x) {
        if (items.Count > 0 && x.StartTime != items[items.Count - 1].EndTime)  return false;

        if (items.Count % 2 == 0 && x is not Class) return false;
        if (items.Count % 2 != 0 && x is not Break) return false;
        items.Add(x);
        return true;
    }
    public void Remove() {
        items.RemoveAt(items.Count - 1);
    }
    
    public override string ToString() {
        string x = "";
        for (int i = 0; i < items.Count; ++i) {
            x += items[i].ToString();
            x += "\n\n";
        }
        return x;
        
    }
}

partial class Schedule : ISettleable {

    public void ChangeStart(DateTime changeTime) {
        if (items.Count >= 1) {
            items[items.Count - 1].ChangeStartTime(changeTime);
        }
        if (items.Count >= 2) {
            items[items.Count - 2].ChangeEndTime(changeTime);
        }
    }
    
    public void ChangeEnd(DateTime changeTime) {
        if (items.Count >= 1) {
            items[items.Count - 1].ChangeEndTime(changeTime);
        }
    }
     public void ChangeEnd(DateTime changeTime, int index) {
        if (items.Count >= 1) {
            items[items.Count - 1].ChangeEndTime(changeTime);
        }
    }
}
abstract public class MySerializer {
    public abstract T Read<T>(string filePath);
    public abstract void Write<T>(T item, string filePath);
}

class MyJSONSerializer : MySerializer {
    public override T Read<T>(string filePath) {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializerOptions options = new JsonSerializerOptions{
                WriteIndented =  true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            return JsonSerializer.Deserialize<T>(fs,options);
        }
        return default(T);
    }
    
    public override void Write<T>(T item, string filePath) {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializerOptions options = new JsonSerializerOptions{
                WriteIndented =  true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };
            JsonSerializer.Serialize(fs, item,options);
        }
    }
}


partial class WeekSchedule {
    List<Schedule> days = new List<Schedule>();

    public List<Schedule> Days {
        get => days;
        protected set => days = value;
    }
    public WeekSchedule(List<Schedule> days) {
        this.days = days;
    }
    public double GetAverageLearnTimeByDayIndex(int index) {
        int lessonsCount = 0;
        double averageTime = 0;
        for (int i = 0; i < days[index].Items.Count; ++i) {
            if (i%2 == 0) {
                averageTime += ((Class)days[index].Items[i]).DurationInMinutes;
                lessonsCount++;
            }
        }
        return averageTime/lessonsCount;
    }
}
partial class WeekSchedule {
    public double GetAverageWeekLearnTime() {
        double averageTime = 0; 
        for (int i = 0; i < days.Count; ++i) {
            averageTime += GetAverageLearnTimeByDayIndex(i);
        }
        return averageTime / days.Count;
    }
}
class Lab10 {
  static void Main() {
    string path = "C:\\Users\\nekodaze\\Desktop\\vadym_lab_10";
    string folderName = "data";
    path = Path.Combine(path, folderName);
    if (!Directory.Exists(path)) {
        Directory.CreateDirectory(path);
    }
    MyJSONSerializer serializer = new MyJSONSerializer();
    string fileName1 = "raw_data.json";
    string fileName2 = "data.json";
    string fileName3 = "new_data.json";
    string fileName4 = "updated_data.json";


    List<string> classes = new List<string>(["Математика","Прогграмирование","Русский Язык", "Физкультура", "Химия", "Физика"]);
    List<string> classDescriptions = new List<string>(["Важная","Открытый урок","Контрольная", "Нету домашнего задания", "Есть домашнее задание", "Всё хорошо"]);
    List<string> classRooms = new List<string>(["402","103","231","111","42"]);
    List<string> breakTitles = new List<string>(["Прекрасная", "Хорошая", "Чилловая", "Особенная", "Хорошая", "На всякий надо"]);
    List<string> breakDescriptions = new List<string>(["Успеть сделать домашку на следующий урок","Отдохнуть после сложной пары", "Посветить время себе", "Сбегать домой за новой ручкой", "Устал", "Устал"]);

    List<Schedule> week = new List<Schedule>();
    for (int i = 0; i < 6; ++i) {
        Schedule day = new Schedule();

        week.Add(day);
    }
    serializer.Write<List<Schedule>>(week,Path.Combine(path,fileName1));

    for (int i = 0; i <6; ++i) {
        DateTime now = DateTime.Now;
        for (int j = 0; j < 5; ++j) {
            string classTitle = classes[(i+j) % classes.Count];
            string classDescription = classDescriptions[(i+j) % classDescriptions.Count];
            string classRoom = classRooms[(i+j) % classRooms.Count];
            string breakTitle = breakTitles[(i+j) % breakTitles.Count];
            string breakDescription = breakDescriptions[(i+j) % breakDescriptions.Count];

            week[i].Add(new Class(classTitle, classDescription, classRoom, now));

            now = week[i].Items[week[i].Items.Count - 1].EndTime;                
            if (j == 2) {
                week[i].Add(new Break(breakTitle, breakDescription, true, now));
            } 
            if (j != 2 && j < 4) {
                week[i].Add(new Break(breakTitle, breakDescription, false, now));
            }
            now = week[i].Items[week[i].Items.Count - 1].EndTime;                
        }
    }

    serializer.Write<List<Schedule>>(week,Path.Combine(path,fileName2));

    for (int i = 0; i < week.Count; ++i) {

        Schedule buf = new Schedule();
        DateTime time = week[i].Items[0].StartTime;
        for (int j = 0; j < week[i].Items.Count; ++j) {
            ScheduleItem x = week[i].Items[j];
            x.ChangeStartTime(time);
            time = x.EndTime;
            if (j >= 5) { // 3 перемена
                time = time.AddMinutes( ((Break)(week[i].Items[5])).DurationInMinutes*0.5);
                if (j==5) {
                    ((Break)(x)).ChangeDuration( (int)(((Break)(x)).DurationInMinutes*1.5));
                }
            }
            x.ChangeEndTime(time);
            buf.Add(x);
        }
        week[i] = buf;
    }

    week[4].Remove();
    week[4].Remove();

    Break tueB = new Break("Переменная до  6 урока","Не хочу на 6 урок=(",false, week[1].Items[week[1].Items.Count - 1].EndTime);
    Class tueC = new Class("6 урок","=(","210", tueB.EndTime);
    week[1].Add(tueB);
    week[1].Add(tueC);

    serializer.Write<List<Schedule>>(week,Path.Combine(path,fileName3));

    List<Schedule> lecturesWeek = new List<Schedule>();
    for (int i = 0; i< week.Count; ++i) {
        int offset = 0;
        Schedule buf = new Schedule();
        for (int j = 0; j< week[i].Items.Count; ++j) {
            ScheduleItem x = week[i].Items[j];
            x.ChangeStartTime(x.StartTime.AddMinutes(offset));
            if (i == 0 && j == 6 || i == 3 && j == 8) {
                Class x2 = (Class)x;
                x = new Lecture(x2.Title,x2.Description,x2.ClassRoom,x2.StartTime);
                offset = x2.DurationInMinutes;
            }
            x.ChangeEndTime(x.EndTime.AddMinutes(offset));
            buf.Add(x);
        }
        lecturesWeek.Add(buf);
    }
    week = lecturesWeek;
    serializer.Write<List<Schedule>>(week,Path.Combine(path,fileName4));



    List<String> weekDays = new List<string>(["Понедельник","Вторник","Среда","Четверг","Пятница","Суббота"]);


    List<Schedule> dweek = serializer.Read<List<Schedule>>(Path.Combine(path,fileName1));

    for (int i = 0; i < dweek.Count; ++i) {
        Console.WriteLine(weekDays[i] + "\n\n");
        Console.WriteLine(dweek[i].ToString());
    }
    dweek = serializer.Read<List<Schedule>>(Path.Combine(path,fileName2));

    for (int i = 0; i < dweek.Count; ++i) {
        Console.WriteLine(weekDays[i] + "\n\n");
        Console.WriteLine(dweek[i].ToString());
    }
    dweek = serializer.Read<List<Schedule>>(Path.Combine(path,fileName3));

    for (int i = 0; i < dweek.Count; ++i) {
        Console.WriteLine(weekDays[i] + "\n\n");
        Console.WriteLine(dweek[i].ToString());
    }

    dweek = serializer.Read<List<Schedule>>(Path.Combine(path,fileName4));

    for (int i = 0; i < dweek.Count; ++i) {
        Console.WriteLine(weekDays[i] + "\n\n");
        Console.WriteLine(dweek[i].ToString());
    }

    WeekSchedule weekSchedule = new WeekSchedule(dweek);
    for (int i = 0; i < weekSchedule.Days.Count; ++i) {
        Console.WriteLine(String.Format("{0} Среднее время учёбы = {1}",weekDays[i],weekSchedule.GetAverageLearnTimeByDayIndex(i)));
    }
    Console.WriteLine("Среднее время учёбы за неделю = " + (weekSchedule.GetAverageWeekLearnTime().ToString()));
  }
}
