﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Domain.Entities
{
    public class Status
    {
        public Status()
        {
            Tickets = new HashSet<Ticket>();
        }

        public Guid ID { get; set; }

        public string Value { get; set; }
        public int Order { get; set; }
        public string AddedBy { get; set; }        
        public DateTime DateAdded { get; set; }

        public Guid TenantID { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
