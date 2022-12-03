using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
    }
    public class UserMetadata
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
      
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        [Required]
        public string Phone_no { get; set; }
        public string Address { get; set; }
        [Required]
       public string State { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public bool Agree { get; set; }
    }
}