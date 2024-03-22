using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SongRecommendation.Application.Contracts.Dtos;
using SongRecommendation.Application.Features.Commands.UserSongCommands;
using SongRecommendation.Application.Features.Commands.UserSongCommands.UpdateLikes;
using SongRecommendation.UI.ApiConsumeServices.Interface;
using SongRecommendation.UI.Models;

namespace SongRecommendation.UI.ApiConsumeServices.Implementations
{
	public class SongApiConsumeService : ISongApiConsumeService
	{
		private readonly ILogger<SongApiConsumeService> _logger;
		private readonly HttpClient _httpClient;
		private readonly ApiUrlOptions _options;
		public SongApiConsumeService(ILogger<SongApiConsumeService> logger,
			HttpClient httpClient, IOptions<ApiUrlOptions> options)
		{
			_httpClient = httpClient;
			_logger = logger;
			_options = options.Value;
		}
		public async Task<bool> AddLikesAndRatingsToSong(AddLikesCommand addLikes)
		{
			try
			{
				string url = $"{_options.SongBaseUrl}AddLikesAndRatingsToSong";
				var response = await _httpClient.PostAsJsonAsync(url, addLikes);
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
				_logger.LogError(ex, "Error in AddLikesAndRatingsToSong");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in AddLikesAndRatingsToSong");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> AddSong(GetSongsDto addSong)
		{
			try
			{
				string url = $"{_options.SongBaseUrl}AddSong";
				var response = await _httpClient.PostAsJsonAsync(url, addSong);
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
				_logger.LogError(ex, "Error in AddSong");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in AddSong");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> DeleteSong(int id)
		{
			try
			{
				string url = $"{_options.SongBaseUrl}DeleteSong/{id}";
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
			catch (HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in DeleteSong");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in DeleteSong");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<List<GetSongsDto>> GetAllSongs()
		{
			try
			{
				string url = $"{_options.SongBaseUrl}GetAllSongs";
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
			catch (HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetAllSongs");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in GetAllSongs");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<List<GetUserSongDto>> GetListOfAllLikes()
		{
			try
			{
				string url = $"{_options.SongBaseUrl}GetListOfAllLikes";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					var result = JsonConvert.DeserializeObject<List<GetUserSongDto>>(stringResponse);
					return result;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch (HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetListOfAllLikes");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in GetListOfAllLikes");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public async Task<GetSongsDto> GetSongById(int id)
		{
			try
			{
				string url = $"{_options.SongBaseUrl}GetSongById/{id}";
				var response = await _httpClient.GetAsync(url);
				if (response.IsSuccessStatusCode)
				{
					var stringResponse = await response.Content.ReadAsStringAsync();
					Console.WriteLine("Response Content: " + stringResponse);
					var result = JsonConvert.DeserializeObject<GetSongsDto>(stringResponse);
					return result;
				}
				else
				{
					Console.WriteLine("HTTP Status Code: " + response.StatusCode);
					throw new HttpRequestException(response.ReasonPhrase);
				}
			}
			catch (HttpRequestException ex)
			{
				_logger.LogError(ex, "Error in GetSongById");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in GetSongById");
				Console.WriteLine("Exception: " + ex.Message);
				return null;
			}
		}

		public  async Task<bool> UpdateLikes(UpdateLikesCommand updateLikes)
		{
			try
			{
				string url = $"{_options.SongBaseUrl}UpdateLikes";
				var response = await _httpClient.PutAsJsonAsync(url, updateLikes);
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
				_logger.LogError(ex, "Error in UpdateLikes");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error in UpdateLikes");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> UpdateSong(GetSongsDto updateSong)
		{
			try
			{
				string url = $"{_options.SongBaseUrl}UpdateSong";
				var response = await _httpClient.PutAsJsonAsync(url, updateSong);
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
				_logger.LogError(ex, "Error in UpdateSong");
				Console.WriteLine("HTTP Request Exception: " + ex.Message);
				return false;
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, "Error in UpdateSong");
				Console.WriteLine("Exception: " + ex.Message);
				return false;
			}
		}
	}
}
