﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Price { get; set; }

        public IEnumerable<Sale> Sales { get; set; }

    }
}
