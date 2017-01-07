using System.Collections.Generic;

namespace SIPWR.Hanoi.Model
{
    public class History
    {
        public List<string> Moves { get; private set; }
        public int Counter { get; private set; }

        public History(List<string> moves, int counter)
        {
            this.Moves = moves;
            this.Counter = counter;
        }

        public string GetMovesString()
        {
            var text = string.Empty;

            foreach (var line in Moves)
            {
                text += line + "\n";
            }

            return text;
        }
    }
}