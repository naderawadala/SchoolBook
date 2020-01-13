using Services.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Managers.Interfaces
{
	public interface IUserManager
	{
		string LoginUser(LoginModel model);

		string Register(RegisterModel model);

		string EditUser(EditPersonModel model);
		string DeleteUser(int id);
	}
}
