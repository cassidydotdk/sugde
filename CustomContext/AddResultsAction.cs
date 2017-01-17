using Sitecore.Rules.Actions;

namespace Website.CustomContext
{
	public class AddResultsAction<T> : RuleAction<T> where T : ResultsContext
	{
		public string AddResultId { get; set; }

		public override void Apply(T ruleContext)
		{
			if (string.IsNullOrEmpty(AddResultId))
				return;

			var resultItem = ruleContext.Item.Database.GetItem(AddResultId, ruleContext.Item.Language);
			if (resultItem == null || resultItem.Versions.Count == 0)
				return;

			ruleContext.SearchResults.Insert(0, resultItem);
		}
	}
}