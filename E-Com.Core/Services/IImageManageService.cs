using Microsoft.AspNetCore.Http;

namespace E_Com.Core.Services
{
    public interface IImageManageService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection file, string src);
        void DeleteImageAsync(string src);
    }
}
