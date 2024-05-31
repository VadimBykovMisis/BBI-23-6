interface ISettleable {
    bool Add(ScheduleItem x);
    void Remove();
    void ChangeStart(DateTime x);
    void ChangeEnd(DateTime x);
    
}