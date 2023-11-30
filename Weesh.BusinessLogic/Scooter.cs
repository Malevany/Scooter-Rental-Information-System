using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weesh.BusinessLogic
{
    public class Scooter
    {
        private Equipment equipment;

        private string id;

        public string ID { get { return id; } }

        public Equipment Equipment { get { return equipment; } }

        public Scooter(string id, Equipment equipment)
        {
            this.id = id;
            this.equipment = equipment;
        }

    }
}
