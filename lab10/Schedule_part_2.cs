
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