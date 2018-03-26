using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Abstractions;
using Sitecore.Buckets.Names;
using Sitecore.Collections;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Attributes;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  internal class DynamicFieldsPipeline
  {
    internal static Dictionary<string, string> Run(DynamicFieldsArgs args)
    {
      var pipeline = ContentSearchManager.Locator.GetInstance<ICorePipeline>();
      Assert.IsNotNull(pipeline, "pipeline != null");

      pipeline.Run(PipelineNames.DynamicFields, args);

      return args.QuickActions;
    }
  }
}
