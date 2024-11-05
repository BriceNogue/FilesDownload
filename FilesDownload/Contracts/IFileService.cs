namespace FilesDownload.Contracts
{
    public interface IFileService
    {
        Task UploadFile(string fileName, byte[] fileContent);
        //Task GetAllFile();
        Task DownloadFile(string fileName);
    }
}
