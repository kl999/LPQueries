<Query Kind="FSharpProgram">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

let rnd = new Random()

let a = [1..100002] |> List.map (fun i -> rnd.Next(500))

//a |> Dump

let sw = new Stopwatch()

sw.Restart()

sw

let newLen = a.Length / 3

let newA = [|1..newLen|] //|> Dump

let mutable sum = 0

for i in 0..a.Length - 1 do
    sum <- sum + a.[i]
    if (i + 1) % 3 = 0 then
        newA.[(i + 1) / 3 - 1] <- sum
        sum <- 0

sw.Stop()

sw |> Dump

sum |> Dump

newA.Dump("new")