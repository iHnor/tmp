using System;
using System.Collections.Generic;

namespace PrimeService.Tests
{
    public class Check
    {
        public List<Product> products;
        public int totalCost;
        private int points = 0;
        public int getTotalCost()
        {
            int totalCost = 0;
            foreach (Product product in this.products)
            {
                totalCost += product.price;
            }
            return totalCost;
        }
        public int getTotalPoints()
        {
            return getTotalCost() + points;
        }
        public void addPoints(int points)
        {
            this.points += points;
        }
        public int getCostByCategory(Category category)
        {
            int output = 0;
            foreach (Product product in products)
            {
                if (product.getCategory() == category)
                {
                    output += product.GetPrice();
                }
            }
            return output;
        }
    }
}
