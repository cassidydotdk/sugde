using System.Linq;
using Sitecore.Collections;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Website.RulesEngine
{
	public class MaxSectionsAllowed<T> : WhenCondition<T> where T : RuleContext
	{
		protected override bool Execute(T ruleContext)
		{
			return ruleContext.Item.GetChildren(ChildListOptions.IgnoreSecurity).Count(i => i.TemplateName.Equals("Section Page")) < 5;
		}
	}
}