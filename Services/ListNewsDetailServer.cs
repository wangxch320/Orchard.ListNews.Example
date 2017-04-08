using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using ListNewsDetail.Models;

namespace ListNewsDetail.Services {
    //所有需要自动注入到Autofac容器的端口都需要继承IDependency
    public interface IListNewsService : IDependency {

        IEnumerable<ListNewsDetailRecord> GetAllNews();

        //IEnumerable<WangxchNews2Record> Where(Func<WangxchNews2Record, bool> predicate);
    }

    public class ListNewsService : IListNewsService {
        private readonly IContentManager _contentManager;
        private readonly IRepository<ListNewsDetailRecord> _stateRepository;

        public ListNewsService(IRepository<ListNewsDetailRecord> stateRepository
            , IContentManager contentManager) {
            _stateRepository = stateRepository;
            _contentManager = contentManager;
        }

        public IEnumerable<ListNewsDetailRecord> GetAllNews()
        {
            return _stateRepository.Table.ToList();
        }
    }
}