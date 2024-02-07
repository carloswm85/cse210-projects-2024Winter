> - The journal is serving double-duty to *manage the menu* as well as to *be the journal*.
> - Normally, I would separate these two things as being distinct, since it makes the code more modular and reusable if you don't tie them together.
> - It is reasonable you might want to manage a journal with a different front-end structure (e.g. GUI).
> - I would also probably *put the prompts somewhere that isn't a local variable* in a method.
> - In practice, this is probably fine because it is constant. The compiler might be smart enough to put this all in the data section and use it directly, but because it is a local variable, there is a risk that your computer will load it into memory each time you call ShowPrompt(). This is a more advanced concept, though, and I wouldn't expect you to think about such things at this point.
> 
> Nathan Parrish