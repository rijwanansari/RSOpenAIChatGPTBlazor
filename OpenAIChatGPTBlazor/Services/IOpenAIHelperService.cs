using OpenAIChatGPTBlazor.Services.Dto;

namespace OpenAIChatGPTBlazor.Services
{
    public interface IOpenAIHelperService
    {
        Task<string> GetResponse(string message);
        Task<CompletionResponseDto> GetHttpResponseAsync(string prompt);
    }
}
