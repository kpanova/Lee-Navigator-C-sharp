using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorNaumen
{
    public enum State
    {
        Wall,
        Way,
        Start,
        Finish
    }
    public static class States
    {
        public static Dictionary<char, State> dictionary = new Dictionary<char, State>
        {
            {'#', State.Wall },
            {'.', State.Way },
            {'@', State.Start },
            {'X', State.Finish }
        };
        public static Dictionary<State, bool> canGo = new Dictionary<State, bool>
        {
            {State.Wall, false },
            {State.Way, true },
            {State.Start, true },
            {State.Finish, true }
        };
        public static bool IsFinish(State state)
        {
            if (state == State.Finish)
            {
                return true;
            }
            else { return false; }
        }
        public static bool IsStart(State state)
        {
            if (state == State.Start)
            {
                return true;
            }
            else { return false; }
        }
    }
}
