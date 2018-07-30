using BusTicketsSystem.Models;
using System;

namespace BusTicketsSystem.Initializer
{
    public class TownsInitializer
    {
        public static Town[] GetTowns()
        {
            var towns = new Town[]
            {
                new Town() {  Name = "Sofia", Country = "Bulgaria"},
                new Town() {  Name = "Plovdiv", Country = "Bulgaria"},
                new Town() {  Name = "Varna", Country = "Bulgaria"},
                new Town() {  Name = "Stara Zagora", Country = "Bulgaria"},
                new Town() {  Name = "London", Country = "United Kingdom"},
                new Town() {  Name = "Paris", Country = "France"},
                new Town() {  Name = "Berlin", Country = "Germany"},
                new Town() {  Name = "Praha", Country = "Czesh Republic"}
            };

            return towns;
        }
    }
}
