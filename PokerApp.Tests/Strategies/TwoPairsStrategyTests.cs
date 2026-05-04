using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

[TestFixture]
public class TwoPairsStrategyTests
{
    private readonly Game _game = new();
    
    [Test]
    public void Game_WithTwoHands_TwoPairsBeatsPair()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });
        
        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithTwoHands_HighTwoPairsBeatsTwoPair()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });
        
        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }
    
    [Test]
    public void Game_WithTwoHands_TwoPairsBeatsTwoPairWithHigherSecondPair()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });
        
        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }

    [Test]
    public void Game_WithTwoHands_TwoPairsDrawButKickerWins()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Spades),
            new Card(CardValue.Three, CardSuit.Spades)
        });
        
        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithTwoHands_TwoPairsDraw()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Spades),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Spades)
        });
        
        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 2, Is.True);
    }
    
    private static Dictionary<string, Hand> Deal(Hand hand1, Hand hand2) =>
        new() { { "Nick", hand1 }, { "King", hand2 } };
}