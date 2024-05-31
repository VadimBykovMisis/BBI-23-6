
class Lecture : Class {
    public Lecture (string title, string description, string classRoom, DateTime startTime) : base (title, description, classRoom, startTime) {
        this.DurationInMinutes *= 2;

        this.EndTime = this.StartTime.AddMinutes(this.DurationInMinutes);
    }
    public override string ToString() {
        return String.Format("Лекция {0}\n{1}\nНачинается {2} и заканчивается {3} в кабинете {4}",Title,Description,StartTime.ToString(),EndTime.ToString(), ClassRoom);
    }
}