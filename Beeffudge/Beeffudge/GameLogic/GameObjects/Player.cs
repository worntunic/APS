using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeffudge.GameLogic.GameObjects {
    public class Player {
        public string name;
        public int score;

        public Player () {
            this.score = 0;
        }

        public Player (string name) {
            this.name = name;
            this.score = 0;
        }
    }
}
