﻿using ProjektSR.Models;

namespace ProjektSR.Interfaces
{
    public interface IPaymentRepository
    {
        public void CreatePayment(Payment payment);

        public Payment? GetPaymentById(int id);

        public IEnumerable<Payment> GetAllUnpaid();
    }
}
