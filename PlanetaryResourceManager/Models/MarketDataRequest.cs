﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryResourceManager.Models
{
    class MarketDataRequest
    {
        public string TypeId { get; set; }
        public string Duration { get; set; }
        public string SystemId { get; set; }
        public string MinimumQuantity { get; set; }
    }
}