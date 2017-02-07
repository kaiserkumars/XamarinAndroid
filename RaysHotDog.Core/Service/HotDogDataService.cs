using RaysHotDog.Core.Model;
using RaysHotDog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDog.Core.Service
{
    public class HotDogDataService
    {
        private static HotDogRepository hotDogRepository = new HotDogRepository();

        public List<HotDog> GetAllHotDogs() { return hotDogRepository.GetAllHotDogs(); }

        public List<HotDogGroup> GetGroupedHotDogs() { return hotDogRepository.GetGroupedHotDogs(); }

        public List<HotDog> GetHotDogsForgroup(int hotDogGroupID) { return hotDogRepository.GetHotDogForGroups(hotDogGroupID); }

        public List<HotDog> GetFavouriteHotDogs() { return hotDogRepository.GetFavouriteHotDogs(); }

        public HotDog GetHotDogByID(int hotDogID) { return hotDogRepository.GetHotDogByID(hotDogID); }

    }
}
