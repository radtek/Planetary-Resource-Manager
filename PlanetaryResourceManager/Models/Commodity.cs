﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryResourceManager.Models
{
    public class Commodity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ItemId { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - ({1})", Name, ItemId);
        }
    }
}
