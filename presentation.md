# Code reviews

_A look into why & how of CRs_


## Intro

This presentation is available on github:
[Dantalion](https://github.com/Caezary/Dantalion)

Created in code for ease of presentation.

**This is a highly opinionated presentation with made-up philosophy and some amount of controversy ;)**


## Why do we do code reviews?

### Do computers dream of quality code?

The machine only needs IL or ASM, it doesn't need OO or functional code, readable or maintainable code.

### Who benefits from good code?

Expectations of the business, clients, developers, architects - all is defined by code.

### What constitutes a good code?

* Readability
* Maintainability
* Correctness
* Meeting the business needs
* Extensibility
* Security
* Reusability
* Runtime efficiency

### But is it worth the trouble?

* Does every developer read every line of code in the system at least three times?
* the emotional approach
* how many comments are too much?

### CR Trends

* F2F reviews
* PRs
* non-blocking CRs


## A reviewer's look into CRs

### Some assumptions

Shared code ownership - everybody is responsible for the state of the code and no one developer owns it.

Every developer should know the lingua franca - i.e. language syntax, SOLID, design patterns, most common libraries etc.

A coding standard is present ;)

### The three readings of code

1. Is the code understandable?
2. Is the code correct?
3. Is the code well designed?

### The Beautiful Controversy PT1

* the reviewer reads the code under review a lot
* the more complicated to code is, the harder it is to review it
* if convoluted code also has comments, is it really better? Think about:
    * correctness
    * maintainability
    * readability
* because of this, the reviewer (and all other developers) will probably skip the comments

### The Beautiful Controversy PT2

How are we supposed to write code like that?

* simplify the hard-to-understand parts
* do not do preemptive optimisation
* make the code SCREAM what it does :)
* what about documentation? - there is a mechanism for that

### To test or not to test?

#### What are not Unit Tests?

* Integration Tests
* Automated Acceptance Tests
* Test Scenarios
* Tests - not a mistake

#### What are Unit Tests?

* Proofs
* Specs
* Documentation

### Mechanisms that will raise the reviewer's suspicion ;)

1. Reflection
2. dynamic
3. System.Linq.Expressions
4. Roslyn code generators
5. runtime compile
6. emit
7. other exotic parts of .NET

### Exceptions that will raise the reviewer's suspicion ;)

1. Exception
2. InvalidOperationException
3. NotImplementedException


## Thank You!
