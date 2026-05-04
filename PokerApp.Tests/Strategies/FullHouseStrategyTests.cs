using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

namespace PokerApp.Tests.Strategies;

[TestFixture]
public class FullHouseStrategyTests
{
    private readonly Game _game = new();

    [Test]
    public void Game_WithTwoHands_FullHouseBeatsFlush()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.King, CardSuit.Hearts),
            new Card(CardValue.Ten, CardSuit.Hearts),
            new Card(CardValue.Nine, CardSuit.Hearts),
            new Card(CardValue.Four, CardSuit.Hearts)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("Nick"));
    }

    [Test]
    public void Game_WithTwoHands_HighFullHouseBeatsFullHouse()
    {
        var hand1 = new Hand(new[]
        {
            new Card(CardValue.Three, CardSuit.Clubs),
            new Card(CardValue.Three, CardSuit.Spades),
            new Card(CardValue.Three, CardSuit.Diamonds),
            new Card(CardValue.Five, CardSuit.Clubs),
            new Card(CardValue.Five, CardSuit.Hearts)
        });

        var hand2 = new Hand(new[]
        {
            new Card(CardValue.Ace, CardSuit.Hearts),
            new Card(CardValue.Ace, CardSuit.Diamonds),
            new Card(CardValue.Ace, CardSuit.Clubs),
            new Card(CardValue.King, CardSuit.Spades),
            new Card(CardValue.King, CardSuit.Hearts)
        });

        var winner = _game.Play(Deal(hand1, hand2));

        Assert.That(winner.Count == 1, Is.True);
        Assert.That(winner.First(), Is.EqualTo("King"));
    }

    private static Dictionary<string, Hand> Deal(Hand hand1, Hand hand2) =>
        new() { { "Nick", hand1 }, { "King", hand2 } };
}