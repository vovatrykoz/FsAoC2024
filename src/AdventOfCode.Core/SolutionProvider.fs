namespace AdventOfCode.Core

type SolutionProvider<'TInfo, 'TInput, 'TOutput>
    (
        infoProvider: IInfoProvider<'TInfo>,
        inputReader: IInputReader<'TInfo, 'TInput>,
        solver: IAdventSolver<'TInput, 'TOutput>,
        logger: ILogger
    ) =

    member _.InfoProvider = infoProvider

    member _.InputReader = inputReader

    member _.Solver = solver

    member _.Logger = logger

    member this.SolveAsync() =
        task {
            let inline log msg = this.Logger.LogInfo msg

            log "Getting initial info..."
            let! info = this.InfoProvider.GetInfoAsync()
            log $"Received the following start info: {info}"

            log $"Reading input from \"{info}\"..."
            let! input = this.InputReader.ReadInputAsync info
            log "Read operation successful!"

            log "Trying to solve the task..."
            let! solution = this.Solver.SolveAsync input
            log "Task solved!"

            return solution
        }
