using System.IO;
using demo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace demo.Data {
    public class DemoContext : DbContext {
        IConfiguration configuration;
        public DemoContext () {
            //获取路径下的配置文件，生成文件处理对象
            configuration = new ConfigurationBuilder ().SetBasePath (Directory.GetCurrentDirectory ()).AddJsonFile ("appsettings.json").Build ();
        }
        /// <summary>
        /// 根据配置节点，读取配置文件
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql (configuration.GetConnectionString ("Default"));
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<GamePlayer> ().HasKey (c => new { c.PlayerId, c.GameId });
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}