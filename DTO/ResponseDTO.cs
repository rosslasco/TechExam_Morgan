using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ResponseDTO
    {
        public string? observation_date { get; set; }
        public List<Countries>? countries { get; set; }


    }

    public class Countries
    {
        public string? country { get; set; }
        public decimal confirmed { get; set; }
        public decimal deaths { get; set; }
        public decimal recovered { get; set; }
    }
}
