using Orchard.ContentManagement.Handlers;
using ListNewsType.Models;
using Orchard.Data;

namespace ListNewsType.Handlers {
  public class ListNewsTypeHandler : ContentHandler {
    public ListNewsTypeHandler(IRepository<ListNewsTypeRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            OnRemoved<ListNewsTypePart>((context, part) => repository.Delete(part.Record));
        }
  }
}
