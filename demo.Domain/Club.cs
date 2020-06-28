using System;
using System.Collections.Generic;
namespace demo.Domain{
    /// <summary>
    /// 俱乐部
    /// </summary>
    public class Club{
        public Club(){
            Players = new List<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        /// <summary>
        /// 成立时间
        /// </summary>
        /// <value></value>
        public DateTime DateOfEstablishment { get; set; }
        public string History { get; set; }
        /// <summary>
        /// 联赛
        /// </summary>
        /// <value></value>
        public League League { get; set; }
        /// <summary>
        /// 赛事
        /// </summary>
        /// <value></value>
        public List<Player> Players { get; set; }

    }
}