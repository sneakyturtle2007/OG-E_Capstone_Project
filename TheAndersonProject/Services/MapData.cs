using System.IO.Compression;
using System.Text.Json;
namespace TheAndersonProject.Services{
    public class MapData{
        public static Dictionary<string, List<ReaderEvent>> EventsByLocation { get; set; } = new Dictionary<string, List<ReaderEvent>>();
        public static List<double[]> SiteLocations = new List<double[]>();
    }
    
}
