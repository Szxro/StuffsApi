using DTOS;
using Models;
namespace RelatedDataApi.Services.DataService
{
    public interface IDataServices
    {
        Task<ServiceResponse<List<ComicDTO>>> getComics();
    }
}
