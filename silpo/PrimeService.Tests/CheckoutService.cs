using System;
using System.Collections.Generic;

namespace PrimeService.Tests
{

    public class CheckoutService
    {
        private Check check;
        public void openCheck()
        {
            check = new Check();
            check.totalCost = 0;
            check.products = new List<Product>();
        }
        public void addProduct(Product product)
        {
            check.products.Add(product);
        }
        public Check closeCheck()
        {
            foreach (Product product in check.products)
            {
                check.totalCost += product.price;
            }
            return check;
        }
        public void useOffer(AnyGoodasOffer offer)
        {
            if (offer.totalCost <= check.getTotalCost())
                check.addPoints(offer.points);
        }
    }
}
