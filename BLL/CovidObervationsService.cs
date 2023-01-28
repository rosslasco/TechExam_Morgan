using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CovidObervationsService : ICovidObervationsService
    {
        private readonly IDapperRepository _dapperRepository;
        public CovidObervationsService(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<ResponseDTO> GetCovidList(DateOnly observationDate, int maxResult)
        {
            var data = await _dapperRepository.GetList(observationDate, maxResult);
            ResponseDTO response = new ResponseDTO();
            List<Countries> country = new List<Countries>();
            response.observation_date = observationDate.ToString("yyyy-MM-dd");
            response.countries = new List<Countries>();
            foreach (var item in data)
            {
                response.countries.Add(new Countries { country = item.CountryRegion, confirmed = item.Confirmed, deaths = item.Deaths, recovered = item.Recovered });
            }

            return response;
        }
    }
}
