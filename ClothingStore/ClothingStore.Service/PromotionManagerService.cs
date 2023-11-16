using ClothingStore.Service.Interface;
using PromotionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class PromotionManagerService : IPromotionManagerService
    {
        private readonly IPromotionManager _promotionManager = new PromotionImp();

        public void PromotionDllLoad(string pathToFile) 
        {
            _promotionManager.PromotionDllLoad(pathToFile);
        }

        public void PromotionDllUnload(string filename)
        {
            _promotionManager.PromotionDllUnload(filename);
        }

        public List<Tuple<string, string, string>> GetPromotionList()
        {
            return _promotionManager.GetPromotionList();
        }
    }
}
