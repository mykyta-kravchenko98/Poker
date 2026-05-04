namespace PokerApp.Core.Helpers;

internal static class StraightHelper
{
    public static bool IsWheel(IEnumerable<int> values) =>
        values.OrderBy(v => v).SequenceEqual([2, 3, 4, 5, 14]);
}