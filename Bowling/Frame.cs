using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Frame
    {
        private readonly List<int> _rolls;

        public Frame(IEnumerable<int> rolls)
        {
            _rolls = rolls.ToList();
        }

        public int Score()
        {
            return _rolls.ElementAtOrDefault(0) + _rolls.ElementAtOrDefault(1);
        }
        public int FirstTry()
        {
            return _rolls.ElementAtOrDefault(0);
        }

        public bool IsStrike => _rolls.ElementAtOrDefault(0) == 10;
        public bool IsSpare => _rolls.ElementAtOrDefault(0) +  _rolls.ElementAtOrDefault(1) == 10 && _rolls.ElementAtOrDefault(0) < 10;
    }
}