// For more information see https://aka.ms/fsharp-console-apps
open System
open System.IO

let lines = File.ReadAllLines(__SOURCE_DIRECTORY__ + "/samples/easy.txt")
let list = Seq.toList lines

let reduce x =
        x |> List.fold (fun m x -> match Map.tryFind x m with
                                   | None -> Map.add x 1 m
                                   | Some c -> Map.add x (c+1) m)
                       Map.empty

let result = reduce list
printfn "%A" result