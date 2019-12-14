# HackerNews

This is a simple command line application that output to STDOUT the top posts of Hacker News in JSON. 

## Getting Started

### Prerequisites

First, download and install the [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) on your computer.

### Installing

To build go to the folder of the solution an execute 

```console
dotnet build
```

and to run the application go to the folder HackerNewsConsole inside the solution and execute dotnet build --posts n where n is the number of posts. For example

```console
dotnet run --posts 2
```

or go to the folder ... HackerNewsConsole\bin\Debug\netcoreapp3.0 and run

```console
HackerNewsConsole.exe --posts 3
```

## Running the tests
To run the test go to the folder HackerNewsConsoleTests and execute

```console
dotnet test
```

## Dependencies
The dependencies of the project HackerNewsConsole are

* Newtonsoft.Json -- For Serialization
* Microsoft DependencyInjection -- Dependency Management
* Microsoft Configuration -- Settings Management

Also for testing

* Moq -- As a mocking framework
* Microsoft TestFramework -- As a testing framework

## Notes

In the project, I tried to use different techniques, all I liked, although some of them could be strongly opinionated. But one thing that I want to mention is the use of generator/iterator in the project, because this technique, I don't know if intentionally or not fits very well whit the API used and the asked exercise. Actually it fits so well that I see as a good way to explain the use of generators/iterators to fellows that aren't used to them because is very visual to see how the responses to every call are printed before doing the next call 
