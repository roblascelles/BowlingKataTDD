using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        private readonly List<Frame> _frames;

        public Game(IReadOnlyCollection<int> rolls)
        {
            _frames = new List<Frame>();

            for (var i = 0; i < rolls.Count; i += 2)
            {
                _frames.Add(new Frame(new List<int>() { rolls.ElementAtOrDefault(i), rolls.ElementAtOrDefault(i + 1) }));
            }
        }

        public int Score()
        {
            var score = 0;
            for (var i = 0; i < _frames.Count; i++)
            {
                var frame = _frames[i];
                var nextFrame = _frames.ElementAtOrDefault(i + 1);

                if (frame.IsStrike)
                {
                    score += 10 + nextFrame?.Score() ?? 0;
                } else if (frame.IsSpare)
                {
                    score += 10 + nextFrame?.FirstTry() ?? 0;
                }
                else
                {
                    score += frame.Score();
                }
            }

            return score;
        }
    }
}
