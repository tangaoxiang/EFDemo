using System.Collections.Generic;
namespace demo.Domain {
    /// <summary>
    /// 每场赛事
    /// </summary>
    public class GamePlayer {
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}