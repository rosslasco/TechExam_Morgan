using DTO;

namespace DAL
{
    public interface IDapperRepository
    {
        Task<IEnumerable<CovidObservationsDTO>> GetList(DateOnly observationDate, int maxResult);
    }
}