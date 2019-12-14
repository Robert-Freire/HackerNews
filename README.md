# HackerNews

This is a simple command line application that output to STDOUT the top posts of Hacker News in JSON. 

## Getting Started

### Prerequisites

Download and install the [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) on your computer.

### Installing

To build go to the folder of the solution an execute 

```console
dotnet build
```

### Running the application

#### Console arguments
Only one console option is supported:

--posts NUMBER_OF_POSTS sets the number of posts to be returned. NUMBER_OF_POSTS Has to be a number between 0 and 100

### Execution

There are several ways to execute the application. You can 
* Go to the folder HackerNewsConsole inside the solution and execute dotnet build --posts n where n is the number of posts. For example

```console
dotnet run --posts 2
```

* Go to the folder HackerNewsConsole\bin\Debug\netcoreapp3.0 inside the solution and execute

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

In the project, I tried to use different techniques, I like all of them although some of them could be arguable. But one thing I want to mention is the use of generator/iterator in the project, because this technique, I am not sure if it intentionally, fits very well with the API used and the exercise requested. 

Actually, it fits so well that I see it as a good way to explain the use of generators/iterators to people who are not used to them because to see how the responses to each call are printed when the answer arrives and before doing the following call is a very visual way to explain it 
