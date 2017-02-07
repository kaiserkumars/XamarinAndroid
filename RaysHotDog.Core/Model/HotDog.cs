﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDog.Core.Model
{
    public class HotDog
    {
        public int HotDogID { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public int Price { get; set; }

        public bool Available { get; set; }

        public int PrepTime { get; set; }

        public List<string> Ingredients { get; set; }

        public bool IsFavourite { get; set; }

        public string GroupName { get; set; }

    }
}
