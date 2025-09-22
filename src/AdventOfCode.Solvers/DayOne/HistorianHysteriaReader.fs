namespace AdventOfCode.Solvers.DayOne

open AdventOfCode.Core
open System.IO
open System.Threading.Tasks

type HistorianHysteriaReader() =
    interface IInputReader<string, HistorianListPair> with
        member _.ReadInputAsync(info: string) : Task<HistorianListPair> =
            task {
                let! text = File.ReadAllTextAsync info

                let leftList, rightList =
                    text.Split "\n"
                    |> Array.map (fun textPair ->
                        let pairArr = textPair.Split "   "
                        int pairArr[0], int pairArr[1])
                    |> Array.unzip

                return HistorianListPair.create leftList rightList
            }
