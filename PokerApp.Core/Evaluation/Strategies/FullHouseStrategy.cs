using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class FullHouseStrategy : IHandStrategy
{
    public bool Matches(Hand hand)
    {
        var groups = hand.Cards.GroupBy(c => c.Value).ToList();
        return groups.Any(g => g.Count() == 3) && 
               groups.Any(g => g.Count() == 2);
    }

    public HandScore Evaluate(Hand hand)
    {
        var groups = hand.Cards.GroupBy(c => c.Value).ToList();

        var triple = groups.First(g => g.Count() == 3).Key;
        var pair = groups.First(g => g.Count() == 2).Key;

        return new HandScore(HandRank.FullHouse, [(int)triple, (int)pair]);
    }
}