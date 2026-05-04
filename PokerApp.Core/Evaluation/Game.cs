using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation;

public class Game
{
    private readonly HandEvaluator _handEvaluator;
    private readonly HandComparer _handComparer;

    public Game()
    {
        _handEvaluator = new HandEvaluator();
        _handComparer = new HandComparer();
    }
    public IReadOnlyList<string> Play(Dictionary<string, Hand> hands)
    {
        var allCards = hands.Values.SelectMany(h => h.Cards).ToList();
        if (allCards.Count != allCards.Distinct().Count())
            throw new ArgumentException("Duplicate cards found across hands");
        
        var scores = hands
            .ToDictionary(
                kvp => kvp.Key,
                kvp => _handEvaluator.Evaluate(kvp.Value)
            );

        var bestScore = scores.Values.Max(_handComparer);

        return scores
            .Where(kvp => _handComparer.Compare(kvp.Value, bestScore) == 0)
            .Select(kvp => kvp.Key)
            .ToList();
    }
}