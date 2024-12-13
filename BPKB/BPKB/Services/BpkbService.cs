using BPKB.Data;
using BPKB.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Xml.Linq;

namespace BPKB.Services
{
    public class BpkbService
    {
        private readonly HttpClient _httpClient;
        public BpkbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StorageLocationModel>> GetLocation()
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                IEnumerable<StorageLocationModel> locations = await _httpClient.GetFromJsonAsync<IEnumerable<StorageLocationModel>>("https://localhost:7175/api/BPKB/GetLocation");

                return locations;
            }
            catch (Exception ex)
            {
                return new List<StorageLocationModel>();
            }
        }
        public async Task<StorageLocationModel> GetLocationByName(string name)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                string baseUrl = "https://localhost:7175/api/BPKB/GetLocationByName";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, "LocationName", name);
                StorageLocationModel locations = await _httpClient.GetFromJsonAsync<StorageLocationModel>(urlWithQuery);

                return locations;
            }
            catch (Exception ex)
            {
                return new StorageLocationModel();
            }
        }

        public async Task<UserModel> GetUser(UserModel userData)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                var queryParams = new Dictionary<string, string>
                {
                    { "Username", userData.Username },
                    { "Password", userData.Password }                   
                };
                string baseUrl = "https://localhost:7175/api/BPKB/Login";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, queryParams);
                UserModel user = await _httpClient.GetFromJsonAsync<UserModel>(urlWithQuery);

                return user;
            }
            catch (Exception ex)
            {
                return new UserModel();
            }
        }
        public async Task SubmitBPKB(BpkbModel data)
        {
            try
            {
                //_httpClient.Timeout = TimeSpan.FromSeconds(30);
                //var bpkbData = new
                //{
                //    AgreementNumber = data.AgreementNumber,
                //    BranchId = data.BranchId,
                //    BpkbNo = data.BpkbNo,
                //    BpkbDateIn = data.BpkbDateIn.ToString(),
                //    BpkbDate = data.BpkbDate.ToString(),
                //    FakturNo = data.FakturNo,
                //    FakturDate = data.FakturDate.ToString(),
                //    PoliceNo = data.PoliceNo,
                //    LocationId = data.LocationId,
                //    LocationName = "Location",
                //    CreatedBy = data.CreatedBy,
                //    LastUpdatedBy = data.LastUpdatedBy
                //};
                var queryParams = new Dictionary<string, string>
                {
                    { "AgreementNumber", data.AgreementNumber },
                    { "BpkbNo", data.BpkbNo },
                    { "BranchId", data.BranchId },
                    { "BpkbDate", data.BpkbDate.ToString() },
                    { "FakturNo", data.FakturNo },
                    { "FakturDate", data.FakturDate.ToString() },
                    { "LocationId", data.LocationId },
                    { "PoliceNo", data.PoliceNo },
                    { "BpkbDateIn", data.BpkbDateIn.ToString() },
                    { "CreatedBy", data.CreatedBy },
                    { "LastUpdatedBy", data.LastUpdatedBy }
                };
                string baseUrl = "https://localhost:7175/api/BPKB/Create";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, queryParams);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "BranchId", data.BranchId);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "BpkbNo", data.BpkbNo);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "BpkbDateIn", data.BpkbDateIn.ToString());
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "BpkbDate", data.BpkbDate.ToString());
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "FakturNo", data.FakturNo);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "FakturDate", data.FakturDate.ToString());
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "PoliceNo", data.PoliceNo);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "LocationId", data.LocationId);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "LocationName", data.LocationName);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "CreatedBy", data.CreatedBy);
                //urlWithQuery += QueryHelpers.AddQueryString(baseUrl, "LastUpdatedBy", data.LastUpdatedBy);
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(urlWithQuery, "");

                
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
