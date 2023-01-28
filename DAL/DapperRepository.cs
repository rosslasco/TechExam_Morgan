using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DTO;
using Microsoft.Extensions.Configuration;
using System.IO;
using Npgsql;
using System.Text.RegularExpressions;

namespace DAL
{
    public class DapperRepository : IDapperRepository
    {        
        private readonly IConfiguration _configuration;        
        private readonly NpgsqlConnection connection;
        private const string TABLE_NAME = "covid_observations";
        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connection = new NpgsqlConnection(_configuration.GetConnectionString("postgres"));
            connection.Open();
        }

        public async Task<IEnumerable<CovidObservationsDTO>> GetList(DateOnly observationDate, int maxResult)
        {
            string commandText = $"SELECT \"CountryRegion\", SUM(\"Confirmed\") Confirmed, SUM(\"Deaths\") Deaths, SUM(\"Recovered\") Recovered FROM {TABLE_NAME} " +
                                "WHERE \"ObservationDate\" = CAST(@ObservationDate AS Date) " +
                                "GROUP BY \"CountryRegion\" " +
                                "HAVING SUM(\"Confirmed\") > 0 " +
                                "ORDER BY Confirmed DESC LIMIT @MaxResult;";

            var queryArgs = new { 
                ObservationDate = observationDate.ToString(), 
                MaxResult = maxResult 
            };
            var result = await connection.QueryAsync<CovidObservationsDTO>(commandText, queryArgs);
            return result;
        }
    }
}
