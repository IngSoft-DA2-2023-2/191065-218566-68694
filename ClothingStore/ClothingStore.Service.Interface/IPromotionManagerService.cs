using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IPromotionManagerService
    {
        public void PromotionDllLoad(string pathToFile);

        public void PromotionDllUnload(string filename);

        public List<Tuple<string, string, string>> GetPromotionList();
    }
}
