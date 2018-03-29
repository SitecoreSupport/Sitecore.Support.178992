namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  using System.Collections.Generic;
  using System;
  using Sitecore.Data.Items;
  using Sitecore.Buckets.Pipelines;
  using Sitecore.ContentSearch.Attributes;

  [Obsolete]
  public class DynamicFieldsArgs : BucketsPipelineArgs
  {
    public DynamicFieldsArgs(Dictionary<string, string> quickActions, Item innerItem)
    {
      this.QuickActions = quickActions;
      this.InnerItem = innerItem;
    }

    public Dictionary<string, string> QuickActions { get; set; }
    public Item InnerItem { get; set; }
  }
}
