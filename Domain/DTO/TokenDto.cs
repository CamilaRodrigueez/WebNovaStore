using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    internal class TokenDto
    {
        public string token { get; set; }
        public string expiration { get; set; }
    }
}
