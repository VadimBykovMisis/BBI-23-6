
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