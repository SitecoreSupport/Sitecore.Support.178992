namespace Sitecore.Support.Buckets.Pipelines.UI.DynamicFields
{
  using System.Collections.Generic;
  using System.Linq;
  using System;
  using Sitecore.Diagnostics;

  [Obsolete]
  internal class IsLocked : DynamicFieldsProcessor
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
      safeDictionary.Add("IsLocked", args.InnerItem.Locking.IsLocked() ? "<span class=\"scLockIco\"><img src=\"-/icon/Network/32x32/lock.png?w=16&amp;h=16&amp;db=master\" class=\"scLockIco\" /></span>" : "<span class=\"scUnLockIco\"><img src=\"-/icon/Network/32x32/lock_open.png?w=16&amp;h=16&amp;db=master\" class=\"scUnLockIco\" /></span>");
      return safeDictionary;
    }
  }
}
