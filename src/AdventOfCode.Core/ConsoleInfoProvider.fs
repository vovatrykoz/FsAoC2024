namespace AdventOfCode.Core

open System
open System.Threading.Tasks

type ConsoleInfoProvider() =
    interface IInfoProvider<string> with
        member _.GetInfoAsync() : Task<string> =
            task {
                let args = Environment.GetCommandLineArgs()

                if Array.length args < 2 then
                    raise (
                        new InvalidOperationException "Please provide the path to the file with the input data when starting the program"
                    )

                return args[1]
            }
