using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeffudge.Server.GameLogic {
    public static class Utils {
        public static bool IsStringValid (string str) {
            return str != null && str != "";
        }
    }
}
