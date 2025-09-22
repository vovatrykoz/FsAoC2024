namespace AdventOfCode.Core

open System

type ConsoleLogger() =
    let _consoleLock = obj

    interface ILogger with
        member _.LogError(message: string) : unit =
            lock _consoleLock (fun () ->
                Console.ForegroundColor <- ConsoleColor.Red
                printf "ERROR: "

                Console.ForegroundColor <- ConsoleColor.White
                printfn $"{message}")

        member _.LogInfo(message: string) : unit =
            lock _consoleLock (fun () ->
                Console.ForegroundColor <- ConsoleColor.Green
                printf "INFO: "

                Console.ForegroundColor <- ConsoleColor.White
                printfn $"{message}")

        member _.LogWarning(message: string) : unit =
            lock _consoleLock (fun () ->
                Console.ForegroundColor <- ConsoleColor.Yellow
                printf "WARN: "

                Console.ForegroundColor <- ConsoleColor.White
                printfn $"{message}")
