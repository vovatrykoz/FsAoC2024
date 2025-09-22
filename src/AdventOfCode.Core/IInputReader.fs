namespace AdventOfCode.Core

open System.Threading.Tasks

[<Interface>]
type IInputReader<'TInfo, 'TInput> =
    abstract member ReadInputAsync: info: 'TInfo -> Task<'TInput>
