using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CaruSell.az_Project
{
    [Serializable]
    internal class Model
    {
        static int countermodel = 0;
        public Model()
        {
            this.ModelId = ++countermodel;
        }
        static public void SetCounter(int counter)
        {
            Model.countermodel = counter;
        }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }
        public override string ToString()
        {
            return $"{ModelId}.{Name} (Marka id = {MarkaId}";
        }
    }
}
