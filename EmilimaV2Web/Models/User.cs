using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class User
    {
        public User()
        {
            DocumentRequests = new HashSet<DocumentRequest>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }
        public string PhotoId { get; set; } = null!;
        public int PositionId { get; set; }

        public virtual File Photo { get; set; } = null!;
        public virtual UserPosition Position { get; set; } = null!;
        public virtual UserRole Role { get; set; } = null!;
        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; }
    }
}
