using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionManager
{
    public class PromotionImp : IPromotionManager
    {
        public void PromotionDllLoad(string pathToFile)
        {
            PromotionManagerImplementation.PromotionDllLoad(pathToFile);
        }
        public void PromotionDllUnload(string filename)
        {
            PromotionManagerImplementation.PromotionDllUnload(filename);
        }
        public void RunPromotions(ShoppingCart sp)
        {
            PromotionManagerImplementation.RunPromotions(sp);
        }

        public List<Tuple<string, string, string>> GetPromotionList()
        {
            return PromotionManagerImplementation.GetPromotionListMethods();
        }
    }
}
