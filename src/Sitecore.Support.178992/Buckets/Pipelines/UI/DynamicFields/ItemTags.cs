namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Data.Fields;
  using Sitecore.Diagnostics;

  internal class ItemTags : DynamicFieldsProcessor
  {
    public override void Process(DynamicFieldsArgs args)
    {
      Assert.ArgumentNotNull(args, "args");

      var collection = args.QuickActions.Concat(IsLockedCheck(args)).ToDictionary(x => x.Key, x => x.Value);
      args.QuickActions = collection;
    }

    private Dictionary<string, string> IsLockedCheck(DynamicFieldsArgs args)
    {
      var safeDictionary = new Dictionary<string, string>();
      var itemTags = args.InnerItem.Fields[Sitecore.Buckets.Util.Constants.SemanticsField];

      if (itemTags != null)
      {
        var tags = ((MultilistField)itemTags).GetItems().Select(item => item.Name);
        var tagString = tags.Aggregate(string.Empty, (current, tag) => current + tag + "-");
        safeDictionary.Add("Tags", tagString);
      }

      return safeDictionary;
    }
  }
}