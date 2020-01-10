using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.CustomModels.MapperSettings
{
	public class MapperConfigurator
	{
		private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{

				cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
				cfg.AddProfile<MappingProfile>();
			});
			var mapper = config.CreateMapper();
			return mapper;
		});

		public static IMapper Mapper => Lazy.Value;

		public class MappingProfile : Profile
		{
			public MappingProfile()
			{

			}
		}
	}
}
