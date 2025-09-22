namespace AdventOfCode.Solvers.DayOne

open AdventOfCode.Core
open System.Threading.Tasks

type HistorianListPair = {
    Left: int array
    Right: int array
} with

    static member create left right = { Left = left; Right = right }

type HistorianHysteriaSolver() =
    interface IAdventSolver<HistorianListPair, int> with
        member _.SolveAsync(input: HistorianListPair) : Task<int> =
            task {
                let leftSorted = input.Left |> Array.sort
                let rightSorted = input.Right |> Array.sort

                let computations =
                    (leftSorted, rightSorted)
                    ||> Array.map2 (fun leftId rightId -> async { return abs (leftId - rightId) })

                let! results = computations |> Async.Parallel |> Async.StartAsTask
                return results |> Array.sum
            }
