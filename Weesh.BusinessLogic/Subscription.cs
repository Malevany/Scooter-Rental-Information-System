using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Subscription
    {
        private double discountOnTrip;
        private double bonusPercentage;


        public double DiscountOnTrip { get { return discountOnTrip; } }
        public double BonusPercentage { get { return bonusPercentage; } }

        public Subscription(double discountOnTrip, double bonusPercentage)
        {
            this.discountOnTrip = discountOnTrip;
            this.bonusPercentage = bonusPercentage;
        }
    }
}
