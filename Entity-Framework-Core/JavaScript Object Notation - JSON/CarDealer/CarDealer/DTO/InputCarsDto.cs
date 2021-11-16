using CarDealer.Models;
using System.Collections;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class InputCarsDto
    {
        public InputCarsDto()
        {
            partsId = new List<int>();
        }
        public string Make { get; set; }

        public string Model { get; set; }

        public int TravelledDistance { get; set; }

        public List<int> partsId { get; set; }
    }
}
