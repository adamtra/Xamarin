using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PJATK.Models;
using PJATK.Utils;

namespace PJATK.Services
{
    public sealed class WebService
    {
        private const string BaseUrl = "https://ws.pjwstk.edu.pl";
        private const string EmailSuffix = "@pjwstk.edu.pl";
        private string _userName;
        private string _password;
        private static volatile WebService _instance;
        private static readonly object SyncRoot = new object();
        private NetworkCredential _credentials;

        public static WebService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new WebService();
                            var userCredentials = CredentialLocker.GetUserCredentials();
                            if (userCredentials != null)
                            {
                                _instance.SetUserCredentials(userCredentials.UserName, userCredentials.Password);
                            }
                        }
                    }
                }

                return _instance;
            }
        }

        private WebService()
        {
        }

        public void SetUserCredentials(string userName, string password)
        {
            _userName = userName.ToLower();
            _password = password;

            _credentials = GetNetworkCredential();
        }

        public async Task<StudentPersonalData> GetStudentPersonalData()
        {
            return await Get<StudentPersonalData>("test/Service.svc/XmlService/GetStudentPersonalDataJson");
        }

        public async Task<ICollection<StudentSchedule>> GetStudentSchedules(DateTime from, DateTime to)
        {
            return await Get<ICollection<StudentSchedule>>(string.Format("test/Service.svc/XmlService/GetStudentScheduleJson?begin={0:yyyy-MM-dd}&end={1:yyyy-MM-dd}", from, to));
        }

        public async Task<string> GetGetPersonImageJson()
        {
            return await Get<string>("test/Service.svc/XmlService/GetStudentPersonalDataJson");
        }

        private async Task<T> Get<T>(string url) where T : class
        {
            try
            {
                string noCache;
                if (url.Contains("?"))
                {
                    noCache = "&nocache=" + DateTime.Now.Ticks;
                }
                else
                {
                    noCache = "?nocache=" + DateTime.Now.Ticks;
                }

                var fullUrl = $"{BaseUrl}/{url}{noCache}";

                var request = (HttpWebRequest)WebRequest.Create(fullUrl);
                request.Method = "GET";
                request.Credentials = _credentials;

                using (var response = (HttpWebResponse)await request.GetResponseAsync())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var result = await reader.ReadToEndAsync();
                            OfflineStorage.SaveData<T>(result);
                            return JsonConvert.DeserializeObject<T>(result);
                        }
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Response is HttpWebResponse response)
                {
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return null;
                    }
                }
                var result = await OfflineStorage.GetData<T>();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        private NetworkCredential GetNetworkCredential()
        {
            return _userName.Contains(EmailSuffix)
                ? new NetworkCredential(_userName, _password)
                : new NetworkCredential($"{_userName}{EmailSuffix}", _password);
        }
    }
}
