﻿using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    public class Program
    {
        public static void Main()
        {
            using (HospitalContext context = new HospitalContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }
        }
    }
}
