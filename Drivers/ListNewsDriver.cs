using ListNews.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement;
using Orchard.Data;
using System.Linq;
using ListNewsDetail.Services;
using ListNewsType.Services;
using System;

namespace ListNews.Drivers
{
    public class ListNewsDriver : ContentPartDriver<ListNewsPart>
    {
        private readonly IListNewsService _ListNewsService;
        private readonly IListNewsTypeService _ListNewsTypeService;
        public ListNewsDriver(IListNewsService ListNewsService,
            IListNewsTypeService ListNewsTypeService)
        {
            _ListNewsService = ListNewsService;
            _ListNewsTypeService = ListNewsTypeService;
        }
        protected override DriverResult Display(ListNewsPart part, string displayType, dynamic shapeHelper)
        {

            var ListNewsType = _ListNewsTypeService.GetAllNews().Where(t => t.ListNewsType != null).ToList();
            string[] _ListNewsType = new string[ListNewsType.Count()];
            for (int i = 0; i < ListNewsType.Count(); i++)
            {
                var OneNewsRecode = ListNewsType[i];
                _ListNewsType[i] = (OneNewsRecode.ListNewsType).ToString();
            }

            Array[] _NewsUrlListAll = new Array[ListNewsType.Count()];
            Array[] _NewsUrlTitletAll = new Array[ListNewsType.Count()];
            Array[] _NewsUrlDataAll = new Array[ListNewsType.Count()];
            int k = 0;
            foreach (var OneListNewsType in _ListNewsType)
            {
                var OneListNewsAll = _ListNewsService.GetAllNews().Where(t => t.NewsTypeof == OneListNewsType).OrderByDescending(t => t.Id).Take(8).ToList();
                string[] _NewsUrlList = new string[OneListNewsAll.Count()];
                string[] _NewsUrlTitlet = new string[OneListNewsAll.Count()];
                string[] _NewsUrlData = new string[OneListNewsAll.Count()];
                for (int i = 0; i < OneListNewsAll.Count(); i++)
                {
                    var OneNewsRecode = OneListNewsAll[i];
                    _NewsUrlList[i] = "/Contents/Item/Display/" + (OneNewsRecode.Id).ToString();
                    _NewsUrlTitlet[i] = (OneNewsRecode.NewsTitle).ToString();
                    _NewsUrlData[i] = (OneNewsRecode.NewsDate).ToString();
                }

                _NewsUrlListAll[k] = _NewsUrlList;
                _NewsUrlTitletAll[k] = _NewsUrlTitlet;
                _NewsUrlDataAll[k] = _NewsUrlData;
                k++;
            }


            return ContentShape("Parts_ListNews", () => shapeHelper.Parts_ListNews(
                    NewsUrlListAll: _NewsUrlListAll,
                    NewsUrlTitletAll: _NewsUrlTitletAll,
                    NewsUrlDataAll: _NewsUrlDataAll,
                    ListNewsType: _ListNewsType));
        }

        //GET
        protected override DriverResult Editor(ListNewsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_ListNews_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/ListNews",
                    Model: part,
                    Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(ListNewsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}
