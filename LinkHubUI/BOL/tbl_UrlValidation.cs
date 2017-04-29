using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    class tbl_UrlValidation//ako želiš da ti url bude unique, naprvi po videu 5.17.
    {
        [Required]
        public string UrlTitle { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string UrlDesc { get; set; }

    }
}
