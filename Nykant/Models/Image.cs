﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nykant.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
