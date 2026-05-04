using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation.Strategies;

public class StraightFlushStrategy : IHandStrategy
{
    private readonly FlushStrategy _flushStrategy = new();
    private readonly StraightStrategy _straightStrategy = new();

    public bool Matches(Hand hand) =>
        _flushStrategy.Matches(hand) && _straightStrategy.Matches(hand);

    public HandScore Evaluate(Hand hand)
    {
        var values = hand.Cards.Select(c => (int)c.Value).ToList();
        var highCard = IsWheel(values) ? 5 : values.Max();
        return new HandScore(HandRank.StraightFlush, [highCard]);
    }

    private static bool IsWheel(List<int> values) =>
        values.OrderBy(v => v).SequenceEqual([2, 3, 4, 5, 14]);
}