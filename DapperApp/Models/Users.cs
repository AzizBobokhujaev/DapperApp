using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperApp.Models
{
    class Users
    {
        public int Id { get; set; }
        
        public string First_Name { get; set; }
       
        public string Last_Name { get; set; }
        
        public string Middle_Name { get; set; }
       
        public DateTime Birth_Date { get; set; }
     
        public DateTime Created_At { get; set; }
    }
}
