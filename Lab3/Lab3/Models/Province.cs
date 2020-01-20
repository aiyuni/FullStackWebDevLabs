using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Lab3.Models
{
    public class Province
    {   
        [Key]
        public string ProvinceCode { get; set; }

        public string ProvinceName { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
