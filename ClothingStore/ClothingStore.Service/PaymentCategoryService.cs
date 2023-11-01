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
    public class PaymentCategoryService: IPaymentCategoryService
    {
        private readonly IPaymentCategoryRepository _paymentCategoryRepository;
        public PaymentCategoryService(IPaymentCategoryRepository paymentCategoryRepository)
        {
            _paymentCategoryRepository = paymentCategoryRepository;
        }
        public List<PaymentCategory> GetAll()
        {
            List<PaymentCategory> paymentCategories = _paymentCategoryRepository.GetAll();
            return paymentCategories;
        }

        public PaymentCategory GetById(int id)
        {
            PaymentCategory paymentCategory = _paymentCategoryRepository.GetById(id);
            if (paymentCategory == null)
            {
                throw new ArgumentException($"No se puede obtener la categoría de medio de pago");
            }
            return paymentCategory;
        }

        public PaymentCategory GetByName(string name)
        {
            PaymentCategory paymentCategory = _paymentCategoryRepository.GetByName(name);
            if (paymentCategory == null)
            {
                throw new ArgumentException($"No se puede obtener la categoría de medio de pago");
            }
            return paymentCategory;
        }
    }
}
