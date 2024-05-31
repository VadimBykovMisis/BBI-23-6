


partial class WeekSchedule {
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
    public double GetAverageWeekLearnTime() {
        double averageTime = 0; 
        for (int i = 0; i < days.Count; ++i) {
            averageTime += GetAverageLearnTimeByDayIndex(i);
        }
        return averageTime / days.Count;
    }
}