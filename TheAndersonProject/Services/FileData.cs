namespace TheAndersonProject.Services
{
    public class FileData{
        public static string FileName { get; set; } = "";
        public static long FileSize { get; set; } = 0;
        public static string FileType { get; set; } = "";
        public static int ReaderEventsCount {get; set;} = 0;
        public static List<ReaderEvent> ReaderEvents {get; set;} = new List<ReaderEvent>();
        public static DateTimeOffset LastModified { get; set; } = DateTimeOffset.MinValue;
        
    }
}