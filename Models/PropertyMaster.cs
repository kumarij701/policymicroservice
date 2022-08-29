﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyAPI.Models
{
    public class PropertyMaster
    {
        public int PropertyMasterId { get; set; }
        public int CostOfAssest { get; set; }
        public int SalvageValue { get; set; }
        public int UsefulLifeOfAssest { get; set; }
        public int PropertyValue { get; set; }
    }
}
