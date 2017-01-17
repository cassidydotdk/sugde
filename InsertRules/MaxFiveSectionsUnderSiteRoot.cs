using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Data.Masters;

namespace Website.InsertRules
{
	public class MaxFiveSectionsUnderSiteRoot : InsertRule
	{
		[UsedImplicitly]
		public MaxFiveSectionsUnderSiteRoot(Int32 whatsthis)
		{
			// This constructor is required, or Sitecore cannot instantiate your rule.
		}

		public override void Expand(List<Item> insertOptions, Item item)
		{
			if (item.TemplateName.Equals("Site Root"))
			{
				int count = item.GetChildren(ChildListOptions.IgnoreSecurity).Count(i => i.TemplateName.Equals("Section Page"));

				if (count < 5)
				{
					var sectionTemplateItem = item.Database.GetItem("/sitecore/templates/User Defined/Section Page");

					if (!insertOptions.Contains(sectionTemplateItem))
						insertOptions.Add(sectionTemplateItem);
				}
			}
		}
	}
}