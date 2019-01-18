using Microsoft.EntityFrameworkCore;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
	}
}
