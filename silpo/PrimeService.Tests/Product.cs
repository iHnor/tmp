using System;

namespace PrimeService.Tests
{
    public class Product
    {
        public int price;
        public string name;
        public Category category;
        public int GetPrice()
        {
            return price;
        }

        public Category getCategory()
        {
            return category;
        }
        public Product(int price, string name, Category category)
        {
            this.price = price;
            this.name = name;
            this.category = category;
        }
        public Product(int price, string name)
        {
            this.price =price;
            this.name = name;
        }
    }
}
