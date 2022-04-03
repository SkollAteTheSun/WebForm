using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebForm.Models
{
    public class Form
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Topic { get; set; }
        
        public string Subject { get; set; }
        
    }
}
