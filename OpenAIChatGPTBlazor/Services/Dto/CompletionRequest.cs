using System.Text.Json.Serialization;

namespace OpenAIChatGPTBlazor.Services.Dto
{
    public class CompletionRequestDto
    {
        [JsonPropertyName("model")]
        public string? Model
        {
            get;
            set;
        }
        [JsonPropertyName("prompt")]
        public string? Prompt
        {
            get;
            set;
        }
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens
        {
            get;
            set;
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("temperature")]
        public float Temperature
        {
            get;
            set;
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("top_p")]
        public float TopP
        {
            get;
            set;
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("presence_penalty")]
        public float PresencePenalty
        {
            get;
            set;
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("frequency_penalty")]
        public float FrequencyPenalty
        {
            get;
            set;
        }

    }
}
