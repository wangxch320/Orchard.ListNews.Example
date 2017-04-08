using Orchard.ContentManagement.Handlers;
using ListNews.Models;
using Orchard.Data;

namespace ListNews.Handlers {
  public class ListNewsHandler : ContentHandler {
    public ListNewsHandler(IRepository<ListNewsRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            OnRemoved<ListNewsPart>((context, part) => repository.Delete(part.Record));
        }
  }
}
