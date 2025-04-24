namespace TheAndersonProject.Services{
    public class Site{
        public string SiteName {get; set;} = "";
        public List<ReaderEvent> ReaderEvents {get; set;} = new List<ReaderEvent>();   
        public string Description {get; set;} = "";
        public Site(){}
        public Site(string siteName, List<ReaderEvent> readerEvents){
            SiteName = siteName;
            ReaderEvents = readerEvents;
        }
    }
}