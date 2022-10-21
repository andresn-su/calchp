open System

let options = [| 
    "1 - Sum";
    "2 - Subtraction";
    "9 - Options" // Like changing the extreme values
|]

(*
    Generate random numbers
*)
type System.Random with
    member this.GetValues (min, max) = 
        Seq.initInfinite (fun _-> this.Next(min, max))

let pair (a, b) = (System.Random()).GetValues(a, b) |> Seq.take 1

(*
    Selects the extreme values for that operation
*)
let extremes =
    printf "Type the minimum value: "
    let minimum = System.Console.ReadLine()
    printf "Type the maximum value: "
    let maximum = System.Console.ReadLine()
    (int minimum, int maximum)

(* The sum function *)
let sum = Seq.sum (pair extremes)

let select = 
    let menu = options |> Array.map (fun x -> printfn "%s" x)
    System.Console.ReadLine()
    
// Runs the opts
let rec run opt = 
    match opt with
    | "1" -> 
        printfn "Your choose: summation..."
        sum
    | _ ->
        printfn "This value is not avaiable"
        run opt

// Prints the result
printfn "%i" (run select)
