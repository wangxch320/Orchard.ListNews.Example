using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace ListNewsDetail.Models {
  public class ListNewsDetailRecord : ContentPartRecord {
    public virtual string NewsTitle { get; set;}
    public virtual string NewsTypeof { get; set; }
    public virtual string NewsDate { get; set;}
    public virtual string NewsAuthor { get; set;}
    public virtual string NewsOrigin { get; set;}
    public virtual string Newsdetaltext { get; set;}
    public virtual string NewsImg { get; set;}
    }

    public class ListNewsDetailPart : ContentPart<ListNewsDetailRecord>
    {
        [Required]
        public string NewsTitle
        {
            get { return Record.NewsTitle; }
            set { Record.NewsTitle = value; }
        }

        [Required]
        public string NewsTypeof
        {
            get { return Record.NewsTypeof; }
            set { Record.NewsTypeof = value; }
        }

        [Required]
        public string NewsDate
        {
            get { return Record.NewsDate; }
            set { Record.NewsDate = value; }
        }

        [Required]
        public string NewsAuthor
        {
            get { return Record.NewsAuthor; }
            set { Record.NewsAuthor = value; }
        }

        [Required]
        public string NewsOrigin
        {
            get { return Record.NewsOrigin; }
            set { Record.NewsOrigin = value; }
        }

        [Required]
        public string Newsdetaltext
        {
            get {
                    string HtmlFormat = "";
                    if (Record.Newsdetaltext != null)
                    {
                        HtmlFormat = Record.Newsdetaltext.Replace("<br />", "\n").Replace("&nbsp&nbsp", "\t");
                    }
                    else
                    {
                        HtmlFormat = Record.Newsdetaltext;
                    }
                    return HtmlFormat;
                }
            set {
                string HtmlFormat = value.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />").Replace("\t", "&nbsp&nbsp");
                Record.Newsdetaltext = HtmlFormat;
            }
        }

        [Required]
        public string NewsImg
        {
            get { return Record.NewsImg; }
            set { Record.NewsImg = value; }
        }
    }
}