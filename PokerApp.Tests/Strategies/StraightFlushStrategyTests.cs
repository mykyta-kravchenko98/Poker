using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

namespace PokerApp.Tests.Strategies;

[TestFixture]
public class StraightFlushStrategyTests
{
    private readonly Game _game = new();

    [Test]
    public void Game_WithTwoHands_StraightFlushBeatsFourOfAKind()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Five, CardSuit.Hearts),
            new Card(CardValue.Six, CardSuit.Hearts),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Eight, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.Ace, CardSuit.Clubs),
            new Card(CardValue.Ace, CardSuit.Spades),
            new Card(CardValue.King, CardSuit.Clubs)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }

    [Test]
    public void Game_WithTwoHands_WheelStraightFlushLosesToNormalStraightFlush()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Two, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Two, CardSuit.Spades),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Four, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Spades),
            new Card(CardValue.Six, CardSuit.Spades)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_RoyalStraightFlushDraw()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Queen, CardSuit.Hearts),
            new Card(CardValue.Jack, CardSuit.Hearts),
            new Card(CardValue.Ten, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Spades),
            new Card(CardValue.King, CardSuit.Spades),
            new Card(CardValue.Queen, CardSuit.Spades),
            new Card(CardValue.Jack, CardSuit.Spades),
            new Card(CardValue.Ten, CardSuit.Spades)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 2, Is.True);
    }

    private static Dictionary<string, Hand> Deal(Hand hand1, Hand hand2) =>
        new() { { "Nick", hand1 }, { "King", hand2 } };
}