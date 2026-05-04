using PokerApp.Core.Helpers;
using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class StraightStrategy : IHandStrategy
{
    public bool Matches(Hand hand)
    {
        var values = GetValues(hand);
        return StraightHelper.IsWheel(values) || IsConsecutive(values);
    }

    public HandScore Evaluate(Hand hand)
    {
        var values = GetValues(hand);
        var highCard = StraightHelper.IsWheel(values) ? 5 : values.Max();
        return new HandScore(HandRank.Straight, [highCard]);
    }

    private static List<int> GetValues(Hand hand) =>
        hand.Cards
            .Select(c => (int)c.Value)
            .OrderBy(v => v)
            .ToList();

    private static bool IsConsecutive(List<int> values) =>
        values.Last() - values.First() == 4 &&
        values.Distinct().Count() == 5;
}