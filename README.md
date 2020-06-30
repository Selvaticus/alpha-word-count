# Word counter

## Requirements

This was done with .netcore 3.1.5 on macOS, but this should run on any machine with the same SDK version/stack.

SDK: `3.1.301 [/usr/local/share/dotnet/sdk]`

Runtime: `Microsoft.NETCore.App 3.1.5 [/usr/local/share/dotnet/shared/Microsoft.NETCore.App]`

## Install

There is nothing to install, no speciall packages were used.

## Run

To run simple use the dotnetcore command, passing in a file.

Hopefully you should get something like bellow

```sh
$ dotnet run lotr.txt
Reading file: lotr.txt
Top 10 words by count 
the => 4285
of => 3801
a => 2010
by => 1840
that => 1524
as => 1144
work => 939
or => 759
their => 655
at => 602
Finished in: 276 ms
```

## Assumptions

- Casing doesnt matter for words, i.e Work == work
- No special treatment of special caracters, odd 'words', or numbers, as amount of english words should dwarf those cases and still allows us to return top results easily
- Also using Regex expression should take care of those special characters anyway.
- I focused mainly on code without any unit tests, as the problem space was quite small and I could move faster and still be able to catch errors (I think)

## Problems

- There might be a problem/bug with the counting of some words, I seem to be able to find less 'a' or 'A' than the word counter program. This is most likely due to the regex expression matches not being what I initially expected. But it could also be that I'm not keeping the sorted list correctly, and if that is the case than there are bigger problems because we can't garantuee that any of those words are actually the top x.