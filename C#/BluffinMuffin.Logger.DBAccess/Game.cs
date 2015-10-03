using System;
using System.Linq;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Game
    {
        internal int Id { get; private set; }
        public DateTime GameStartedAt { get; internal set; }

        public Table Table { get; }

        public Game(Table table)
        {
            Table = table;
        }

        public void RegisterGame()
        {
            if (Id > 0)
                return;

            GameStartedAt = DateTime.Now;

            using (var context = Database.GetContext())
            {
                var table = context.AllTableParams.Single(x => x.Id == Table.Id);
                var g = new GameEntity
                {
                    TableParam = table,
                    GameStartedAt = GameStartedAt
                };
                context.AllGames.Add(g);
                context.SaveChanges();
                Id = g.Id;
            }
        }
    }
}
