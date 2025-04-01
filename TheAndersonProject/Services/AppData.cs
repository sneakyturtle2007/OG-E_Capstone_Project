using System.IO.Compression;
using System.Text.Json;
namespace TheAndersonProject.Services{
    public class AppData{
        public string Test {set; get;} = "Testing";
        
        
        /*public async Task LoadAppData(){
            try{
                var fileName = await _sessionStorage.GetAsync<string>("FileName");
                var fileSize = await _sessionStorage.GetAsync<long>("FileSize");
                var fileType = await _sessionStorage.GetAsync<string>("FileType");
                var readerEventsCount = await _sessionStorage.GetAsync<int>("ReaderEventsCount");
                var lastModified = await _sessionStorage.GetAsync<DateTimeOffset>("LastModified");
                Console.WriteLine(fileName.Value);
                var readerEvents = await _sessionStorage.GetAsync<string>("ReaderEvents");
                Console.WriteLine(readerEvents.Value);
                //var eventsPerReader = await _sessionStorage.GetAsync<string>("EventsPerReader");

                if (fileName.Success && fileSize.Success && fileType.Success && readerEventsCount.Success && lastModified.Success && readerEvents.Success){
                    FileData.FileName = fileName.Value;
                    FileData.FileSize = fileSize.Value;
                    FileData.FileType = fileType.Value;
                    FileData.ReaderEventsCount = readerEventsCount.Value;
                    FileData.LastModified = lastModified.Value;
                    FileData.ReaderEvents = JsonSerializer.Deserialize<List<ReaderEvent>>(Decompress(readerEvents.Value));
                    //FileData.EventsPerReader = JsonSerializer.Deserialize<Dictionary<string, List<ReaderEvent>>>(Decompress(eventsPerReader.Value));
                    Test = "Data loaded successfully";
                }else{
                    Test = "Failed to load data";
                }
            }catch (TaskCanceledException){
                // Handle the cancellation gracefully
                Test = "Data loading was canceled.";
            }catch (Exception ex){
                // Log or handle other exceptions
                Test = $"An error occurred: {ex.Message}";
            }

            return;
        }

        public async Task SaveAppData(){
            await _sessionStorage.SetAsync("FileName", FileData.FileName);
            await _sessionStorage.SetAsync("FileSize", FileData.FileSize);
            await _sessionStorage.SetAsync("FileType", FileData.FileType);
            await _sessionStorage.SetAsync("ReaderEventsCount", FileData.ReaderEventsCount);
            await _sessionStorage.SetAsync("LastModified", FileData.LastModified);
            string compressedReaderEvents = Compress(JsonSerializer.Serialize(FileData.ReaderEvents));
            string compressedEventsPerReader = Compress(JsonSerializer.Serialize(FileData.EventsPerReader));
            Console.WriteLine(compressedReaderEvents);
            Console.WriteLine(compressedEventsPerReader);
            await _sessionStorage.SetAsync("ReaderEvents", compressedReaderEvents);
            Console.WriteLine("successfully stored reader events");
            //Console.WriteLine(compressedEventsPerReader);
            //await _sessionStorage.SetAsync("EventsPerReader", compressedEventsPerReader);
            //Console.WriteLine("successfully stored events per reader");
            return;
        }
        public async Task ClearAppData(){
            await _sessionStorage.DeleteAsync("FileName");
            await _sessionStorage.DeleteAsync("FileSize");
            await _sessionStorage.DeleteAsync("FileType");
            await _sessionStorage.DeleteAsync("ReaderEventsCount");
            await _sessionStorage.DeleteAsync("LastModified");
            await _sessionStorage.DeleteAsync("ReaderEvents");
            await _sessionStorage.DeleteAsync("EventsPerReader");
            return;
        }
        string Compress(string uncompressedString){
            byte[] compressedBytes;
            using var uncompressedStream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(uncompressedString));
            using var compressedStream = new MemoryStream();
            using var compressor = new GZipStream(compressedStream, CompressionMode.Compress);
            uncompressedStream.CopyTo(compressor);
            compressedBytes = compressedStream.ToArray();
            compressor.Close();
            compressedStream.Close();
            uncompressedStream.Close();
            return Convert.ToBase64String(compressedBytes);
        }
        string Decompress(string compressedString){
            byte[] decompressedBytes;
            using var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString));
            using var uncompressedStream = new MemoryStream();
            using var decompressor = new GZipStream(compressedStream, CompressionMode.Decompress);
            compressedStream.CopyTo(decompressor);
            decompressedBytes = uncompressedStream.ToArray();
            decompressor.Close();
            uncompressedStream.Close();
            compressedStream.Close();
            return System.Text.Encoding.UTF8.GetString(decompressedBytes);
        }*/
    }
    
}
