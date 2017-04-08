using System.Collections.Generic;
using SimpleCommerce.Models;

namespace SimpleCommerce.ViewModels {
    public class EditAddressViewModel {
        public string NewsDesc { get; set; }
        public string NewsDate { get; set; }
        public string NewsAuthor { get; set; }
        public string NewsOrigin { get; set; }
        public string Newsdetaltext { get; set; }
        public IEnumerable<WangxchNewsRecord> States { get; set; }
    }
}