using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Sitecore.Rules;

namespace Website.CustomContext
{
	public class ResultsController : Controller
	{
		public ActionResult ShowResults()
		{
			var sc = new ResultsContext
			{
				SearchQuery = HttpContext.Request["q"],
				Item = Sitecore.Context.Item
			};

			if (string.IsNullOrEmpty(sc.SearchQuery))
				return new EmptyResult();

			// Setup
			sc.SearchQuery = sc.SearchQuery.ToLowerInvariant();

			// Do the "search" (ahem....)
			var root = RenderingContext.Current.ContextItem.Database.GetItem("/sitecore");
			sc.SearchResults = new List<Item>(root.Axes.GetDescendants().ToList().FindAll(d => d.Name.ToLowerInvariant().Contains(sc.SearchQuery)));

			// Fire up the Rules Engine
			var ruleContainer = RenderingContext.Current.ContextItem.Database.GetItem("/sitecore/system/Settings/Rules/Custom Search");
			var ruleList = RuleFactory.GetRules<ResultsContext>(ruleContainer, "Rule");
			ruleList.Run(sc);

			// Display
			return PartialView("~/Views/Results.cshtml", sc.SearchResults);
		}
	}
}