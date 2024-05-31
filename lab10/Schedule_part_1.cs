using System.Text.Json.Serialization;

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