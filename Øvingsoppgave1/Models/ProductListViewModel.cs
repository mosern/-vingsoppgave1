﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Øvingsoppgave1.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}