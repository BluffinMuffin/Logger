using System;
using System.Linq;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Game
    {
        internal int Id { get; private set; }
        
        public Table Table { get; }

        public Game(Table table)
        {
            Table = table;
        }

        public void RegisterGame()
        {
            if (Id > 0)
                return;

            using (var context = Database.GetContext())
            {
                var table = context.AllTableParams.Single(x => x.Id == Table.Id);
                var g = new GameEntity
                {
                    TableParam = table,
                    GameStartedAt = DateTime.Now
                };
                context.AllGames.Add(g);
                context.SaveChanges();
                Id = g.Id;
            }
        }
    }
}
