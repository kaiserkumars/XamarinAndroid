using RaysHotDog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDog.Core.Repository
{
    public class HotDogRepository
    {
        public static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>() {
            new HotDogGroup()
            {
                HotDogGroupID = 1, Title = "Veg Lovers", ImagePath="", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogID= 1,
                        Name = "Regular HD",
                        ShortDescription = "Best piece !",
                        Description="Lorem Ipsum ainan Iansn ahvsjiahfnv.",
                        ImagePath="hotdog1",
                        Available= true,
                        PrepTime=10,
                        Ingredients= new List<string>() {"Regular Bun","Sausage","Onion","Garlic" },
                        Price=8,
                        IsFavourite=true,
                    },

                  new HotDog()
                  {
                      HotDogID= 2,
                        Name = "Big Regular HD",
                        ShortDescription = "Second Best piece !",
                        Description="Lorem Ipsum Protumd Hinsak ainan Iansn ahvsjiahfnv.",
                        ImagePath="hotdog2",
                        Available= true,
                        PrepTime=15,
                        Ingredients= new List<string>() {"Regular Bun","Sausage","Onion","Garlic","Chutney" },
                        Price=10,
                        IsFavourite=false,
                  },

                   new HotDog()
                  {
                      HotDogID = 3,
                        Name = "Big Extra Regular HD",
                        ShortDescription = "Third Best piece !",
                        Description="Lorem saf Ipsum Protumd Hiksnsak ainan Iansn ahvsjiahfnv.",
                        ImagePath="hotdog3",
                        Available= true,
                        PrepTime=24,
                        Ingredients= new List<string>() {"Extra Regular Bun","Sausage","Onion","Garlic","Chutney" },
                        Price=20,
                        IsFavourite=false,
                  }
                }
            },

            new HotDogGroup()
            {
                HotDogGroupID = 2, Title = "Veg Lovers", ImagePath="", HotDogs = new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogID= 4,
                        Name = "Regular Ceese HD",
                        ShortDescription = "Best piece !",
                        Description="Lorem Ipsum ainan Iansn ahvsjiahfnv.",
                        ImagePath="hotdog4",
                        Available= true,
                        PrepTime=10,
                        Ingredients= new List<string>() {"Regular Bun","Sausage","Onion","Garlic" },
                        Price=8,
                        IsFavourite=true,
                    },

                  new HotDog()
                  {
                      HotDogID= 5,
                        Name = "Big Regular CHeese HD",
                        ShortDescription = "Second Best piece !",
                        Description="Lorem Ipsum Protumd Hinsak ainan Iansn ahvsjiahfnv.",
                        ImagePath="hotdog5",
                        Available= true,
                        PrepTime=15,
                        Ingredients= new List<string>() {"Regular Bun","Sausage","Onion","Garlic","Chutney" },
                        Price=10,
                        IsFavourite=false,
                  },

                   new HotDog()
                  {
                      HotDogID = 6,
                        Name = "Big Extra Regular Cheese HD",
                        ShortDescription = "Third Best piece !",
                        Description="Lorem saf Ipsum Protumd Hiksnsak ainan Iansn ahvsjiahfnv.",
                        ImagePath="hotdog6",
                        Available= true,
                        PrepTime=24,
                        Ingredients= new List<string>() {"Extra Regular Bun","Sausage","Onion","Garlic","Chutney" },
                        Price=20,
                        IsFavourite=false,
                  }
                }
            }

        };


        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from HotDogGroup in hotDogGroups
                                          from HotDog in HotDogGroup.HotDogs
                                          select HotDog;
            return hotDogs.ToList<HotDog>(); 
        }

        public HotDog GetHotDogByID(int hotDogID) {

            IEnumerable<HotDog> hotDogs = from HotDogGroup in hotDogGroups
                                          from HotDog in HotDogGroup.HotDogs
                                          where HotDog.HotDogID == hotDogID
                                          select HotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogForGroups(int hotDogGroupID)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupID == hotDogGroupID).FirstOrDefault();
            if (group != null)
            {
                return group.HotDogs;

            }

            return null;
        }

        public List<HotDog> GetFavouriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = from HotDogGroup in hotDogGroups
                                          from HotDog in HotDogGroup.HotDogs
                                          where HotDog.IsFavourite
                                          select HotDog;
            return hotDogs.ToList<HotDog>();
        }
    }
}
