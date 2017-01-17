using Sitecore.Rules.Conditions;

namespace Website.CustomContext
{
	public class ResultContainsCondition<T> : StringOperatorCondition<T> where T : ResultsContext
	{
		public string Value { get; set; }

		protected override bool Execute(T ruleContext)
		{
			return Compare(Value.ToLowerInvariant(), ruleContext.SearchQuery);
		}
	}
}