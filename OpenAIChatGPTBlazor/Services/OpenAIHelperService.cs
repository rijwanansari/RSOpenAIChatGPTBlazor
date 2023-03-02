using OpenAI_API;
using OpenAIChatGPTBlazor.Services.Dto;
using System.Text;
using System.Text.Json;
using System.Timers;

namespace OpenAIChatGPTBlazor.Services
{
    public class OpenAIHelperService : IOpenAIHelperService
    {
        private readonly ILogger<OpenAIHelperService> _logger;
        private string _apiKey = "Enter you API KEY";
        private string _model = "text-davinci-003";
        public OpenAIHelperService(ILogger<OpenAIHelperService> logger)
        {
            _logger = logger;   
        }
        public async Task<string> GetResponse(string message)
        {
            try
            {
                OpenAIAPI api = new OpenAIAPI(new APIAuthentication(_apiKey));
                var client = new OpenAI_API.APIAuthentication(_apiKey);
                var result = await api.Completions.CreateCompletionAsync(
                    new CompletionRequest(
                        message, 
                        model: Model.CurieText, 
                        temperature: 0.1));
                return result.Completions[0].Text.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CompletionResponseDto> GetHttpResponseAsync(string prompt)
        {
            try
            {
                CompletionResponseDto completionResponse = new CompletionResponseDto();
                CompletionRequestDto completionRequest = new CompletionRequestDto
                {
                    Model = _model,
                    Prompt = prompt,
                    MaxTokens = 120,
                    TopP = 0.3f,
                    FrequencyPenalty = 0.5f,
                    PresencePenalty = 0
                };
                using (HttpClient httpClient = new HttpClient())
                {
                    using (var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/completions"))
                    {
                        httpReq.Headers.Add("Authorization", $"Bearer {_apiKey}");
                        string requestString = JsonSerializer.Serialize(completionRequest);
                        httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");
                        using (HttpResponseMessage? httpResponse = await httpClient.SendAsync(httpReq))
                        {
                            if (httpResponse is not null)
                            {
                                if (httpResponse.IsSuccessStatusCode)
                                {
                                    string responseString = await httpResponse.Content.ReadAsStringAsync();
                                    {
                                        if (!string.IsNullOrWhiteSpace(responseString))
                                        {
                                            completionResponse = JsonSerializer.Deserialize<CompletionResponseDto>(responseString);
                                        }
                                    }
                                }
                            }
                            return completionResponse;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
