using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weesh.BusinessLogic;

namespace Weesh.UserInterface
{
    public class Polling
    {
        private string timeStart;
        private int hours;
        private int age;
        private int scooterType;

        public string TimeStart { get { return timeStart; } }
        public int Hours { get { return hours; } }
        public int Age { get { return age; } }
        public int ScooterType { get { return scooterType; } }

        public UserRequest CreateRequest()
        {
            timeStart = EnterTime();
            while(true)
            {
                hours = EnterDuration();
                if (!Hire.IsCorrectDuration(hours))
                    ConsoleInput.MaxDurationError();
                else
                    break;
            }
            while (true)
            {
                age = EnterAge();
                if (!Hire.IsCorrectAgeRange(age))
                    ConsoleInput.MinAgeError();
                else
                    break;
            }
            scooterType = SelectTypeOfScooter();
            return new UserRequest(timeStart, hours, age, scooterType);
        }

        public string[] GetLoginPassword()
        {
            string login = ConsoleInput.InputLogin();
            string password = ConsoleInput.InputPassword();
            return new string[] {login, password};
        }

        private string EnterTime()
        {
            string time;
            TimeOnly temp;

            while (true)
            {
               time = ConsoleInput.InputTimeStart();
                if (TimeOnly.TryParse(time, out temp))
                {
                    return temp.ToString();
                }
                else
                {
                    ConsoleInput.TimeStartError();
                }
            }
        }

        private int EnterDuration()
        {
            while (true)
            {

                string time = ConsoleInput.InputDuration();
                if (int.TryParse(time, out int Hours))
                {
                    return Hours;
                }
                else
                    ConsoleInput.DurationError();
            }
        }

        private int EnterAge()
        {
            int age = 0;
            while (true)
            {
                var ageString = ConsoleInput.InputAge();
                if (int.TryParse(ageString, out age))
                {
                    return age;
                }
                else
                    ConsoleInput.AgeError();
            }
        }

        private int SelectTypeOfScooter()
        {

            var key = ConsoleInput.InputSelectTypeOfScooter();
            while (true)
            {
                switch (key)
                {
                    case ConsoleKey.D1:
                        return 1;
                    case ConsoleKey.D2:
                        return 2;
                }
                key = ConsoleInput.InputSelectTypeOfScooter();
            }
        }
    }
}
