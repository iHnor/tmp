using System;
using System.Collections.Generic;

namespace PrimeService.Tests
{

    public class CheckoutService
    {
        private Check check;
        private List<Offer> offers;

        public CheckoutService()
        {
            offers = new List<Offer>();
        }

        public void openCheck()
        {
            check = new Check();
            /* check.totalCost = 0;
            check.products = new List<Product>(); */
        }
        public void addProduct(Product product)
        {
            if(check == null)
                openCheck();
            check.products.Add(product);
        }
        public Check closeCheck()
        {
            Check closedCheck = check;
            foreach(Offer offer in offers) {
                offer.apply(check);
            }
            check = null;
            return closedCheck;
            /* foreach (Product product in check.products)
            {
                check.totalCost += product.price;
            }
            return check; */
        }
        public void useOffer(Offer offer)
        {
            offer.apply(check);
            /* if (typeof(offer).IsInstanceOfType(FactorByCategoryOffer))
            {
                FactorByCategoryOffer fbOffer = (FactorByCategoryOffer)offer;
                int points = check.getCostByCategory(fbOffer.categoryl);
                check.addPoints(points * (fbOffer.factor - 1));
            }
            else
            {
                if (typeof(offer).IsInstanceOfType(AnyGoodasOffer))
                {
                    AnyGoodasOffer agOffer = (AnyGoodasOffer)offer;
                    if (agOffer.totalCost <= check.getTotalCost())
                        check.addPoints(agOffer.points);
                }

            } */
        }
    }
}
