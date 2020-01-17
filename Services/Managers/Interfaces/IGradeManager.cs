using Models;
using Services.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Managers.Interfaces
{
	public interface IGradeManager:IBaseManager<Grade>
	{
		bool SetGrade(SetGradeModel model);
		bool RemoveGrade(RemoveGradeModel model);
		bool EditGrade(EditGradeModel model);
	}
}
