namespace AdventOfCode.Core

type SolutionProvider<'TInfo, 'TInput, 'TOutput>
    (
        infoProvider: IInfoProvider<'TInfo>,
        inputReader: IInputReader<'TInfo, 'TInput>,
        solver: IAdventSolver<'TInput, 'TOutput>,
        logger: ILogger
    ) =

    member val InfoProvider = infoProvider

    member val InputReader = inputReader

    member val Solver = solver

    member val Logger = logger

    member this.SolveAsync() =
        task {
            this.Logger.LogInfo "Starting the solver..."
            this.Logger.LogInfo "Getting initial info..."
            let! info = this.InfoProvider.GetInfoAsync() |> Async.AwaitTask
            this.Logger.LogInfo $"Received the following start info: {info}"

            this.Logger.LogInfo $"Reading input from \"{info}\"..."
            let! input = this.InputReader.ReadInputAsync info |> Async.AwaitTask
            this.Logger.LogInfo "Read operation successful!"

            this.Logger.LogInfo "Trying to solve the task..."
            let! solution = this.Solver.SolveAsync input |> Async.AwaitTask
            this.Logger.LogInfo "Task solved!"

            return solution
        }
