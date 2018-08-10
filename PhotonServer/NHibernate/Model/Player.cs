using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameServer.Model {
    class Player {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Account { get; set; }
        public virtual string Pwd { get; set; }
        public virtual int Level { get; set; }
        public virtual int Score { get; set; }
    }
}
