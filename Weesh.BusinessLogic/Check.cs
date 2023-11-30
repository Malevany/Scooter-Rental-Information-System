using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Check
    {
        private string check;
        public string CheckForPerson { get { return check; } }

        public void CreateCheck(string scooter, string TimeStart, double resultPrice)
        {
            check = string.Format("Номер вашего самоката: {0}. Обратитесь в пункт выдачи в {1} для его получения. " +
                "Итого к оплате: {2}. Всего доброго!",
                scooter, TimeStart, Math.Round(resultPrice, 0));
        }
    }
}
