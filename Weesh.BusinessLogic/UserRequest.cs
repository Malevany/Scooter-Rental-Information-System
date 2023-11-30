using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class UserRequest
    {
        private string timeStart;
        private int hours;
        private int age;
        private int scooterType;

        public string TimeStart { get { return timeStart; } }
        public int Hours { get { return hours; } }
        public int Age { get { return age; } }
        public int ScooterType { get { return scooterType; } }

        public UserRequest(string timeStart, int hours, int age, int scooterType)
        {
            this.timeStart = timeStart;
            this.hours = hours;
            this.age = age;
            this.scooterType = scooterType;
        }
    }
}
