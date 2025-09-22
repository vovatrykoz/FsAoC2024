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

    let args = Environment.GetCommandLineArgs()

    if Array.length args < 2 then
        logger.LogError "Please provide the path to the file with the input data"
        Environment.Exit -1

    let path = args[1]

    let solution =
        solutionProvider.SolveAsync() |> Async.AwaitTask |> Async.RunSynchronously

    logger.LogInfo $"solution = {solution}"
with ex ->
    logger.LogError ex.Message
    Environment.Exit -1
