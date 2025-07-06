using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fire_Safety_Requirements
{
    public class FirestoreService
    {
        private const string ProjectId = "fsiguideapp-2b95b";
        private const string ApiKey = "AIzaSyBKuZ1GC-smmolO5ljnxuQN-InUL4YyqPM";
        private readonly HttpClient _httpClient;

        public FirestoreService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> PostDeviceDataAsync(string deviceId, string period)
        {
            var url = $"https://firestore.googleapis.com/v1/projects/{ProjectId}/databases/(default)/documents/device_data?key={ApiKey}";

            var payload = new
            {
                fields = new
                {
                    deviceId = new { stringValue = deviceId },
                    period = new { stringValue = period },
                    timestamp = new { timestampValue = DateTime.UtcNow.ToString("o") }
                }
            };

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }
    }
}
