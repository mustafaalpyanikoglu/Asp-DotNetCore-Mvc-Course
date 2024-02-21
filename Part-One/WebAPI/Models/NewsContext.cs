using System.Collections.Generic;

namespace WebAPI.Models
{
	public static class NewsContext
	{
		public static List<News> List = new List<News>()
		{
			new News() {Title = "Haber 1"},
			new News() {Title = "Haber 2"}
		};
	}
}
