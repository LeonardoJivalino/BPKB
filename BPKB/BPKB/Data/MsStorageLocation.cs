﻿using System;
using System.Collections.Generic;

namespace BPKB.Data
{
    public partial class MsStorageLocation
    {
        public MsStorageLocation()
        {
            TrBpkbs = new HashSet<TrBpkb>();
        }

        public string LocationId { get; set; } = null!;
        public string? LocationName { get; set; }

        public virtual ICollection<TrBpkb> TrBpkbs { get; set; }
    }
}
