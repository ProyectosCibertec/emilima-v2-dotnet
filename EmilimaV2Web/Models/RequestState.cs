using System;
using System.Collections.Generic;

namespace EmilimaV2Web.Models
{
    public partial class RequestState
    {
        public RequestState()
        {
            DocumentRequests = new HashSet<DocumentRequest>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; }
    }
}
