using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.UI.ApiConsumeServices.Interface;
using SongRecommendation.UI.Models;

namespace SongRecommendation.UI.ApiConsumeServices.Implementations
{
	public class UserApiConsumeService : IUserApiConsumeService
	{
		private readonly ILogger<UserApiConsumeService> _logger;
		private readonly HttpClient _httpClient;
		private readonly ApiUrlOptions _options;
        public UserApiConsumeService(ILogger<UserApiConsumeService> logger,
			HttpClient httpClient, IOptions<ApiUrlOptions> options)
        {
			_httpClient = httpClient;
			_logger = logger;
			_options = options.Value;
        }
        public async Task<bool> AddUser(GetUserDto userCreate)
		{
			try
			{
				string url = $"{_options.UserBaseUrl}AddUser";
				var response = await _httpClient.PostAsJsonAsync(url, userCreate);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					return true;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch (HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in AddUser");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in AddUser");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> DeleteUser(int id)
		{
			try
			{
				string url = $"{_options.UserBaseUrl}DeleteUser/{id}";
				var response = await _httpClient.DeleteAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					return true;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch(HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in DeleteUser");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in DeleteUser");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<List<GetUserDto>> GetAllUsers()
		{
			try
			{
				string url = $"{_options.UserBaseUrl}GetAllUsers";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					var result = JsonConvert.DeserializeObject<List<GetUserDto>>(stringResponse);
					return result;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch(HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetAllUsers");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in GetAllUsers");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<List<GetSongsDto>> GetListOfRecommendedSong(int userId)
		{
			try
			{
				string url = $"{_options.UserBaseUrl}GetRecommeded/{userId}";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					var result = JsonConvert.DeserializeObject<List<GetSongsDto>>(stringResponse);
					return result;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch(HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetListOfRecommendedSong");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in GetListOfRecommendedSong");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<List<GetSongsDto>> GetListSongsDifferentFromLikedSong(int userId)
		{
			try
			{
				string url = $"{_options.UserBaseUrl}GetDifferentSongsFromLikedSongs/{userId}";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					var result = JsonConvert.DeserializeObject<List<GetSongsDto>>(stringResponse);
					return result;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch(HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetListSongsDifferentFromLikedSong");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in GetListSongsDifferentFromLikedSong");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<GetUserDto> GetUserById(int id)
		{
			try
			{
				string url = $"{_options.UserBaseUrl}GetUserById/{id}";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					var result = JsonConvert.DeserializeObject<GetUserDto>(stringResponse);
					return result;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch(HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetUserById");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in GetUserById");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<bool> UpdateUser(GetUserDto userUpdate)
		{
			string url = $"{_options.UserBaseUrl}UpdateUser";
			try
			{
				var response = await _httpClient.PutAsJsonAsync(url, userUpdate);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					return true;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch(HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in UpdateUser");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in UpdateUser");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}
	}
}
