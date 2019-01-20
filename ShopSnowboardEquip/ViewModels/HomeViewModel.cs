using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Equipment> PreferredEquipments { get; set; }
    }
}
