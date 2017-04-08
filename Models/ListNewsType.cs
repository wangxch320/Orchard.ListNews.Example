using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace ListNewsType.Models {
  public class ListNewsTypeRecord : ContentPartRecord {
    public virtual string ListNewsType { get; set;}
    public virtual string ListNewsTypeName { get; set; }
  }

  public class ListNewsTypePart : ContentPart<ListNewsTypeRecord> {
        [Required]
        public string ListNewsType {
            get { return Record.ListNewsType; }
            set { Record.ListNewsType = value;}
        }
        [Required]
        public string ListNewsTypeName
        {
            get { return Record.ListNewsTypeName; }
            set { Record.ListNewsTypeName = value; }
        }
    }
}