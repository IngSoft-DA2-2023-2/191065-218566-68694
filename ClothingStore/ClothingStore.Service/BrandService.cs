using AutoMapper;
using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.BrandDTOs;
using ClothingStore.Service.Interface;


namespace ClothingStore.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public List<BrandResponseDTO> GetAll()
        {
            var brandDtos = _brandRepository.GetAll(); // Suponiendo que esto devuelve List<BrandResponseDTO>
            var brands = _mapper.Map<List<BrandResponseDTO>>(brandDtos);
            return brands;
        }

        public BrandResponseDTO GetById(int id)
        {
            Brand brand = _brandRepository.GetById(id);
            if (brand == null)
            {
                throw new ArgumentException($"No se puede obtener la marca");
            }
            return _mapper.Map<BrandResponseDTO>(brand); ;
        }

        public BrandResponseDTO GetByName(string name)
        {
            Brand brand = _brandRepository.GetByName(name);
            if (brand == null)
            {
                throw new ArgumentException($"No se puede obtener la marca");
            }
            return _mapper.Map<BrandResponseDTO>(brand); ;
        }
    } 
}
