# Lesson 13: LINQ starter

This starter accompanies the coding-driven LINQ lesson. It includes the models
and data. You will write the queries during class.

## Before class

1. Download the ZIP and choose **Extract All**. Work in the extracted folder.
2. Open **Lesson13_LinqIntro.slnx** in Visual Studio.
3. Build the solution, then run it with **Ctrl+F5**.
4. Confirm that the console displays:

```text
Students ready: 5
Pokémon ready: 20
```

Leave the solution open for class. If it does not build, ask for help before
the lesson begins.

## Requirements

- .NET 10 SDK and Visual Studio 2026 with .NET desktop development tools.
- No additional NuGet packages are required.

If you use the command line, run these commands from the folder containing
the solution:

```shell
dotnet build Lesson13_LinqIntro.slnx
dotnet run --project Lesson13_LinqIntro/Lesson13_LinqIntro.csproj
```

## Files

| File | Purpose |
| --- | --- |
| `Student.cs` | Supplied Student model with Name and Mark |
| `Pokemon.cs` | Supplied Pokemon model |
| `Program.cs` | Five students, 20 Pokémon, startup check, and activity sections |

Continue all coding activities in **Program.cs** below the supplied data.
Keep the models and lists unchanged. Follow the slides for the Student activities
and the worksheet for the Pokémon activities. The blank sections match the
lesson order. Use distinct query variable names when keeping multiple queries.

For each query, predict its result type in a comment, then print its results.
Use `foreach` to display results. The query should decide which items or values
to return.

## Pokémon worksheet

[Open LINQ Basics with Pokémon](https://github.com/NAIT-SDEV2301/lesson-plan-files/blob/main/module02/lesson13/Lesson13-TakeHome-LINQ-Basics-Pokemon.md)

Complete sections A-D **in class** as directed. The linked file still says
“Take-Home”; this lesson uses it as the core in-class activity. Its model and
20-entry dataset are already included here, so skip its setup steps.
