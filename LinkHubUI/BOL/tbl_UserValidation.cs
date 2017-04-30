using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    class tbl_UserValidation//Odradi isto ono za unique Email. 5.19. da se ne dogodi da imaš više istih mailova za registraciju. +Odradi user registration 5.19. cca 7:10
    {
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    {

    }
}
