namespace TheAndersonProject.Services
{
    public class UserSettings{
        public static int ReaderMaintenanceTheshold { get; set; } = 1000;
        public static int PanelMaintenanceTheshold { get; set; } = 1000;
        public static int UserActivityTheshold { get; set; } = 1000;
    }
}