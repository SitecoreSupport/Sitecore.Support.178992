namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  using System.Collections.Generic;
  using System;
  using Sitecore.Data.Items;
  using Sitecore.Buckets.Pipelines;
  using Sitecore.ContentSearch.Attributes;

  internal class DynamicFieldsArgs : BucketsPipelineArgs
  {
    internal DynamicFieldsArgs(Dictionary<string, string> quickActions, Item innerItem)
    {
      this.QuickActions = quickActions;
      this.InnerItem = innerItem;
    }

    internal Dictionary<string, string> QuickActions { get; set; }
    internal Item InnerItem { get; set; }
  }
}
