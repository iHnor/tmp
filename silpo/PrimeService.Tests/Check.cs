using System;
using System.Collections.Generic;

namespace PrimeService.Tests
{
    public class Check
    {
        public List<Product> products;
        public int totalCost;
        private int points = 0;
        public Check()
        {
            this.products = new List<Product>();
        }
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

        public List<Product> getProducts()
        {
            return products;
        }

        public void addPoints(int points)
        {
            this.points += points;
        }

        public void addProduct(Product product)
        {
            products.Add(product);
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
        public int getCount() {
            return products.Count;
        }

        public int getCostByProduct(Product product) {
            int cost = 0;
            foreach (Product p in products)
            {
                if (product == p)
                {
                    cost += product.GetPrice();
                }
            }
            return cost;
        }
    }
}
