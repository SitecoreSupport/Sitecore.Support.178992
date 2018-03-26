namespace Sitecore.Support.Buckets.Pipelines.UI.QuickActions
{
  using System.Collections.Generic;
  using Sitecore.Data.Items;
  using Sitecore.Buckets.Pipelines;
  internal class QuickActionArgs : BucketsPipelineArgs
  {
    internal QuickActionArgs(List<string> quickActions, Item innerItem)
    {
      this.QuickActions = quickActions;
      this.InnerItem = innerItem;
    }
    internal List<string> QuickActions { get; set; }

    /// <summary>Gets or sets the result.</summary>
    /// <value>The result.</value>
    internal Item InnerItem { get; set; }
  }
}
