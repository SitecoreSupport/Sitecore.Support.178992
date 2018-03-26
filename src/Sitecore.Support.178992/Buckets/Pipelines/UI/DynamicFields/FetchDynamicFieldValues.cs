namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  using System.Collections.Generic;
  using System.Linq;

  internal class FetchDynamicFieldValues : DynamicFieldsProcessor
  {
    public override void Process(DynamicFieldsArgs args)
    {
      if (args == null)
      {
        return;
      }

      var collection = args.QuickActions.Concat(GetQuickActions(args)).ToDictionary(x => x.Key, x => x.Value);
      args.QuickActions = collection;
    }

    protected virtual Dictionary<string, string> GetQuickActions(DynamicFieldsArgs args)
    {
      var safeDictionary = new Dictionary<string, string>();
      safeDictionary.Add("DisplayName", args.InnerItem.DisplayName);
      return safeDictionary;
    }
  }
}