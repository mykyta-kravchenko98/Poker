using PokerApp.Core.Evaluation.Strategies;
using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation;

// aggregate strategies and define hand combination
public class HandEvaluator
{
    //from higher combination to lower
    private readonly IReadOnlyList<IHandStrategy> _strategies =
    [
        new StraightFlushStrategy(),
        new FourOfAKindStrategy(),
        new FullHouseStrategy(),
        new FlushStrategy(),
        new StraightStrategy(),
        new ThreeOfAKindStrategy(),
        new TwoPairsStrategy(),
        new PairStrategy(),
        new HighCardStrategy(),
    ];

    public HandScore Evaluate(Hand hand) =>
        _strategies.First(s => s.Matches(hand)).Evaluate(hand);
}