using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class StraightStrategy : IHandStrategy
{
    public bool Matches(Hand hand)
    {
        var values = GetValues(hand);
        return IsWheel(values) || IsConsecutive(values);
    }

    public HandScore Evaluate(Hand hand)
    {
        var values = GetValues(hand);
        var highCard = IsWheel(values) ? 5 : values.Max();
        return new HandScore(HandRank.Straight, [highCard]);
    }

    private static List<int> GetValues(Hand hand) =>
        hand.Cards
            .Select(c => (int)c.Value)
            .OrderBy(v => v)
            .ToList();

    private static bool IsWheel(List<int> values) =>
        values.SequenceEqual([2, 3, 4, 5, 14]);

    private static bool IsConsecutive(List<int> values) =>
        values.Last() - values.First() == 4 &&
        values.Distinct().Count() == 5;
}