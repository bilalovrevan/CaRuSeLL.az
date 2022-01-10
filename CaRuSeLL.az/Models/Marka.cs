using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaruSell.az_Project
{
    [Serializable]
    internal class Marka
    {
        static int countermarka = 0;
        public Marka()
        {
            this.MarkaId = ++countermarka;
        }
        static public void SetCounter(int countermarka)
        {
            Marka.countermarka = countermarka;
        }
        public int MarkaId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{MarkaId}.{Name}";
        }
    }
}
