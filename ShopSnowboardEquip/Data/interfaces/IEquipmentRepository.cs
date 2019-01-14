using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.interfaces
{
	public interface IEquipmentRepository
	{
		IEnumerable<Equipment> Equipments { get;}
		IEnumerable<Equipment> PreferredEquipments { get;}
		Equipment GetEquipmentById(int equipmentId);
	}
}
