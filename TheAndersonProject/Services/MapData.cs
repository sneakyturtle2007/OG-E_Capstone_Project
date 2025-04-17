using System.IO.Compression;
using System.Text.Json;
namespace TheAndersonProject.Services{
    public class MapData{
        public Dictionary<string, List<ReaderEvent>> EventsByLocation { get; set; } = new Dictionary<string, List<ReaderEvent>>();
        
    }
    
}
