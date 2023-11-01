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
    public class PaymentService: IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public List<Payment> GetAll()
        {
            List<Payment> payments = _paymentRepository.GetAll();
            return payments;
        }

        public Payment GetById(int id)
        {
            Payment payment = _paymentRepository.GetById(id);
            if (payment == null)
            {
                throw new ArgumentException($"No se puede obtener el medio de pago");
            }
            return payment;
        }

        public Payment GetByName(string name)
        {
            Payment payment = _paymentRepository.GetByName(name);
            if (payment == null)
            {
                throw new ArgumentException($"No se puede obtener el medio de pago");
            }
            return payment;
        }
    }
}
