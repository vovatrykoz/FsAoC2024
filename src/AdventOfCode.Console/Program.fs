open AdventOfCode.Core
open AdventOfCode.Solvers.DayOne
open System

let logger = new ConsoleLogger() :> ILogger

try
    let infoProvider = new ConsoleInfoProvider() :> IInfoProvider<string>

    let reader =
        new HistorianHysteriaReader() :> IInputReader<string, HistorianListPair>

    let solver = new HistorianHysteriaSolver() :> IAdventSolver<HistorianListPair, int>

    let solutionProvider =
        new SolutionProvider<string, HistorianListPair, int>(infoProvider, reader, solver, logger)

    let solution =
        solutionProvider.SolveAsync() |> Async.AwaitTask |> Async.RunSynchronously

    logger.LogInfo $"solution = {solution}"
with ex ->
    logger.LogError ex.Message
    Environment.Exit -1
