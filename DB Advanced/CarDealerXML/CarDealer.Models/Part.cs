namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public Part()
        {
            this.PartCars = new List<PartCar>();
        }


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCar> PartCars { get; set; }
    }
}
