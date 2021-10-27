using Xunit;
using System;

namespace PrimeService.Tests
{
    public class CheckoutServiceTest
    {
        // private Product bred_3;
        // private Product milk_7;
        // private CheckoutService checkoutService;
        // public CheckoutServiceTest()
        // {
        //     CheckoutService checkoutService = new CheckoutService();
        //     checkoutService.openCheck();

        //     milk_7 = new Product(7, "Milk", Category.MILK);
        //     bred_3 = new Product(3, "Bread");
        // }


        [Fact]
        void closeCheck_withOneProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }
        [Fact]
        void closeCheck_withTwoProduct()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bread", Category.Bread));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 10);
        }

        [Fact]
        void addProduct__whenCheckIsClosed__opensNewCheck()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            Check milkCheck = checkoutService.closeCheck();
            Assert.Equal(milkCheck.getTotalCost(), 7);

            checkoutService.addProduct(new Product(3, "Bread", Category.Bread));
            Check breadCheck = checkoutService.closeCheck();
            Assert.Equal(breadCheck.getTotalCost(), 3);
        }

        [Fact]
        void closeCheck__calcTotalPoints()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bread", Category.Bread));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 10);
        }

        [Fact]
        void useOffer__addOfferPoints()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bread", Category.Bread));

            checkoutService.useOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 12);
        }
        [Fact]
        void useOffer__whenCostLessThanRequired__doNothing()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(3, "Bread", Category.Bread));
            checkoutService.useOffer(new AnyGoodsOffer(6, 2));
            Check check = checkoutService.closeCheck();
            Assert.Equal(check.getTotalPoints(), 3);
        }
        [Fact]
        void useOffer__factorByCategory()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(7, "Milk", Category.MILK));
            checkoutService.addProduct(new Product(3, "Bread", Category.Bread));


            checkoutService.useOffer(new FactorByCategoryOffer(Category.MILK, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 31);
        }

        [Fact]
        void expiration__check()
        {
            FactorByCategoryOffer checkDate = new FactorByCategoryOffer(Category.MILK, 2);

            Assert.Equal(checkDate.checkExpiration(), true);
        }
        [Fact]
        void endExpiration()
        {
            FactorByCategoryOffer checkDate = new FactorByCategoryOffer(Category.MILK, 2);
            checkDate.setExpirationDate(DateTime.Now.AddYears(-1));

            Assert.Equal(checkDate.checkExpiration(), false);
        }
    }



}