using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.UserInterface
{
    public class Travel
    {   
        public static bool ConfirmTravel()
        {
            var key = ConsoleInput.InputConfirmOrder();
            
            while (true)
            {
                switch (key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }
                key = ConsoleInput.InputConfirmOrder();
            }
        }
        public static bool ConfirmBonusDebit()
        {
            var key = ConsoleInput.WriteOffBonuses();

            while (true)
            {
                switch (key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                        return false;
                }
                key = ConsoleInput.WriteOffBonuses();
            }
        }
    }
}
