class Program {
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
