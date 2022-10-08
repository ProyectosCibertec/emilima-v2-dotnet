using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class DocumentRequest
    {
        public DocumentRequest()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreationDate { get; set; }
        public int StateId { get; set; }
        public string UserId { get; set; } = null!;
        public int OrganicUnitId { get; set; }

        public virtual OrganicUnit OrganicUnit { get; set; } = null!;
        public virtual RequestState State { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Document> Documents { get; set; }
    }
}
