namespace AdventOfCode.Core

open System.Threading.Tasks

[<Interface>]
type IInfoProvider<'TInfo> =
    abstract member GetInfoAsync: unit -> Task<'TInfo>
