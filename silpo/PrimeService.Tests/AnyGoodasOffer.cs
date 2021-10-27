using System;
using System.Collections.Generic;

namespace PrimeService.Tests
{
    public class AnyGoodasOffer : Offer
    {
        public int totalCost;
        public int points;
        public AnyGoodasOffer(int totalcost, int points)
        {
            this.totalCost = totalCost;
            this.points = points;
        }
        protected override int calculatePoints(Check check)
        {
            return points;
        }

        protected override bool checkCondition(Check check)
        {
            return totalCost <= check.getTotalCost();
        }
    }
}