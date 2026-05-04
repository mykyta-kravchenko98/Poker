using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation;

public interface IHandStrategy
{
    bool Matches(Hand hand);
    HandScore Evaluate(Hand hand);
}