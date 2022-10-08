using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class File
    {
        public File()
        {
            Documents = new HashSet<Document>();
            User1s = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string Filename { get; set; } = null!;

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<User> User1s { get; set; }
    }
}
