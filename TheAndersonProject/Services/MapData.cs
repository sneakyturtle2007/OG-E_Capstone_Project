using System.IO.Compression;
using System.Text.Json;
namespace TheAndersonProject.Services{
    public class MapData{
        public static List<Site> Sites { get; set; } = new List<Site>();
        public static List<double[]> SiteCoordinates = new List<double[]>();
    }
}
