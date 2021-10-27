using Xunit;
using System;

namespace PrimeService.Tests
{
    public class CheckoutServiceTest
    {
        private Product bred_3;
        private Product milk_7;
        private CheckoutService checkoutService;
        public CheckoutServiceTest()
        {
            CheckoutService checkoutService = new CheckoutService();
            checkoutService.openCheck();

            milk_7 = new Product(7, "Milk");
            bred_3 = new Product(3, "Bread");
        }


        [Fact]
        void closeCheck_withOneProduct()
        {
            checkoutService.addProduct(milk_7);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 7);
        }
        [Fact]
        void closeCheck_withTwoProduct()
        {
            checkoutService.addProduct(milk_7);
            checkoutService.addProduct(bred_3);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalCost(), 10);
        }
        [Fact]
        void addProduct__whenCheckIsClosed__opensNewCheck()
        {
            checkoutService.addProduct(milk_7);
            Check milkCheck = checkoutService.closeCheck();
            Assert.Equal(milkCheck.getTotalCost(), 7);

            checkoutService.addProduct(bred_3);
            Check breadCheck = checkoutService.closeCheck();
            Assert.Equal(breadCheck.getTotalCost(), 3);
        }

        [Fact]
        void closeCheck__calcTotalPoints()
        {
            checkoutService.addProduct(milk_7);
            checkoutService.addProduct(bred_3);
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 10);
        }

        [Fact]
        void useOffer__addOfferPoints()
        {
            checkoutService.addProduct(milk_7);
            checkoutService.addProduct(bred_3);

            checkoutService.useOffer(new AnyGoodasOffer(6, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 12);
        }
        [Fact]
        void useOffer__whenCostLessThanRequired__doNothing()
        {
            checkoutService.addProduct(bred_3);

            checkoutService.useOffer(new AnyGoodasOffer(6, 2));
            Check check = checkoutService.closeCheck();

            Assert.Equal(check.getTotalPoints(), 3);
        }
    }

}