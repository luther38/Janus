﻿using System;
using System.Collections.Generic;

namespace Janus.Domain.Entities
{
    public class ComputerID
    {
        public Guid ID { get; set; }

        public string ComputerName { get; set; }
        public string Domain { get; set; }
        public string RAM { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string SkuNumber { get; set; }
        public string BiosManufacturer { get; set; }
        public string BiosName { get; set; }
        public string BiosVersion { get; set; }
        public string BiosStatus { get; set; }
        public string BiosSerialNumber { get; set; }
        public DateTime DateTimeUpdated { get; set; }
        public Guid TicketID { get; set; }
        public Guid HardDriveID { get; set; }
        public Guid NetworkID { get; set; }
        public Guid WindowsUpdatesID { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<HardDrives> HardDrives { get; set; }        
        public ICollection<Network> Network { get; set; }
        public ICollection<WindowsUpdates> WindowsUpdates { get; set; }

        public Guid TenantID { get; set; }
    }
}
