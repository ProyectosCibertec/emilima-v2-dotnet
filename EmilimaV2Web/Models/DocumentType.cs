using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; }
    }
}
