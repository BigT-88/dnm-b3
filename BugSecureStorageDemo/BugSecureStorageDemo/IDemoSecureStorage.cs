using System;
namespace BugSecureStorageDemo.Services
{
    public interface IDemoSecureStorage
    {
        Task<bool> IsSecureStorageEnabled();
        Task SetAsync(string key, string value);
        Task<string> GetAsync(string key);
        bool RemoveKey(string key);
        void RemoveAll();
    }
}
