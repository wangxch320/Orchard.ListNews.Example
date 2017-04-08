using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using ListNewsType.Models;

namespace ListNewsType.Services {
    //所有需要自动注入到Autofac容器的端口都需要继承IDependency
    public interface IListNewsTypeService : IDependency {
        IEnumerable<ListNewsTypeRecord> GetAllNews();

    }

    public class ListNewsTypeService : IListNewsTypeService {
        private readonly IContentManager _contentManager;
        private readonly IRepository<ListNewsTypeRecord> _stateRepository;

        public ListNewsTypeService(IRepository<ListNewsTypeRecord> stateRepository
            , IContentManager contentManager) {
            _stateRepository = stateRepository;
            _contentManager = contentManager;
        }

        public IEnumerable<ListNewsTypeRecord> GetAllNews()
        {
            return _stateRepository.Table.ToList();
        }
    }
}