using System;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        
        public Subscription(DateTime createDate, DateTime lastUpdateDate, DateTime? expireDate) 
        {
            CreateDate = createDate;
            LastUpdateDate = lastUpdateDate;
            ExpireDate = expireDate;   
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
    }
}