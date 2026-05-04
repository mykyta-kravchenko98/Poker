using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class TwoPairsStrategy : IHandStrategy
{
    public bool Matches(Hand hand) =>
        hand.Cards
            .GroupBy(c => c.Value)
            .Count(g => g.Count() == 2) == 2;

    public HandScore Evaluate(Hand hand)
    {
        var groups = hand.Cards
            .GroupBy(c => c.Value)
            .ToList();

        var pairs = groups
            .Where(g => g.Count() == 2)
            .Select(g => (int)g.Key)
            .OrderByDescending(v => v)
            .ToList();

        var kicker = groups
            .First(g => g.Count() == 1).Key;

        return new HandScore(HandRank.TwoPair, [pairs[0], pairs[1], (int)kicker]);
    }
}