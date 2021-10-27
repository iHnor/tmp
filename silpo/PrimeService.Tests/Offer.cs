using System;

namespace PrimeService.Tests
{
    public abstract class Offer
    {
        DateTime expirationDate = DateTime.Now.AddYears(1);
        public void setExpirationDate(DateTime expiration)
        {
            this.expirationDate = expiration;
        }
        
        public void apply(Check check)
        {
            if (checkCondition(check) && checkExpiration())
            {
                check.addPoints(calculatePoints(check));
            }
        }
        protected virtual int calculatePoints(Check check)
        {
            return check.getTotalCost();
        }

        protected virtual bool checkCondition(Check check)
        {
            return true;
        }

        public bool checkExpiration(){
            return DateTime.Now < expirationDate;
        }
    }
}