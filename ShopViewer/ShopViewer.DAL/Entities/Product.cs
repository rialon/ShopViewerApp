﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopViewer.DAL.Entities {

    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
