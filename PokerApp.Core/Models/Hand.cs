namespace PokerApp.Core.Models;

public class Hand
{
    public IReadOnlySet<Card> Cards { get; }

    public Hand(IEnumerable<Card> cards)
    {
        var cardSet = new HashSet<Card>(cards);
        
        if (cardSet.Count != 5)
            throw new ArgumentException("Hand must contain exactly 5 cards.");
            
        Cards = cardSet;
    }
}