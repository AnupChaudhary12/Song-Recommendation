using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SongRecommendation.Application.Contracts.Dtos
{
    public class GetUserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; } = default!;
        [JsonProperty("email")]
        public string Email { get; set; } = default!;
    }
}
