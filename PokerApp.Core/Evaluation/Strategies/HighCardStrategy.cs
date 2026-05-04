using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class HighCardStrategy : IHandStrategy
{
    //always the last option
    public bool Matches(Hand hand) => true;

    public HandScore Evaluate(Hand hand)
    {
        var tiebreakers = hand.Cards
            .Select(c => (int)c.Value)
            .OrderByDescending(v => v)
            .ToList();

        return new HandScore(HandRank.HighCard, tiebreakers);
    }
}