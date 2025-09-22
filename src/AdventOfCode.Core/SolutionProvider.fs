namespace AdventOfCode.Core

type SolutionProvider<'TInfo, 'TInput, 'TOutput>
    (inputReader: IInputReader<'TInfo, 'TInput>, solver: IAdventSolver<'TInput, 'TOutput>, logger: ILogger) =

    member val InputReader = inputReader

    member val Solver = solver

    member val Logger = logger

    member this.SolveAsync(info: 'TInfo) =
        task {
            this.Logger.LogInfo $"Reading input from {info}..."
            let! input = this.InputReader.ReadInputAsync info |> Async.AwaitTask
            this.Logger.LogInfo $"Read operation successful"

            this.Logger.LogInfo $"Trying to solve the task..."
            let! solution = this.Solver.SolveAsync input |> Async.AwaitTask
            this.Logger.LogInfo $"Task solved"

            return solution
        }
