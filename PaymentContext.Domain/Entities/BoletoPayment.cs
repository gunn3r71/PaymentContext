﻿using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode,
                             Email email,
                             string boletoNumber,
                             DateTime paidDate,
                             DateTime expireDate,
                             Money total,
                             Money totalPaid,
                             string payer,
                             Document document,
                             Address address)
               : base(paidDate,
                      expireDate,
                      total,
                      totalPaid,
                      payer,
                      document,
                      address)
        {
            BarCode = barCode;
            Email = email;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public Email Email { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}