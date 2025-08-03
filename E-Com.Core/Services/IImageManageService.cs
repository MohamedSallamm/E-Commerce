using Microsoft.AspNetCore.Http;

namespace E_Com.Core.Services
{
    public interface IImageManageService
    {

        //  Task<List<string>> AddImageAsync(List<IFormFile> Photo, string src);
        Task<List<string>> AddImageAsync(List<IFormFile> Photo, string src); // واحد string يرجع

        void DeleteImageAsync(string src);

    }
}
