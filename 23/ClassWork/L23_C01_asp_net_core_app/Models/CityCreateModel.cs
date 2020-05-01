using L23_C01_asp_net_core_app.Data;
using L23_C01_asp_net_core_app.Validation;
using System.ComponentModel.DataAnnotations;

namespace L23_C01_asp_net_core_app.Models
{
	public class CityCreateModel
	{
		[Required]
		[MinLength(2)]
		[MaxLength(100)]
		//обязательное поле
		//ограничено по длине 100 
		public string Name { get; set; }

		[MaxLength(300)]
		[DifferentValue("Name")]
		//ограничено по длине 300 
		public string Description { get; set; }


		public CityCreateModel()
		{
		}

		public CityCreateModel(CityDto city)
		{
			Name = city.Name;
			Description = city.Description;
		}

		public CityDto ToDto(int id)
		{
			var dto = new CityDto
			{
				Id = id,
				Name = Name,
				Description = Description
			};

			return dto;
		}
	}
}
