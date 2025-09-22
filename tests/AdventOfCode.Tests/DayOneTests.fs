namespace AdventOfCode.Tests

open AdventOfCode.Core
open AdventOfCode.Solvers.DayOne
open NUnit.Framework

module ``Day 1: Historian Hysteria Tests`` =
    [<Test>]
    let ``Can correctly calculate list distance for example lists`` () =
        let solver = new HistorianHysteriaSolver() :> IAdventSolver<HistorianListPair, int>
        let listOne = [| 3; 4; 2; 1; 3; 3 |]
        let listTwo = [| 4; 3; 5; 3; 9; 3 |]
        let lists = HistorianListPair.create listOne listTwo

        let expected = 11
        let actual = solver.SolveAsync lists |> Async.AwaitTask |> Async.RunSynchronously

        Assert.That(actual, Is.EqualTo expected)
