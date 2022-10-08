using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class HierarchicalDependency
    {
        public HierarchicalDependency()
        {
            DocumentalSeries = new HashSet<DocumentalSerie>();
            UserPositions = new HashSet<UserPosition>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DocumentalSerie> DocumentalSeries { get; set; }
        public virtual ICollection<UserPosition> UserPositions { get; set; }
    }
}
