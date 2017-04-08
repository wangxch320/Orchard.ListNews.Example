using Orchard.ContentManagement.Handlers;
using ListNewsDetail.Models;
using Orchard.Data;

namespace ListNewsDetail.Handlers {
  public class ListNewsDetailHandler : ContentHandler {
    public ListNewsDetailHandler(IRepository<ListNewsDetailRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            OnRemoved<ListNewsDetailPart>((context, part) => repository.Delete(part.Record));
        }
  }
}
