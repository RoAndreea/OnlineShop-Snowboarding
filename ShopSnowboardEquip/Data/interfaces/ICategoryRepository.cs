using ShopSnowboardEquip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.interfaces
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get;  }
	}
}
