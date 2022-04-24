using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class TerminalApiService
    {
        private readonly HttpClient _httpClient;

        public TerminalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

       

        public async Task<TerminalDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<TerminalDto>>($"terminal/{id}");
            return response.Data;


        }
        public async Task<List<TerminalDto>> AllAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<TerminalDto>>>($"terminal");
            return response.Data;


        }
        public async Task<TerminalDto> SaveAsync(TerminalDto newTerminal)
        {
            var response = await _httpClient.PostAsJsonAsync("terminal", newTerminal);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<TerminalDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(TerminalDto newTerminal)
        {
            var response= await _httpClient.PutAsJsonAsync("terminal", newTerminal);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"terminal/{id}");

            return response.IsSuccessStatusCode;
        }



     

    }
}
