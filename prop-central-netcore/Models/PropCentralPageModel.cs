using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace prop_central_netcore.Models
{
	public class PropCentralPageModel : PageModel
	{

		public string GetUserName()
		{
			if (User.Identity.IsAuthenticated) return User.Claims.Where(x => x.Type == "name").FirstOrDefault().Value;
			else return "";
		}
	}
}

