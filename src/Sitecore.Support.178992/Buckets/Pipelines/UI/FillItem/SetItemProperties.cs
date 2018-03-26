using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sitecore.Buckets.Pipelines.UI.FillItem;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Shell.Framework;
using Sitecore.Support.Buckets.Pipelines.UI.DynamicFields;
using Sitecore.Support.Buckets.Pipelines.UI.QuickActions;

namespace Sitecore.Support.Buckets.Pipelines.UI.FillItem
{
  public class SetItemProperties : Sitecore.Buckets.Pipelines.UI.FillItem.SetItemProperties
  {

    private static readonly MethodInfo GetValueMethodInfo =
      typeof(Sitecore.Buckets.Pipelines.UI.FillItem.SetItemProperties).GetMethod("GetValue", BindingFlags.Instance | BindingFlags.NonPublic);

    protected override void GetQuickActions(FillItemArgs args)
    {
      if (GetValueMethodInfo == null)
      {
        base.GetQuickActions(args);
        return;
      }
      var enumerableCollextion = args.ResultItems;
      Language contentLanguage = null;
      if (args.ContentLanguage != null)
      {
        Language.TryParse(args.ContentLanguage, out contentLanguage);
      }

      foreach (var sitecoreItem in enumerableCollextion.OfType<SitecoreUISearchResultItem>())
      {
        Language parsedLanguage;
        Language.TryParse(sitecoreItem.Language, out parsedLanguage);
        var innerItem = Context.ContentDatabase.GetItem(sitecoreItem.ItemId, parsedLanguage, Sitecore.Data.Version.Parse(sitecoreItem.Version));
        if (innerItem != null)
        {
          this.ExtendedGetValue(innerItem, sitecoreItem, contentLanguage);
        }
        else
        {
          var coreItem = Context.Database.GetItem(sitecoreItem.ItemId, parsedLanguage, Sitecore.Data.Version.Parse(sitecoreItem.Version));
          if (coreItem != null)
          {
            this.ExtendedGetValue(coreItem, sitecoreItem, contentLanguage);
          }
        }
      }

      args.ResultItems = enumerableCollextion;
    }

    protected void ExtendedGetValue(Item innerItem, SitecoreUISearchResultItem sitecoreItem, Language contentLanguage)
    {
      GetValueMethodInfo.Invoke(this, new object[] {innerItem, sitecoreItem, contentLanguage});
      var dynamicFields = this.GetDynamicFields(innerItem);

      if (sitecoreItem.DynamicFields == null)
        sitecoreItem.DynamicFields = new List<KeyValuePair<string, string>>();

      foreach (var dynamicField in dynamicFields)
      {
        sitecoreItem.DynamicFields.Add(new KeyValuePair<string, string>(dynamicField.Key, dynamicField.Value));
      }

      var dyncamiQuickActionList = new List<string>();
      sitecoreItem.DynamicQuickActions = this.GetDynamicQuickActions(dyncamiQuickActionList, innerItem).ToList();
    }

    internal Dictionary<string, string> GetDynamicFields(Item innerItem)
    {
      var safeDiction = new Dictionary<string, string>();
      return DynamicFieldsPipeline.Run(new DynamicFieldsArgs(safeDiction, innerItem));
    }

    internal IEnumerable<string> GetDynamicQuickActions(List<string> quickActions, Item innerItem)
    {
      return QuickActionPipeline.Run(new QuickActionArgs(quickActions, innerItem));
    }
  }
}