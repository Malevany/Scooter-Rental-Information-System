using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Equipment
    {
        private string batteryCapacity;
        private string ageTypeOfScooter;
        private string seat;

        public string BatteryCapacity { get { return batteryCapacity; } }

        public string AgeTypeOfScooter { get { return ageTypeOfScooter; } }

        public string Seat { get { return seat; } }

        public Equipment(string batteryCapacity, string typeOfScooter, string seat)
        {
            this.batteryCapacity = batteryCapacity;
            this.ageTypeOfScooter = typeOfScooter;
            this.seat = seat;
        }
    }
}
