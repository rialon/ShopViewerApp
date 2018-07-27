using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopViewer.WEB.Models {

    public class ShopViewModel {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter shop name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter shop address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter shop start time")]
        [DataType(DataType.Time, ErrorMessage = "Please enter a valid start time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please enter shop end time")]
        [DataType(DataType.Time, ErrorMessage = "Please enter a valid end time")]
        public DateTime EndTime { get; set; }
    }
}