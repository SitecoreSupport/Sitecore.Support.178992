namespace Sitecore.Support.Buckets.Pipelines.UI.QuickActions
{
  using System.Collections.Generic;
  using System;
  using Sitecore.Abstractions;
  using Sitecore.ContentSearch;
  using Sitecore.Diagnostics;

  [Obsolete]
  public class QuickActionPipeline
  {
    public static List<string> Run(QuickActionArgs args)
    {
      var pipeline = ContentSearchManager.Locator.GetInstance<ICorePipeline>();
      Assert.IsNotNull(pipeline, "pipeline != null");

      pipeline.Run(Names.PipelineNames.QuickActions, args);
      return args.QuickActions;
    }
    public static string FormatAction(string command, string title)
    {
      return string.Format("{0}|{1}", command, title);
    }
  }
}