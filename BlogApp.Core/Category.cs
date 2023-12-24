using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        public string LogoUrl { get; set; }
    }
}
