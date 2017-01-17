using System.Linq;
using Sitecore.Collections;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Website.RulesEngine
{
	public class VariableTemplatesAllowed<T> : IntegerComparisonCondition<T> where T : RuleContext
	{
		public string TemplateId { get; set; }

		protected override bool Execute(T ruleContext)
		{
			return Compare(ruleContext.Item.GetChildren(ChildListOptions.IgnoreSecurity).Count(i => i.TemplateID.ToString().Equals(TemplateId)));
		}
	}
}