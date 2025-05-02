namespace TheAndersonProject.Services
{
    public class SiteData{
        public static string SiteName { get; set; } = "";
        public static bool DisplaySiteInfo { get; set; } = false;
        public static int ReaderEventsCount {get; set;} = 0;
        public static List<ReaderEvent> ReaderEvents {get; set;} = new List<ReaderEvent>();    
        public static int[] YearMonth {get; set;} = new int[2]; 
        
        public static Dictionary<string, List<ReaderEvent>> OrganizeEvents_StringKey(List<ReaderEvent> totalEvents, string category){
            Dictionary<string, List<ReaderEvent>> eventsByCategory = new Dictionary<string, List<ReaderEvent>>();
            List<ReaderEvent> tempList = new List<ReaderEvent>();
            string key = "";
            foreach(ReaderEvent temp in totalEvents){
                switch(category){
                    case "user":
                        key = temp.UserID;
                        break;
                    case "reader":
                        key = temp.ReaderDesc;
                        break;
                    case "day":
                        key = DateTime.Parse(temp.EventTime).ToString("dddd");
                        break;
                    case "location":
                        key = temp.Location;
                        break;
                    default:
                        break;
                }
                if(!eventsByCategory.ContainsKey(key)){
                    tempList = new List<ReaderEvent>();
                    eventsByCategory.Add(key, tempList);
                }
                eventsByCategory[key].Add(temp);
            }
            return eventsByCategory;
        }       
        public static Dictionary<int, List<ReaderEvent>> OrganizeEvents_IntKey(List<ReaderEvent> totalEvents){
            Dictionary<int, List<ReaderEvent>> eventsByPanel = new Dictionary<int, List<ReaderEvent>>();
            List<ReaderEvent> tempList = new List<ReaderEvent>();
            foreach(ReaderEvent temp in totalEvents){
                if(!eventsByPanel.ContainsKey(temp.Machine)){
                    tempList = new List<ReaderEvent>();
                    eventsByPanel.Add(temp.Machine, tempList);
                }
                eventsByPanel[temp.Machine].Add(temp);
            }
            return eventsByPanel;
        }
        public static List<string> OrganizeCount_String<T>(Dictionary<string, List<T>> dictionary){
            List<string> sortedList = new List<string>();
            foreach(KeyValuePair<string, List<T>> kvp in dictionary){
                for(int i = 0; i < sortedList.Count; i++){
                    if(kvp.Value.Count > dictionary[sortedList[i]].Count){
                        sortedList.Insert(i, kvp.Key);
                        break;
                    }
                }
                if(!sortedList.Contains(kvp.Key)){
                    sortedList.Add(kvp.Key);
                }
            }
            return sortedList;
        }
    }
}
