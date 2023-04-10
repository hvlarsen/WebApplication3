namespace WebApplication3.Models
{
    public class InputFile
    {
        public int FileId { get; set; }
        public string? FileName { get; set; }
        public ICollection<Rootobject> Rootobjects { get; set; }
        public InputFile(string fileName)
        {
            FileName = fileName;
            Rootobjects = new List<Rootobject>();
        }
    }
}
