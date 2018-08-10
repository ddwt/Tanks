using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameServer.Model;

namespace MyGameServer.Manger {
    interface IPlayerManger {
        void Add(Player player);
        void Update(Player player);
        void Remove(Player player);
        Player GetById(int id);
        Player GetByUsername(string username);
        ICollection<Player> GetAllPlayers();
    }
}
