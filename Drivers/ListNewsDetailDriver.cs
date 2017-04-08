using ListNewsDetail.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement;
using Orchard.Data;
using ListNewsDetail.Services;
using System.Linq;
using ListNewsType.Services;
using ListNews.ViewModel;

namespace ListNewsDetail.Drivers {
    public class ListNewsDetailDriver : ContentPartDriver<ListNewsDetailPart> {
        private readonly IListNewsService _ListNewsService;
        private readonly IListNewsTypeService _ListNewsTypeService;
        public ListNewsDetailDriver(IListNewsService ListNewsService,
            IListNewsTypeService ListNewsTypeService)
        {
            _ListNewsService = ListNewsService;
            _ListNewsTypeService = ListNewsTypeService;
        }
        protected override DriverResult Display(ListNewsDetailPart part, string displayType, dynamic shapeHelper)
        {
          string NewsdetaltextareaHtml = part.Newsdetaltext;
          NewsdetaltextareaHtml = NewsdetaltextareaHtml.Replace("\t", "&nbsp&nbsp");

          string NewsdetaltextareaHtmlp = "";
          string[] textareaHtmlList = NewsdetaltextareaHtml.Split('\n');
          foreach (string OnetextareaHtml in textareaHtmlList)
          {
              NewsdetaltextareaHtmlp = NewsdetaltextareaHtmlp + "<p>" + OnetextareaHtml + "</p>";

          }

          var prevNewsRecode = _ListNewsService.GetAllNews().Where(t => t.Id < part.Id).OrderBy(p => p.Id).LastOrDefault();
          var nextNewsRecode = _ListNewsService.GetAllNews().Where(t => t.Id > part.Id).OrderBy(p => p.Id).FirstOrDefault();

          var ListNewsType = _ListNewsTypeService.GetAllNews().Where(t => t.ListNewsType != null).ToList();
          string[] _ListNewsType = new string[ListNewsType.Count()];
          for(int i = 0; i < ListNewsType.Count(); i++)
                {
                    var OneNewsRecode = ListNewsType[i];
                    _ListNewsType[i] = (OneNewsRecode.ListNewsType).ToString();
                }

          return ContentShape("Parts_ListNewsDetail", () => shapeHelper.Parts_ListNewsDetail(
                  NewsTitle: part.NewsTitle,
                  NewsTypeof: part.NewsTypeof,
                  NewsDate: part.NewsDate,
                  NewsAuthor: part.NewsAuthor,
                  NewsOrigin: part.NewsOrigin,
                  Newsdetaltext: NewsdetaltextareaHtmlp,
                  NewsImg: part.NewsImg,
                  prevNewsRecode: prevNewsRecode,
                  nextNewsRecode: nextNewsRecode,
                  ListNewsType: _ListNewsType));
        }

        //GET
        protected override DriverResult Editor(ListNewsDetailPart part, dynamic shapeHelper)
        {
          return ContentShape("Parts_ListNewsDetail_Edit",
              () => shapeHelper.EditorTemplate(
                  TemplateName: "Parts/ListNewsDetail",
                  Model: BuildEditorViewModel(part),
                  Prefix: Prefix));
        }
 
        //POST
        protected override DriverResult Editor(ListNewsDetailPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            var model = new EditListNewsDetailViewModel();
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        private EditListNewsDetailViewModel BuildEditorViewModel(ListNewsDetailPart part)
        {
            var ListNewsType = _ListNewsTypeService.GetAllNews().Where(t => t.ListNewsType != null).ToList();

            var avm = new EditListNewsDetailViewModel
            {
                NewsTitle = part.NewsTitle,
                NewsTypeof = part.NewsTypeof,
                NewsDate = part.NewsDate,
                NewsAuthor = part.NewsAuthor,
                NewsOrigin = part.NewsOrigin,
                Newsdetaltext = part.Newsdetaltext,
                NewsImg = part.NewsImg,
                ListNewsType = ListNewsType
            };
            return avm;
        }
    }
}
