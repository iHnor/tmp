using System;

namespace PrimeService.Tests
{
    public class ProductOffer: Offer
    {
        Product product;

        public ProductOffer(Product product) {
            this.product = product;
        }
        protected override int calculatePoints(Check check) {
            int points = check.getCostByProduct(product);
            return points;
        }

        protected override bool checkCondition(Check check)
        {
            return check.getCostByProduct(product) != 0;
        }
    }
}