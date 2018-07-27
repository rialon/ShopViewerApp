using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopViewer.WEB.Models {

    public class ProductViewModel {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter product description")]
        public string Description { get; set; }

        public int ShopId { get; set; }
    }
}