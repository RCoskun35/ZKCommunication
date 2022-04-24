using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class EventDataApiService
    {
        private readonly HttpClient _httpClient;

        public EventDataApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EventDataDto>> AllAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<EventDataDto>>>($"eventdata");
            return response.Data;

        }

        public async Task<EventDataDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<EventDataDto>>($"eventdata/{id}");
            return response.Data;


        }

        public async Task<EventDataDto> SaveAsync(EventDataDto newEventData)
        {
            var response = await _httpClient.PostAsJsonAsync("eventdata", newEventData);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<EventDataDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(EventDataDto newEventData)
        {
            var response= await _httpClient.PutAsJsonAsync("eventdata", newEventData);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"eventdata/{id}");

            return response.IsSuccessStatusCode;
        }



     

    }
}
