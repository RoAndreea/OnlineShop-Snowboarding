using ShopSnowboardEquip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.interfaces
{
	public interface IGenderRepository
	{
		IEnumerable<Gender> Genders { get;}
        Gender GetGenderById(int genderId);
        void CreateGender(Gender gender);
        void DeleteGender(Gender gender);
        void EditGender(Gender gender);
    }
}
