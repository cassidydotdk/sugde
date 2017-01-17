using System.Collections.Generic;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Rules;

namespace Website.CustomContext
{
	public class ResultsContext : RuleContext
	{
		public string SearchQuery { get; set; }

		public List<Item> SearchResults { get; set; }

		public ResultsContext()
		{
			SearchResults = new List<Item>();
		}
	}
}