using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class User
    {
        private string login;
        private string password;
        private double bonusQuantity;
        private string typeOfSub = "None";
        private Subscription sub;

        public string Login { get { return login; } }
        public string Password { get { return password; } }
        public double BonusQuantity { get { return bonusQuantity; } }
        public string TypeOfSub { get { return typeOfSub; } }
        public Subscription Subscription { get { return sub; } }

        public User(string login, string password, double bonusQuantity)
        {
            this.login = login;
            this.password = password;
            this.bonusQuantity = bonusQuantity;
        }
        public void GetBonusForTrip(double bonus)
        {
            bonusQuantity += bonus;
        }
        public void SpentBonusForTrip(double spentedBonus)
        {
            bonusQuantity -= spentedBonus;
        }
        public void GetCard(Subscription sub, string typeOfSub)
        {
            this.sub = sub;
            this.typeOfSub = typeOfSub;
        }
    }
}
