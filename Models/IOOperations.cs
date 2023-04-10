using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication3.Models
{
    public class IOOperations
    {
        public static async Task<List<InputFile>> ReadFolderAsync(string folder)
        {
            string[] files = Directory.GetFiles(folder);
            List<InputFile> inputFiles = new List<InputFile>();
            string processedFilesFolder = Path.Combine(folder, "Processed files");
            Directory.CreateDirectory(processedFilesFolder);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                Console.WriteLine(fileName);
                string jsonString = await File.ReadAllTextAsync(folder + "/" + fileName);
                jsonString = jsonString.TrimEnd('\n');

                // Split the JSON string into individual objects based on a delimiter
                string[] objectStrings = jsonString.Split("\n");

                List<Rootobject> rootObjects = new List<Rootobject>();
                foreach (string str in objectStrings)
                {
                    Rootobject? rootObject = JsonConvert.DeserializeObject<Rootobject>(str);
                    if (rootObject != null)
                    {
                        rootObjects.Add(rootObject);
                    }
                }
                InputFile inputFile = new InputFile(fileName);
                inputFile.Rootobjects = rootObjects;
                inputFiles.Add(inputFile);

                // Move the file to the "Processed files" subfolder
                string destinationPath = Path.Combine(processedFilesFolder, fileName);
                File.Move(file, destinationPath);
            }
            return inputFiles;
        }

        public static Match inputFileToMatch(InputFile inputFile)
        {
            List<Odds> oddsList = new List<Odds>();
            Dictionary<int, string> runnersDict = new Dictionary<int, string>();
            string eventName = "Unknown eventName";
            DateTime startTime = new DateTime(1900, 1, 1);

            foreach (Rootobject r in inputFile.Rootobjects)
            {
                DateTime timeStamp = DateTimeOffset.FromUnixTimeMilliseconds(r.pt).UtcDateTime;

                foreach (Mc mc in r.mc ?? Enumerable.Empty<Mc>())
                {
                    if (mc.marketDefinition != null)
                    {
                        eventName = mc.marketDefinition?.eventName ?? "Unknown eventName";
                        startTime = mc.marketDefinition?.marketTime ?? new DateTime(1900, 1, 1);

                        foreach (Runner runner in mc.marketDefinition?.runners ?? Enumerable.Empty<Runner>())
                        {
                            if (runner.name != null)
                            {
                                runnersDict.TryAdd(runner.id, runner.name);
                            }
                        }
                    }
                    else if (mc.rc != null)
                    {
                        foreach (Rc rc in mc.rc ?? Enumerable.Empty<Rc>())
                        {
                            Odds odds = new Odds(timeStamp, runnersDict[rc.id], rc.ltp);
                            oddsList.Add(odds);
                        }
                    }
                }
            }

            return new Match(eventName, startTime, oddsList);
        }
    }
}