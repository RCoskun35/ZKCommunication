using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserDto>> AllAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<UserDto>>>($"user");
            return response.Data;

        }


        public async Task<UserDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<UserDto>>($"user/{id}");
            return response.Data;


        }

        public async Task<UserDto> SaveAsync(UserDto newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("user", newUser);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<UserDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(UserDto newUser)
        {
            var response= await _httpClient.PutAsJsonAsync("user", newUser);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"user/{id}");

            return response.IsSuccessStatusCode;
        }



     

    }
}
