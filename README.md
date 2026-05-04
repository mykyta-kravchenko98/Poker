## How to run
dotnet run --project PokerApp.Core

## How to run tests  
dotnet test

## Architecture

### Strategy Pattern
Each poker hand combination (Flush, Straight, Pair, etc.) is implemented 
as a separate strategy (`IHandStrategy`). This avoids a large if/else chain 
and makes it easy to add or modify combinations independently.
The `HandEvaluator` aggregates all strategies and selects the first matching 
one, ordered from highest to lowest combination.

### Value Objects
`Card` and `HandScore` are implemented as C# records — immutable, 
with structural equality. This ensures that two cards with the same 
value and suit are always considered equal, which is essential for 
duplicate detection across hands.

### TDD
The project was developed using Test-Driven Development. Each combination 
was covered with tests before implementation, which made it clear what 
needed to be built at every step and ensured all edge cases were handled 
— including wheel straights (A-2-3-4-5), flush tiebreakers across all 
5 cards, and draws between multiple hands.

## AI Usage

Claude (Anthropic) was used as a coding assistant.

- Code scaffolding and boilerplate generation
- Syntax suggestions during implementation
- Test case review

Architecture decisions, TDD workflow, and business logic 
were designed and validated independently.
