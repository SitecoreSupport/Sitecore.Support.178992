namespace Sitecore.Support.Buckets.Pipelines.UI.QuickActions
{
  using System;
  using System.Collections.Generic;
  using Sitecore.Data.Items;
  using Sitecore.Buckets.Pipelines;
  [Obsolete]
  public class QuickActionArgs : BucketsPipelineArgs
  {
    public QuickActionArgs(List<string> quickActions, Item innerItem)
    {
      this.QuickActions = quickActions;
      this.InnerItem = innerItem;
    }
    public List<string> QuickActions { get; set; }

    /// <summary>Gets or sets the result.</summary>
    /// <value>The result.</value>
    public Item InnerItem { get; set; }
  }
}
