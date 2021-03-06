using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    { 
        public void CreateSubscription(Student student)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if (document == "78608644010")
                return true;
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "lc@lc.com")
                return true;
            return false;
        }

        public void UpdateSubscription(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
