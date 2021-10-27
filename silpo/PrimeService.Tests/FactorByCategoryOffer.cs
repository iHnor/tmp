using System;

namespace PrimeService.Tests
{
    public class FactorByCategoryOffer : Offer
    {
        public Category category;
        public int factor;
        public Category GetCategory () {
            return category;
        }

        public int GetFactor() {
            return factor;
        }
        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }
        protected override int calculatePoints(Check check)
        {
            int points = check.getCostByCategory(category);
            return (points * (factor - 1));
        }

        protected override bool checkCondition(Check check)
        {
            return check.getCostByCategory(category) != 0;
        }
    }
}