using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPJ
{
    public class notify
    {
        
        public String send { get; set; }
        public String filename { get; set; }
        public String msg { get; set; }
        public String status { get; set; }
        public String type { get; set; }
        public int id { get; set; }
        public String datet { get; set; }
        public notify()
        {
            this.send = send;
            this.filename = filename;
            this.msg = msg;
            this.status = status;
            this.type = type;
            this.id = id;
            this.datet = datet;
        }

    }
}