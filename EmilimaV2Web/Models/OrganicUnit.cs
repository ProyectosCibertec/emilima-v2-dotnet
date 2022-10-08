using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class OrganicUnit
    {
        public OrganicUnit()
        {
            DocumentRequests = new HashSet<DocumentRequest>();
            DocumentalSeries = new HashSet<DocumentalSerie>();
            UserPositions = new HashSet<UserPosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; }
        public virtual ICollection<DocumentalSerie> DocumentalSeries { get; set; }
        public virtual ICollection<UserPosition> UserPositions { get; set; }
    }
}
