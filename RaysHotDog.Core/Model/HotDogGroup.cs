using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDog.Core.Model
{
   public class HotDogGroup
    {
        public int HotDogGroupID { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public List<HotDog> HotDogs { get; set; }
        
    }
}
