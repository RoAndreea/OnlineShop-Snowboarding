using Microsoft.EntityFrameworkCore;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopSnowboardEquip.Data.Repositories
{
    public class EquipmentRepository : IEquipmentRepository

	{
		private readonly AppDbContext _appDbContext;

		public EquipmentRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public IEnumerable<Equipment> Equipments => _appDbContext.Equipments.Include(c => c.Category);

		public IEnumerable<Equipment> PreferredEquipments => _appDbContext.Equipments.Where(p => p.IsPreferredEquipment).Include(c => c.Category);

        public Equipment GetEquipmentById(int equipmentId) => _appDbContext.Equipments.FirstOrDefault(p => p.EquipmentId == equipmentId);

        public void CreateEquipment(Equipment equipment)
        {
            _appDbContext.Equipments.Add(equipment);
            _appDbContext.SaveChanges();
        }

        public void DeleteEquipment(int equipmentId)
        {
            Equipment equipment = _appDbContext.Equipments.Find(equipmentId);
            _appDbContext.Equipments.Remove(equipment);
            _appDbContext.SaveChanges(); 
        }

        public void EditEquipment(Equipment equipment)
        {
            _appDbContext.Equipments.Update(equipment);
            _appDbContext.SaveChanges();
        }
	}
}
