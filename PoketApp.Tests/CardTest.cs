using PokerApp.Core.Models;

namespace PoketApp.Tests;

[TestFixture]
public class CardTests
{
    [Test]
    public void Card_WithSameRankAndSuit_ShouldBeEqual()
    {
        var card1 = new Card(CardValue.Ace, CardSuit.Hearts);
        var card2 = new Card(CardValue.Ace, CardSuit.Hearts);
        
        Assert.That(card1, Is.EqualTo(card2));
    }
    
    [Test]
    public void Card_WithDifferentRank_ShouldNotBeEqual()
    {
        var card1 = new Card(CardValue.Ace, CardSuit.Hearts);
        var card2 = new Card(CardValue.King, CardSuit.Hearts);
        
        Assert.That(card1, Is.Not.EqualTo(card2));
    }
    
    [Test]
    public void Card_WithDifferentSuit_ShouldNotBeEqual()
    {
        var card1 = new Card(CardValue.Ace, CardSuit.Hearts);
        var card2 = new Card(CardValue.Ace, CardSuit.Spades);
        
        Assert.That(card1, Is.Not.EqualTo(card2));
    }

    [Test]
    public void Rank_ShouldBeOrderedCorrectly()
    {
        Assert.That(CardValue.Ace, Is.GreaterThan(CardValue.King));
        Assert.That(CardValue.King, Is.GreaterThan(CardValue.Queen));
        Assert.That(CardValue.Two, Is.LessThan(CardValue.Three));
    }
    
    [Test]
    public void Hand_ShouldContainFiveCards()
    {
        var hand = new Hand(new[]
        {
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.King, Suit.Hearts),
            new Card(Rank.Queen, Suit.Hearts),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Ten, Suit.Hearts)
        });
        
        Assert.That(hand.Cards.Count, Is.EqualTo(5));
    }
}