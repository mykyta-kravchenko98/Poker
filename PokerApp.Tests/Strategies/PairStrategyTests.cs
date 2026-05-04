using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

namespace PoketApp.Tests;

[TestFixture]
public class PairStrategyTests
{
    private readonly Game _game = new();
    
    [Test]
    public void Game_WithTwoHands_PairBeatsHighCard()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Two, CardSuit.Hearts),
            new Card(CardValue.Two, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Queen, CardSuit.Diamonds),
            new Card(CardValue.Jack, CardSuit.Clubs),
            new Card(CardValue.Ten, CardSuit.Spades),
            new Card(CardValue.Eight, CardSuit.Hearts)
        });
        
        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithTwoHands_HighPairBeatsPairCard()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Two, CardSuit.Hearts),
            new Card(CardValue.Two, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Jack, CardSuit.Clubs),
            new Card(CardValue.Ten, CardSuit.Spades),
            new Card(CardValue.Eight, CardSuit.Hearts)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_PairDrawCard()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 2, Is.True);
    }
    
    [Test]
    public void Game_WithTwoHands_PairDrawButFirstKickerWins()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Queen, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_PairDrawButSecondKickerWins()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Queen, CardSuit.Diamonds),
            new Card(CardValue.Jack, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Queen, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    private static Dictionary<string, Hand> Deal(Hand hand1, Hand hand2) =>
        new() { { "Nick", hand1 }, { "King", hand2 } };
}