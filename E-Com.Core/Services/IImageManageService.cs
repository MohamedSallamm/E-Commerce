using Microsoft.AspNetCore.Http;

namespace E_Com.Core.Services
{
    public interface IImageManageService
    {

        //  Task<List<string>> AddImageAsync(List<IFormFile> Photo, string src);
        Task<List<string>> AddImageAsync(List<IFormFile> Photo, string src); // يرجع string واحد

        void DeleteImageAsync(string src);

    }
}
