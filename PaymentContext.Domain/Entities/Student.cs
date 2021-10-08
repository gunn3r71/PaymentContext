using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
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

            AddNotifications(Name, Document, Email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        private List<Subscription> _subscriptions;
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions; }}

        public void AddSubscription(Subscription subscription)
        {
            var hasActiveSubscription = false;

            if (_subscriptions.Any(x => x.Active))
                hasActiveSubscription = true;

            if (subscription.Payments.Count == 0)
                AddNotification("Subscription.Payments", "This subscription has no payments.");

            if (hasActiveSubscription)
                AddNotification("Subscription", "There is already an active subscription.");
            _subscriptions.Add(subscription);
        }
    }
}