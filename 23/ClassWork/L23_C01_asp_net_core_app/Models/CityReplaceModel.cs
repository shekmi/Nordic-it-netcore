using L23_C01_asp_net_core_app.Data;
using System.ComponentModel.DataAnnotations;

namespace L23_C01_asp_net_core_app.Models
{
	public class CityReplaceModel
	{
		[Required]
		[MinLength(2)]
		[MaxLength(100)]
		//[Display(Name = "City Name")] //для укращательств для веба, но не для API
		//обязательное поле
		//ограничено по длине 100 
		public string Name { get; set; }

		[MaxLength(300)]
		//ограничено по длине 300 
		public string Description { get; set; }

		public CityReplaceModel()
		{
		}

		public CityReplaceModel(CityDto city)
		{
			Name = city.Name;
			Description = city.Description;
		}
	}
}
