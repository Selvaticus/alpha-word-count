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
of => 4285
author => 3801
great => 2010
personal => 1840
church => 1524
artwork => 1144
any => 939
or => 759
lord => 655
war => 602
Finished in: 271 ms
```

## Assumptions

- Casing doesnt matter for words, i.e Work == work
- No special treatment of special caracters, odd 'words', or numbers, as amount of english words should dwarf those cases and still allows us to return top results easily
- Also using Regex expression should take care of those special characters anyway.
- I focused mainly on code without any unit tests, as the problem space was quite small and I could move faster and still be able to catch errors (I think)