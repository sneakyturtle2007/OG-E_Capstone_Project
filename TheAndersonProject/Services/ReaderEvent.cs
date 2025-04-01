namespace TheAndersonProject.Services{
    public class ReaderEvent{
        public string eventTime { get; set; } = "";
        public string location { get; set; } = "";
        public string readerDesc { get; set; } = "";
        public string idHash { get; set; } = "";
        public int devID { get; set; } = 0;
        public int machine { get; set; } = 0;

        public ReaderEvent() {}

        public ReaderEvent(string eventTime, string location, string readerDesc, string idHash, int devID, int machine)
        {
            this.eventTime = eventTime;
            this.location = location;
            this.readerDesc = readerDesc;
            this.idHash = idHash;
            this.devID = devID;
            this.machine = machine;
        }
    }
}