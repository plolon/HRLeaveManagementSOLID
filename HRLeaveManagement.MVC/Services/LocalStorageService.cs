using Hanssens.Net;
using HRLeaveManagement.MVC.Contracts;
using System.Collections.Generic;

namespace HRLeaveManagement.MVC.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage localStorage;
        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HR.LEAVEMGMT"
            };
            localStorage = new LocalStorage(config);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
            {
                localStorage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return localStorage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return localStorage.Get<T>(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            localStorage.Store(key, value);
            localStorage.Persist();
        }
    }
}
