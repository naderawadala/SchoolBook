using Services.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
	public interface IIdentityManager
	{
		string LoginUser(LoginModel model);

		string Register(RegisterModel model);

		string EditUser(PersonModel model);
		string DeleteUser(int id);
	}
}
