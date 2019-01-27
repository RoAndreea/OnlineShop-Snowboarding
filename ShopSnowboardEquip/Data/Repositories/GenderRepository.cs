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

        public void CreateGender(Gender gender)
        {
            _appDbContext.Genders.Add(gender);
            _appDbContext.SaveChanges();
        }

        public void DeleteGender(Gender gender)
        {
            _appDbContext.Genders.Remove(gender);
            _appDbContext.SaveChanges();
        }

        public void EditGender(Gender gender)
        {
            _appDbContext.Genders.Update(gender);
            _appDbContext.SaveChanges();
        }

        public Gender GetGenderById(int genderId) => _appDbContext.Genders.FirstOrDefault(p => p.GenderId == genderId);
    }
}
