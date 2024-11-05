using Microsoft.AspNetCore.Http;

namespace FilesDownload.Models
{
    public class FileModel : BaseModel
    {
        public IFormFile File { get; set; }
        public byte[] Contents { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
    }
}
