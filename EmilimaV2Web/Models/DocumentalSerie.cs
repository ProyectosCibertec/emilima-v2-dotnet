using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class DocumentalSerie
    {
        public DocumentalSerie()
        {
            Documents = new HashSet<Document>();
        }

        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int HierarchicalDependencyId { get; set; }
        public int OrganicUnitId { get; set; }
        public string Definition { get; set; } = null!;
        public string ServiceFrequency { get; set; } = null!;
        public string NormativeScope { get; set; } = null!;
        public byte[]? IsPublic { get; set; }
        public string? PhisicalFeatures { get; set; }
        public string DocumentalSerieValue { get; set; } = null!;
        public int YearsInManagementArchive { get; set; }
        public int YearsInCentralArchive { get; set; }
        public DateTime ElaborationDate { get; set; }

        public virtual HierarchicalDependency HierarchicalDependency { get; set; } = null!;
        public virtual OrganicUnit OrganicUnit { get; set; } = null!;
        public virtual ICollection<Document> Documents { get; set; }
    }
}
