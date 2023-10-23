using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class BrandService: IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public List<Brand> GetAll()
        {
            List<Brand> brands = _brandRepository.GetAll();
            return brands;
        }

        public Brand GetById(int id)
        {
            Brand brand = _brandRepository.GetById(id);
            if (brand == null)
            {
                throw new ArgumentException($"No se puede obtener la marca");
            }
            return brand;
        }

        public Brand GetByName(string name)
        {
            Brand brand = _brandRepository.GetByName(name);
            if (brand == null)
            {
                throw new ArgumentException($"No se puede obtener la marca");
            }
            return brand;
        }
    }
}
