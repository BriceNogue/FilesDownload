using FilesDownload.Contracts;
using Microsoft.AspNetCore.Http;

namespace FilesDownload.Services
{
    public class FileService : IFileService
    {
        string url = "";
        HttpClient client = new();

        public async Task DownloadFile(string fileName)
        {
            client.GetAsync(url).Wait();
        }

        //public Task GetAllFile()
        //{
        //    client.Dispose();
        //}

        public async Task UploadFile(string fileName, byte[] fileContent)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            client.SendAsync(request);
        }

        public async Task<string> UploadFileToDriver(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "Le fichier est vide";
            }

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string filePath = Path.Combine(uploadPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "Fichier téléchargé avec succès";
        }
    }
}
