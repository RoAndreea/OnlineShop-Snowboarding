using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.Repositories
{
	public class GenderRepository: IGenderRepository
	{
		private readonly AppDbContext _appDbContext;
		public GenderRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public IEnumerable<Gender> Genders => _appDbContext.Genders;
	}
}
