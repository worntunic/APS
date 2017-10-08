using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeffudge.Server.GameLogic.GameObjects {
    public class Player {
        public string name;
        public int score;

        public Player (string name) {
            this.name = name;
            this.score = 0;
        }
    }
}
