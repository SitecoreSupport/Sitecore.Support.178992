namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  using System;
  using System.Collections.Generic;
  using Sitecore.Abstractions;
  using Sitecore.Buckets.Names;
  using Sitecore.ContentSearch;
  using Sitecore.Diagnostics;

  [Obsolete]
  public class DynamicFieldsPipeline
  {
    public static Dictionary<string, string> Run(DynamicFieldsArgs args)
    {
      var pipeline = ContentSearchManager.Locator.GetInstance<ICorePipeline>();
      Assert.IsNotNull(pipeline, "pipeline != null");

      pipeline.Run(PipelineNames.DynamicFields, args);

      return args.QuickActions;
    }
  }
}
