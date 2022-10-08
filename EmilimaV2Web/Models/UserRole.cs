using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            User1s = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<User> User1s { get; set; }
    }
}
