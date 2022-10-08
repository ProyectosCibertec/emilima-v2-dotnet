using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class UserPosition
    {
        public UserPosition()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int OrganicUnitId { get; set; }
        public int HierarchicalDependencyId { get; set; }

        public virtual HierarchicalDependency HierarchicalDependency { get; set; } = null!;
        public virtual OrganicUnit OrganicUnit { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
