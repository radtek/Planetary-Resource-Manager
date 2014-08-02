﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetaryResourceManager.Models
{
    public class Product : Commodity
    {
        public int InputBatchSize { get; set; }
        public int OutputBatchSize { get; set; }
        public double ExportCost { get; set; }
    }
}