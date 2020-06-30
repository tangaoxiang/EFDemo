using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using demo.Data;
using demo.Domain;
using Microsoft.EntityFrameworkCore;
namespace demo.App {
    class Program {
        static void Main (string[] args) {
            using var context = new DemoContext ();
            //   var italy = "Italy";
            //     var leagues = context.Leagues.Where (x => x.Country == italy).ToList ();
            //     foreach (var league in leagues) {
            //         Console.WriteLine (league.Name);
            //     }

            //    var f = context.Leagues.Find(2);

            //    System.Console.WriteLine(f?.Id);
            #region demo2 insert
            // var serieA = context.Leagues.FirstOrDefault (x => x.Name == "Serie A");
            // var juventus = new Club {
            //     League = serieA,
            //     Name = "Juventus",
            //     City = "Torino",
            //     DateOfEstablishment = new DateTime (1987, 11, 1),
            //     Players = new List<Player> {
            //     new Player {
            //         Name = "C. Rnaldo",
            //         DateOfBirth = new DateTime (1985, 2, 5)
            //     }
            //     }
            // };
            //  context.Clubs.Add (juventus);
            // int count = context.SaveChanges ();
            // System.Console.WriteLine (count);
            #endregion

            #region demo3 多表关联查询
            var clubs = context.Clubs.Where (c => c.Id > 0)
                .Include (c => c.League)
                .Include (c => c.Players).ThenInclude (p => p.Resume)
                .Include (c => c.Players)
                .ThenInclude (p => p.GamePlayers).ThenInclude (g => g.Game)
                .FirstOrDefault ();
            #endregion

            #region demo4 多表关联查询，子查询 
            var result = context.Clubs.Where (c => c.Id > 0)
                .Select (c => new {//context不能追踪匿名类
                    Id = c.Id,
                        LeagueName = c.League.Name,
                        Name = c.Name,
                        players = c.Players.Where (p => p.DateOfBirth > new DateTime (1990, 1, 1))
                }).ToList();
            #endregion

        }
    }
}