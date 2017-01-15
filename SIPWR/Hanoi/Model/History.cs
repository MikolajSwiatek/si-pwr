using System;
using System.Collections.Generic;

namespace SIPWR.Hanoi.Model
{
    public class History
    {
        public List<string> Moves { get; private set; }

        public int Counter { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTime { get; private set; }

        public History(
            List<string> moves,
            int counter,
            DateTime startTime,
            DateTime endTime)
        {
            this.Moves = moves;
            this.Counter = counter;
            this.StartTime = startTime;
            this.EndTime = endTime;
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