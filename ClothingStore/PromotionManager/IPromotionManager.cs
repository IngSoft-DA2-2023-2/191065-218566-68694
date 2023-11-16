using ClothingStore.Domain.Entities;
using PromotionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionManager
{
    public interface IPromotionManager
    {
        public void PromotionDllLoad(string pathToFile);

        public void PromotionDllUnload(string filename);

        public void RunPromotions(ShoppingCart sp);

        public List<Tuple<string, string, string>> GetPromotionList();

    }
}
