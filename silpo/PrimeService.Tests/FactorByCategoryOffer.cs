using System;

namespace PrimeService.Tests
{
    public class FactorByCategoryOffer: Offer{
        public Category category;
        public int factor;
        public FactorByCategoryOffer(Category category, int factor)
        {
            this.category = category;
            this.factor = factor;
        }
    }
}