using PokerApp.Core.Evaluation;
using PokerApp.Core.Models;

var game = new Game();

// Demo 1: Straight Flush vs Four of a Kind
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
    new Card(CardValue.Ace, CardSuit.Spades),
    new Card(CardValue.Ace, CardSuit.Diamonds),
    new Card(CardValue.Ace, CardSuit.Clubs),
    new Card(CardValue.Ace, CardSuit.Hearts),
    new Card(CardValue.King, CardSuit.Clubs)
});

var winners = game.Play(new Dictionary<string, Hand>
{
    { "Alice", hand1 },
    { "Bob", hand2 }
});

Console.WriteLine(winners.Count == 1
    ? $"{winners[0]} has won!"
    : $"Tie between: {string.Join(", ", winners)}");