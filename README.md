# Polang

## About
Polang is a Teletubby themed programming language. I know nothing about designing programming languages but hopefully I'll learn something through creating this abomination.


## Usage

### Valid Polang program

Polang programs must start with

```
Over the hills and faraway Teletubbies come to play
```
and end with
```
The sun is setting in the sky, Teletubbies say goodbye
```

### Writing to the console

Writing to the console is done via the `Say eh-oh` keyword.

#### Example

```
Say eh-oh "Tinky winky!"
```

### Variables

A variable can be defined by the key phrase `Time for` followed by the variable name and an initial value. 

Currently supported types:
- String
- Int

#### Example

```
Time for x 10
```

Variables can be reassigned using the same technique:

```
Time for x "Po"
Say eh-oh x // Prints "Po"
Time for x "Dipsy"
Say eh-oh x // Prints "Dipsy"
```

### If statements

`What's that?` followed by two variables. Any following lines starting with a tab will execute if the given variables are the same.

#### Example

```
Time for x "Po"
Time for y "Po"

What's that? x y
    Say eh-oh "It's Po!"
```

### Loops

`Ring a ring o' roses, a pocket full of posies` will start an infinite loop. `A-tishoo, a-tishoo` defines the end of the loop scope. The loop will exit when the keyword `We all fall down` is encountered.

#### Example

Prints the numbers 1 to 10:

```
Time for i = 1

Ring a ring o' roses, a pocket full of posies



A-tishoo, a-tissue
```

