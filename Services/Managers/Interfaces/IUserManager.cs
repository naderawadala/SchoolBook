using Models;
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

		bool EditUser(EditPersonModel model);
		bool DeleteUser(int id);
		List<User> GetAll();
	}
}
