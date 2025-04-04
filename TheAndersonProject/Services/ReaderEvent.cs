namespace TheAndersonProject.Services{
    public class ReaderEvent{
        public string EventTime { get; set; } = "";
        public string Location { get; set; } = "";
        public string ReaderDesc { get; set; } = "";
        public string UserID { get; set; } = "";
        public int DevID { get; set; } = 0;
        public int Machine { get; set; } = 0;

        public ReaderEvent() {}

        public ReaderEvent(string EventTime, string Location, string ReaderDesc, string UserID, int DevID, int Machine)
        {
            this.EventTime = EventTime;
            this.Location = Location;
            this.ReaderDesc = ReaderDesc;
            this.UserID = UserID;
            this.DevID = DevID;
            this.Machine = Machine;
        }
    }
}