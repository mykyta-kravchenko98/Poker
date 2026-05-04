using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

namespace PokerApp.Tests.Strategies;

[TestFixture]
public class FlushStrategyTests
{
    private readonly Game _game = new();

    [Test]
    public void Game_WithTwoHands_FlushBeatsStraight()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Two, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Hearts),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Six, CardSuit.Spades),
            new Card(CardValue.Seven, CardSuit.Diamonds),
            new Card(CardValue.Eight, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithTwoHands_HighFlushBeatsFlush()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Hearts),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.Six, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Diamonds),
            new Card(CardValue.Eight, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Diamonds)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_FlushDrawButFirstKickerBeat()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.Six, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Diamonds),
            new Card(CardValue.Eight, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Diamonds)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }

    [Test]
    public void Game_WithTwoHands_FlushDrawButSecondKickerBeat()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Ten, CardSuit.Diamonds),
            new Card(CardValue.Eight, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Diamonds)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_FlushDrawButThirdKickerBeat()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Ten, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Ten, CardSuit.Diamonds),
            new Card(CardValue.Eight, CardSuit.Diamonds),
            new Card(CardValue.Four, CardSuit.Diamonds)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithTwoHands_FlushDrawButLastKickerBeat()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Ten, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Ten, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Diamonds)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_FlushDraw()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Ten, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Ten, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Diamonds),
            new Card(CardValue.Four, CardSuit.Diamonds)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 2, Is.True);
    }

    private static Dictionary<string, Hand> Deal(Hand hand1, Hand hand2) =>
        new() { { "Nick", hand1 }, { "King", hand2 } };
}