﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Managers.Interfaces
{
	public interface IParentManager: IBaseManager<Parent>
	{
		List<Grade> GetChildGrades(int parentID);
	
	}
}
