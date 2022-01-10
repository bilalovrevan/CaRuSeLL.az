using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaruSell.az_Project.Models
{
    [Serializable]
    internal class Cars
    {
        static int counter = 0;
        public Cars()
        {
            this.CarId = ++counter;
        }
        static public void SetCounter(int counter)
        {
            Cars.counter = counter;
        }
        public int CarId { get; set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public double Mator { get; set; }
        public string SuretlerQutusu { get; set; }
        public string Reng { get; set; }
        public double Qiymet { get; set; }
        public override string ToString()
        {
            return $"{CarId}: {Name}\n ---------ili -{Year}---------\n ---------VIN -{VIN}---------\n ---------Mator hecmi -{Mator}l---------\n ---------Suretler qutusu -{SuretlerQutusu}---------\n ---------Rengi -{Reng}---------\n ------------------{Qiymet} azn------------------";
        }

    }
}
