using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Student : BaseEntity
    {
        public string Name
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
    }
}



