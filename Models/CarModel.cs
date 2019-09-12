using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareForceOne.Models
{
    public class CarModel
    {
        [Key]
        public int CarId { get; set; }
        public string CarRegNumber { get; set; }
        public string CarBrand { get; set; }
        public string CarBrandModel { get; set; }
        public decimal CarFuelConsumption { get; set; }
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
