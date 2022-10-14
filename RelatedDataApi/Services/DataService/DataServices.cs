using AutoMapper;
using Data;
using DTOS;
using Microsoft.EntityFrameworkCore;
using Models;

namespace RelatedDataApi.Services.DataService
{
    public class DataServices: IDataServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DataServices(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ComicDTO>>> getComics()
        {
            try
            {
                if (_context.Comic == null)
                    return new ServiceResponse<List<ComicDTO>>() { Message = "No Data Found", Success = false };
                var comics = await _context.Comic.Select(x => _mapper.Map<ComicDTO>(x)).ToListAsync();
                return new ServiceResponse<List<ComicDTO>>() { Data =comics  };
            } 
            catch (Exception e)
            {
                return new ServiceResponse<List<ComicDTO>>() { Message = e.Message, Success = false };
            }
        }
    }
}
