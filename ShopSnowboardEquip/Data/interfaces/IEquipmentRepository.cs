using ShopSnowboardEquip.Models;
using System.Collections.Generic;

namespace ShopSnowboardEquip.Data.interfaces
{
    public interface IEquipmentRepository
	{
		IEnumerable<Equipment> Equipments { get;}
		IEnumerable<Equipment> PreferredEquipments { get;}
		Equipment GetEquipmentById(int equipmentId);
        void CreateEquipment (Equipment equipment);
        void DeleteEquipment(int equipmentId);
        void EditEquipment(Equipment equipment);
	}
}
