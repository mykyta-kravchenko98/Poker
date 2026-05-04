using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class FlushStrategy : IHandStrategy
{
    public bool Matches(Hand hand) =>
        hand.Cards
            .GroupBy(c => c.Suit)
            .Count() == 1;

    public HandScore Evaluate(Hand hand)
    {
        var tiebreakers = hand.Cards
            .Select(c => (int)c.Value)
            .OrderByDescending(v => v)
            .ToList();

        return new HandScore(HandRank.Flush, tiebreakers);
    }
}