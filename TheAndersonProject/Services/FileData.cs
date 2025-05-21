using System;
using System.IO;
using System.Text;
using System.Text.Json;
namespace TheAndersonProject.Services
{
    public class FileData{
        public static string FileName { get; set; } = "";
        public static int ReaderEventsCount {get; set;} = 0;
        public static List<ReaderEvent> ReaderEvents {get; set;} = new List<ReaderEvent>();        

        public static void SaveInfo(){
            Console.WriteLine("Saving FileInfo");
            if (File.Exists("FileInfo.txt"))
            {
                string[] contents = File.ReadAllLines("FileInfo.txt");
                for (int i = 0; i < contents.Length; i++)
                {
                    if (contents[i].Contains(FileName))
                    {
                        string readerMaintenance = JsonSerializer.Serialize(SiteData.ReaderMaintenance);
                        string panelMaintenance = JsonSerializer.Serialize(SiteData.PanelMaintenance);
                        contents[i] = $"{FileName}|{SiteData.SiteName}`{readerMaintenance}`{panelMaintenance}";
                    }
                }
                File.WriteAllLines("FileInfo.txt", contents);
                
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("FileInfo.txt"))
                {
                    string maintenance = "";
                    Dictionary<string, List<ReaderEvent>> eventsByReaders = SiteData.OrganizeEvents_StringKey(ReaderEvents, "reader");
                    Dictionary<int, List<ReaderEvent>> eventsByPanels = SiteData.OrganizeEvents_IntKey(ReaderEvents);
                    Dictionary<string, int> tempList = new Dictionary<string, int>();
                    foreach (KeyValuePair<string, List<ReaderEvent>> kvp in eventsByReaders)
                    {
                        tempList.Add(kvp.Key, 1);
                    }

                    maintenance += $"{JsonSerializer.Serialize(tempList)}`";
                    tempList.Clear();

                    foreach (KeyValuePair<int, List<ReaderEvent>> kvp in eventsByPanels)
                    {
                        tempList.Add(kvp.Key.ToString(), 1);
                    }
                    maintenance += $"{JsonSerializer.Serialize(tempList)}";

                    writer.WriteLine($"{FileName}|{SiteData.SiteName}`{maintenance}");
                    writer.Flush();
                }
            }
        }
        public static void LoadInfo(string siteName){
            if(File.Exists("FileInfo.txt")){
                StreamReader reader = new StreamReader("FileInfo.txt");  

                string line = "";
                if(reader.ReadLine() == null){
                    File.Delete("FileInfo.txt");
                    SaveInfo();
                }
                reader.Close();
                reader = new StreamReader("FileInfo.txt");
                while(!reader.EndOfStream){
                    line = reader.ReadLine();
                    Console.WriteLine("temp");
                    if(line.Contains(FileName)){
                        string[] sites = line.Split("|");
                        for(int i = 0; i < sites.Length; i++){
                            if(sites[i].Contains(siteName)){
                                SiteData.ReaderMaintenance = JsonSerializer.Deserialize<Dictionary<string, int>>(sites[i].Split("`")[1]);
                                SiteData.PanelMaintenance = JsonSerializer.Deserialize<Dictionary<string, int>>(sites[i].Split("`")[2]);
                                Console.WriteLine($"FileName: {FileName}|{line.Split("|")[1]}");
                            }
                        }
                    }
                }
                reader.Close();
                
            }else{
                SaveInfo();
                using(StreamReader reader = new StreamReader("FileInfo.txt")){
                    
                    string line = "";

                    while(!reader.EndOfStream){
                        line = reader.ReadLine();
                        Console.WriteLine("temp");
                        if(line.Contains(FileName)){
                            string[] sites = line.Split("|");
                            for(int i = 0; i < sites.Length; i++){
                                if(sites[i].Contains(siteName)){
                                    SiteData.ReaderMaintenance = JsonSerializer.Deserialize<Dictionary<string, int>>(sites[i].Split("`")[1]);
                                    SiteData.PanelMaintenance = JsonSerializer.Deserialize<Dictionary<string, int>>(sites[i].Split("`")[2]);
                                    Console.WriteLine($"FileName: {FileName}|{line.Split("|")[1]}");
                                }
                            }
                        }
                    }

                }
            }
        }

    }
}