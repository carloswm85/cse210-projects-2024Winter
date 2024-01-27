# Class Definition

- `Main` method in class `Program` handles the `Journal` class.
- Entries are not visible at that level, since they're are all internaly handled inside every journal.
- Every journal has a list of entries, that are created, displayed, loaded and saved by the `Journal` class.
- The `Journal` class contains the necessary methods for the functioning of every journal object.

```cs
CLASS: Entry
Attributes:
+ _prompt : string
+ _response : string
+ _date : DateTime || int || string
Behaviors:
+ Display() : void
```

```cs
CLASS: Journal
Attributes:
+ _entries : List<Entry>
Behaviors:
+ Display() : void (?)
+ GetOptionSelection() : int
~ Save() : void
~ Load() : void
~ Write() : void
- ShowPrompt() : void
```

# Unused Elements

```cs
// NOT USED
CLASS: Menu
Attributes:
* _options : List<int> (?)
// Options:
// - Write entry
// - Display journal
// - Load journal from a file
// - Save journal to a file
// - Quit
* _prompts : List<string>
// Who was the most interesting person I interacted with today?
// What was the best part of my day?
// How did I see the hand of the Lord in my life today?
// What was the strongest emotion I felt today?
// If I had one thing I could do over today, what would it be?
Behaviors:
* Load() : string
* Save() : void
* Display() : void
```

# Extra

- Read all files stored in the journal folder location.
- `Report on what you have done to exceed requirements by adding a description of it in a comment in the Program.cs file.`

