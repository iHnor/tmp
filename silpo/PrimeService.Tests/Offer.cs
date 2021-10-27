using System;

namespace PrimeService.Tests
{
    public abstract class Offer {
        public void apply(Check check){
            if(checkCondition(check)){
                check.addPoints(calculatePoints(check));
            }
        }
        protected virtual int calculatePoints(Check check) {
            return check.getTotalCost();
        }

        protected virtual bool checkCondition(Check check)
        {
            return true;
        }
        
    }
}