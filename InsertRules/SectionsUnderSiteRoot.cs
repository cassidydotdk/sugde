using System;
using System.Collections.Generic;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Data.Masters;

namespace Website.InsertRules
{
	public class SectionsUnderSiteRoot : InsertRule
	{
		[UsedImplicitly]
		public SectionsUnderSiteRoot(Int32 whatsthis)
		{
			// This constructor is required, or Sitecore cannot instantiate your rule.
		}

		public override void Expand(List<Item> insertOptions, Item item)
		{
			if (item.TemplateName.Equals("Site Root"))
			{
				var sectionTemplateItem = item.Database.GetItem("/sitecore/templates/User Defined/Section Page");
				if (!insertOptions.Contains(sectionTemplateItem))
					insertOptions.Add(sectionTemplateItem);
			}
		}
	}
}