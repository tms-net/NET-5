namespace FileServer.Data
{
    public interface IDatabase
    {
        Task<string> GetDataAsync();
    }

    internal class FileDb : IDatabase
    {
        public Task<string> GetDataAsync()
        {
            return Task.FromResult("FILE CONTENT");
        }
    }
}
