using System;
namespace BugSecureStorageDemo.Services
{
    public class SecureStorageService : IDemoSecureStorage
    {

        public async Task<string> GetAsync(string key)
        {
            var value = string.Empty;
            try
            {
                value = await SecureStorage.GetAsync(key);
                return value;
            }
            catch (Exception ex)
            {
                return value;
                //need to handle exception when secure storage is not supported on device
            }
        }

        public async Task<bool> IsSecureStorageEnabled()
        {
            var isEnabled = false;
            try
            {
                await SecureStorage.SetAsync("TestSecureStorage", "Testing Secure Storage");
                SecureStorage.Remove("TestSecureStorage");
                isEnabled = true;
                return isEnabled;
            }
            catch (Exception ex)
            {
                return isEnabled;
            }
        }

        public void RemoveAll()
        {
            SecureStorage.RemoveAll();
        }

        public bool RemoveKey(string key)
        {
            return SecureStorage.Remove(key);
        }

        public async Task SetAsync(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception ex)
            {
                //need to handle exception when secure storage is not supported on device
            }
        }
    }
}
