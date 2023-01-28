using DTO;

namespace BLL
{
    public interface ICovidObervationsService
    {
        Task<ResponseDTO> GetCovidList(DateOnly observationDate, int maxResult);
    }
}