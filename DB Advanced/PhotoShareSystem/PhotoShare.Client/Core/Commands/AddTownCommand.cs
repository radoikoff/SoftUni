﻿namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;

    public class AddTownCommand : ICommand
    {
        private readonly ITownService townService;
        private readonly ISessionService sessionService;

        public AddTownCommand(ITownService townService, ISessionService sessionService)
        {
            this.townService = townService;
            this.sessionService = sessionService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            if (!this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string townName = data[0];
            string country = data[1];

            var townExists = this.townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }

            var town = this.townService.Add(townName, country);

            return $"Town {townName} was added successfully!";
        }
    }
}
