using Microsoft.AspNetCore.Identity;

namespace ShopSnowboardEquip
{
	internal class ApplicationUser : IdentityUser
	{
		public string UserName { get; internal set; }
		public string Email { get; internal set; }
	}
}