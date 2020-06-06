# lioneditor
A system agnostic (hopefully) FFT-WOTL save editor based on [https://github.com/bsides/lioneditor](https://github.com/bsides/lioneditor)

# Work in progress

This repo is a work in progress.  I'll update the readme to reflect changes as I go.  My goal is to take the C# of the original work and rewrite it beat for beat in ruby.  It'll be a command line tool first, then I'll work on the GUI with Shoes ([https://github.com/shoes/shoes4](https://github.com/shoes/shoes4)) or some such. 

The focus for now is purely on the save editor, so I'll be stripping out the other tools in order to simplify the folder structure.  I'll build forks of those in time if I have any success in this first adventure.  I'll deal with any shared scripts as I go.  Not sure what I'll do with those yet for maintainability.  Hopefully I can strip out the relevant parts of each.  We'll see.

I'm happy to take recommendations and contributions from anyone, especially those who have used the editor (I have not, hence my building this).  I'm a perfectionist, but I'm far from the best coder out there, and I try to be kind so don't be shy!

Here's the overall plan:

## Pre-release

1. Get the data structures built out naively
2. Get the main module using the data structures to parse a save file and prove that the rubified data structures truly work.
3. Get a CLI up and running for basic manipulation of the file (I have had limited success with this in the past, so I may forego this, but darned if I don't want to give it another try)

## Post-release
Get a GUI up and running and tested on OSX.  I don't have a linux machine anywhere, so anyone who wants to contribute to that side of testing is welcome.  I have indirect access to a windows machine, so I'll eventually test on there as well.
