using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareForceOne.Models
{
    public class CarModel
    {
        [Key]
        public int CarId { get; set; }
        [DisplayName("Reg number")]
        public string CarRegNumber { get; set; }

        [DisplayName("Brand")]
        public string CarBrand { get; set; }

        [DisplayName("Model")]
        public string CarBrandModel { get; set; }

        [DisplayName("Fuel consumption")]
        public decimal CarFuelConsumption { get; set; }

        [DisplayName("Creator")]
        public string CarCreator { get; set; }

        private CarModel(string aCarRegNumber, string aCarBrand, string aCarBrandModel, decimal aCarFuelConsumption, string aCarCreator)
        {
            // Här skall vi ändra så den tar in user.id objektet istället.
            CarCreator = aCarCreator;
            CarRegNumber = aCarRegNumber;
            CarBrand = aCarBrand;
            CarBrandModel = aCarBrandModel;
            CarFuelConsumption = aCarFuelConsumption;
        }

        public CarModel()
        {

        }
    }
}
