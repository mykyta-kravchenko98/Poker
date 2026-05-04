using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

namespace PoketApp.Tests;

[TestFixture]
public class GameTests
{
    [Test]
    public void Game_WithTwoHands_HigherCardWins()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var deal = new Dictionary<string, Hand>()
        {
            { "Nick", hand1 },
            { "King", hand2 }
        };
        
        var game = new Game();
        var winner = game.Play(deal);

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithThreeHands_HigherCardWins()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Queen, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var hand3 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Spades)
        });
        
        var deal = new Dictionary<string, Hand>()
        {
            { "Nick", hand1 },
            { "King", hand2 },
            { "Bob", hand3 }
        };
        
        var game = new Game();
        var winner = game.Play(deal);

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Bob"));
    }
    
    [Test]
    public void Game_WithThreeHands_HigherCardDraw()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var hand3 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Spades),
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Spades),
            new Card(CardValue.Seven, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Clubs)
        });
    
        var deal = new Dictionary<string, Hand>()
        {
            { "Nick", hand1 },
            { "King", hand2 },
            { "Bob", hand3 }
        };
    
        var game = new Game();
        var winner = game.Play(deal);

        Assert.That(winner.Count == 2, Is.True);
        Assert.That(winner, Does.Contain("Nick"));
        Assert.That(winner, Does.Contain("Bob"));
    }
    
    [Test]
    public void Game_WithThreeHands_HigherSecondCardWin()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Queen, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Spades)
        });

        var hand3 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Spades),
            new Card(CardValue.Three, CardSuit.Hearts),
            new Card(CardValue.Five, CardSuit.Spades),
            new Card(CardValue.Seven, CardSuit.Diamonds),
            new Card(CardValue.Nine, CardSuit.Clubs)
        });
        
        var deal = new Dictionary<string, Hand>()
        {
            { "Nick", hand1 },
            { "King", hand2 },
            { "Bob", hand3 }
        };
        
        var game = new Game();
        var winner = game.Play(deal);

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }
    
    [Test]
    public void Game_WithTwoHands_AllCardsEqual_IsDraw()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Spades),
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Seven, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Clubs)
        });

        var deal = new Dictionary<string, Hand>()
        {
            { "Nick", hand1 },
            { "King", hand2 }
        };

        var game = new Game();
        var winner = game.Play(deal);

        Assert.That(winner.Count == 2, Is.True);
        Assert.That(winner, Does.Contain("Nick"));
        Assert.That(winner, Does.Contain("King"));
    }
    
    [Test]
    public void Game_WithDuplicateCardsAcrossHands_ThrowsException()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Diamonds),
            new Card(CardValue.Seven, CardSuit.Spades),
            new Card(CardValue.Nine, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts), // duplicate
            new Card(CardValue.King, CardSuit.Diamonds),
            new Card(CardValue.Queen, CardSuit.Clubs),
            new Card(CardValue.Jack, CardSuit.Hearts),
            new Card(CardValue.Ten, CardSuit.Spades)
        });

        var deal = new Dictionary<string, Hand>()
        {
            { "Nick", hand1 },
            { "King", hand2 }
        };

        var game = new Game();

        Assert.Throws<ArgumentException>(() => game.Play(deal));
    }
}