using System;
using CaruSell.az_Project.Models;

namespace CaruSell.az_Project
{
    [Serializable]
    internal class CarContext
    {
        public GenericStore<Marka> Markas { get; set; }
        public GenericStore<Model> Models { get; set; }
        public GenericStore<Cars> Cars { get; set; }
    }
}
