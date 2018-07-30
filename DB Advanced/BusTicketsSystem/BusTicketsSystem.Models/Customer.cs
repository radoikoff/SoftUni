namespace BusTicketsSystem.Models
{
    using BusTicketsSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        //first name, last name, date of birth, gender, home town

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int TownId { get; set; }
        public Town HomeTown { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
