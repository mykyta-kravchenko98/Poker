namespace PokerApp.Core.Models;

public record HandScore(HandRank Rank, IReadOnlyList<int> Tiebreakers);