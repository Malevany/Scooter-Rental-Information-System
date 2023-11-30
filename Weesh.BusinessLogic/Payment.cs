using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Payment
    {
        private double resultPrice;
        private Dictionary<string, double> pricingPolicy;
        private double spentBonus;
        public double ResultPrice { get { return resultPrice; } }
        public double SpentBonus { get { return spentBonus; } }

        public Payment(Dictionary<string, double> pricingPolicy)
        {
            this.pricingPolicy = pricingPolicy;
        }

        public void CalculatePrice(UserRequest userRequest, User user)
        {
            resultPrice = pricingPolicy["PricePerHour"] * userRequest.Hours;
            if (IsScooterWithSeat(userRequest.ScooterType))
                resultPrice = resultPrice * pricingPolicy["SeatAllowance"];
            CalculateDiscount(user.Subscription);
            if (user.BonusQuantity <= resultPrice)
            {
                resultPrice -= user.BonusQuantity;
                spentBonus = user.BonusQuantity;
            }
            else
            {
                spentBonus = resultPrice;
                user.SpentBonusForTrip(spentBonus);
                resultPrice = 0;
            }
                
        }
        public void CalculatePrice(UserRequest userRequest)
        {
            resultPrice = pricingPolicy["PricePerHour"] * userRequest.Hours;
            if (IsScooterWithSeat(userRequest.ScooterType))
                resultPrice = resultPrice * pricingPolicy["SeatAllowance"]; 
        }
        public void CalculateDiscount(Subscription subscription)
        {
            resultPrice -= subscription.DiscountOnTrip;
        }
        public double CalculateBonusForTrip(Subscription sub)
        {
            return Math.Round(resultPrice * sub.BonusPercentage);
        }
        private bool IsScooterWithSeat(int typeOfScooter)
        {
            return typeOfScooter == 1;
        }
    }
}
