﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinics
{
    public class PetClinic
    {
        private Pet[] pets;

        public PetClinic(string name, int roomCount)
        {
            this.Name = name;
            ValidateRoomCount(roomCount);
            this.pets = new Pet[roomCount];
        }

        public string Name { get; }

        public int Center => this.pets.Length / 2;

        public bool HasEmptyRooms => this.pets.Any(p => p == null);


        private void ValidateRoomCount(int roomCount)
        {
            if (roomCount % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public bool Add(Pet pet)
        {
            int cuurentRoom = this.Center;

            for (int i = 0; i < this.pets.Length; i++)
            {
                if (i % 2 != 0)
                {
                    cuurentRoom -= i;
                }
                else
                {
                    cuurentRoom += i;
                }

                if (this.pets[cuurentRoom] == null)
                {
                    this.pets[cuurentRoom] = pet;
                    return true;
                }
            }

            return false;
        }

        public bool Release()
        {
            for (int i = 0; i < this.pets.Length; i++)
            {
                int index = (this.Center + i) % this.pets.Length;

                if (this.pets[index] != null)
                {
                    this.pets[index] = null;
                    return true;
                }
            }
            return false;
        }

        public string Print(int roomNumber)
        {
            return this.pets[roomNumber - 1]?.ToString() ?? "Room empty";
        }

        public string PrintAll()
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= this.pets.Length; i++)
            {
                sb.AppendLine(this.Print(i));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
