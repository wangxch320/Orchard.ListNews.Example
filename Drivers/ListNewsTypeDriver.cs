using ListNewsType.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement;
using Orchard.Data;


namespace ListNewsType.Drivers {
  public class ListNewsTypeDriver : ContentPartDriver<ListNewsTypePart> {
    protected override DriverResult Display(ListNewsTypePart part, string displayType, dynamic shapeHelper)
    {
      return ContentShape("Parts_ListNewsType", () => shapeHelper.Parts_ListNewsType(
              ListNewsType: part.ListNewsType,
              ListNewsTypeName: part.ListNewsTypeName));
    }

    //GET
    protected override DriverResult Editor(ListNewsTypePart part, dynamic shapeHelper)
    {
      return ContentShape("Parts_ListNewsType_Edit",
          () => shapeHelper.EditorTemplate(
              TemplateName: "Parts/ListNewsType",
              Model: part,
              Prefix: Prefix));
    }
 
    //POST
    protected override DriverResult Editor(ListNewsTypePart part, IUpdateModel updater, dynamic shapeHelper)
    {
      updater.TryUpdateModel(part, Prefix, null, null);
      return Editor(part, shapeHelper);
    }
  }
}
