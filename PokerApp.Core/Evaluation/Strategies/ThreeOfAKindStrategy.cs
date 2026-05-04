using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class ThreeOfAKindStrategy : IHandStrategy
{
    public bool Matches(Hand hand) =>
        hand.Cards
            .GroupBy(c => c.Value)
            .Any(g => g.Count() == 3);

    public HandScore Evaluate(Hand hand)
    {
        var groups = hand.Cards
            .GroupBy(c => c.Value)
            .ToList();

        var triple = groups
            .First(g => g.Count() == 3).Key;

        var kickers = groups
            .Where(g => g.Count() == 1)
            .Select(g => (int)g.Key)
            .OrderByDescending(v => v)
            .ToList();

        return new HandScore(HandRank.ThreeOfAKind, [(int)triple, kickers[0], kickers[1]]);
    }
}