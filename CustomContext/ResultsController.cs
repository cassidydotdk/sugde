using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;

namespace Website.CustomContext
{
	public class ResultsController : Controller
	{
		public ActionResult ShowResults()
		{
			var sc = new ResultsContext {SearchQuery = HttpContext.Request["q"]};

			if (string.IsNullOrEmpty(sc.SearchQuery))
				return new EmptyResult();

			sc.SearchQuery = sc.SearchQuery.ToLowerInvariant();

			var root = RenderingContext.Current.ContextItem.Database.GetItem("/sitecore");
			sc.SearchResults = new List<Item>(root.Axes.GetDescendants().ToList().FindAll(d => d.Name.ToLowerInvariant().Contains(sc.SearchQuery)));

			return PartialView("~/Views/Results.cshtml", sc.SearchResults);
		}
	}
}