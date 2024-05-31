partial class WeekSchedule {
    List<Schedule> days = new List<Schedule>();

    public List<Schedule> Days {
        get => days;
        protected set => days = value;
    }
    public WeekSchedule(List<Schedule> days) {
        this.days = days;
    }
}