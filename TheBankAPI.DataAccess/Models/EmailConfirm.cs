using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBankAPI.DataAccess.Models
{
    public class EmailConfirm
    {
        public string UserId { get; set; }
        public string UserToken { get; set; }
    }
}
