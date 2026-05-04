using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class FourOfAKindStrategy : IHandStrategy
{
    public bool Matches(Hand hand) =>
        hand.Cards
            .GroupBy(c => c.Value)
            .Any(g => g.Count() == 4);

    public HandScore Evaluate(Hand hand)
    {
        var groups = hand.Cards.GroupBy(c => c.Value).ToList();

        var quad = groups.First(g => g.Count() == 4).Key;
        var kicker = groups.First(g => g.Count() == 1).Key;

        return new HandScore(HandRank.FourOfAKind, [(int)quad, (int)kicker]);
    }
}