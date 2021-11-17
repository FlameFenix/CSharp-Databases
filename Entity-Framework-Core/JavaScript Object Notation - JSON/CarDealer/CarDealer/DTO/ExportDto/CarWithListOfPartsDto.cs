using System.Collections.Generic;

namespace CarDealer.DTO.ExportDto
{
    public class CarWithListOfPartsDto
    {
        public CarDto car { get; set; }

        public IEnumerable <PartDto> parts { get; set; }
    }
}
