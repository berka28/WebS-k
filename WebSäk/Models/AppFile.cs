using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSäk.Models
{
    public class AppFile
    {
        public int Id { get; set; }
        public string UntrustedName { get; set; }
        public DateTime TimeStamp { get; set; }
        public long Size { get; set; }
        public byte[] Content { get; set; }
    }
}
