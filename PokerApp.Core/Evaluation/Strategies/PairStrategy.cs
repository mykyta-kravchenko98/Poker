using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class PairStrategy : IHandStrategy
{
    public bool Matches(Hand hand) =>
        hand.Cards
            .GroupBy(c => c.Value)
            .Any(g => g.Count() == 2);

    public HandScore Evaluate(Hand hand)
    {
        var groups = hand.Cards
            .GroupBy(c => c.Value)
            .ToList();

        var pair = groups
            .First(g => g.Count() == 2).Key;

        var kickers = groups
            .Where(g => g.Count() == 1)
            .Select(g => (int)g.Key)
            .OrderByDescending(v => v)
            .ToList();

        var tiebreakers = new List<int> { (int)pair };
        tiebreakers.AddRange(kickers);

        return new HandScore(HandRank.Pair, tiebreakers);
    }
}