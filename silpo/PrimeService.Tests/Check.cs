using System;
using System.Collections.Generic;

namespace PrimeService.Tests
{
    public class Check
    {
        public List<Product> products;
        public int totalCost;
        public int getTotalCost()
        {
            int totalCost = 0; 
            foreach(Product product in this.products){
                totalCost +=product.price;
            }
            return totalCost;
        }
        public int getTotalPoints(){
            return getTotalCost();
        }
    }
}
