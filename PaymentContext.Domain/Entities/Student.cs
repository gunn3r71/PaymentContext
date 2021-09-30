using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        private List<Subscription> _subscriptions;
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions; }}

        public void AddSubscription(Subscription subscription)
        {
            //Cancela todas as assinaturas e torna essa como principal
            foreach (var sub in Subscriptions)
                sub.Activate();

            _subscriptions.Add(subscription);
        }
    }
}