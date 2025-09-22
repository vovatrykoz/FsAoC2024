namespace AdventOfCode.Core

open System.Threading.Tasks

[<Interface>]
type IAdventSolver<'TInput, 'TOutput> =
    abstract member SolveAsync: input: 'TInput -> Task<'TOutput>
