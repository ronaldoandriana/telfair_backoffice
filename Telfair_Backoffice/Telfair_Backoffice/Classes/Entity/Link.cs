﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telfair_Backend.Classes.Entity
{
    public class Link
    {
        public string Id { get; set; }
        public string MyId { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public string MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public int Status { get; set; }
    }
}
