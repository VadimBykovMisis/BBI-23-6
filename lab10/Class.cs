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