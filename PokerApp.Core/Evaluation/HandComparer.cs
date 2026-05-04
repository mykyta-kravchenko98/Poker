using PokerApp.Core.Models;

namespace PokerApp.Core.Evaluation;

// Compare two hands
public class HandComparer : IComparer<HandScore>
{
    public int Compare(HandScore? x, HandScore? y)
    {
        if (x is null && y is null) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        var rankResult = x.Rank.CompareTo(y.Rank);
        if (rankResult != 0)
            return rankResult;

        return x.Tiebreakers
            .Zip(y.Tiebreakers)
            .Select(pair => pair.First.CompareTo(pair.Second))
            .FirstOrDefault(r => r != 0);
    }
}