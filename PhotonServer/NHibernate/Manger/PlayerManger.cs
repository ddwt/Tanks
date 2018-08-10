using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameServer.Model;
using NHibernate;
using NHibernate.Criterion;

namespace MyGameServer.Manger {
    class PlayerManger : IPlayerManger {
        public void Add(Player player) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    session.Save(player);
                    transaction.Commit();
                }    
            }
        }

        public ICollection<Player> GetAllPlayers() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                IList<Player> players = session.CreateCriteria(typeof(Player)).List<Player>();
                return players;
            }
        }

        public Player GetById(int id) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    Player player = session.Get<Player>(id);
                    transaction.Commit();
                    return player;
                }
            }
        }

        public Player GetByUsername(string username) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                Player player = session.CreateCriteria(typeof(Player)).Add(Restrictions.Eq("Username", username)).UniqueResult<Player>();
                return player;
            }
        }

        public void Remove(Player player) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    session.Delete(player);
                    transaction.Commit();
                }
            }
        }

        public void Update(Player player) {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction transaction = session.BeginTransaction()) {
                    session.Update(player);
                    transaction.Commit();
                }
            }
        }
    }
}
