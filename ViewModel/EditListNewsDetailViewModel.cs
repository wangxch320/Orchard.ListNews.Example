using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ListNewsDetail.Models;
using ListNewsType.Models;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace ListNews.ViewModel
{
    public class EditListNewsDetailViewModel
    {
        public string NewsTitle { get; set; }
        public string NewsTypeof { get; set; }
        public string NewsDate { get; set; }
        public string NewsAuthor { get; set; }
        public string NewsOrigin { get; set; }
        public string Newsdetaltext { get; set; }
        public string NewsImg { get; set; }
        public IEnumerable<ListNewsTypeRecord> ListNewsType { get; set; }
    }
}