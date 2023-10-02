
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvinceAndCities.Models{
        public class Province
    {   
        [Key]
        public string? ProvinceCode { get; set; }
        public string? ProvinceName { get; set; }

        [InverseProperty("Province")]
        public List<City>? Cities { get; set; }

    }
}