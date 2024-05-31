using System.Text.Json.Serialization;

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