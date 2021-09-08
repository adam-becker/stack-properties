module AwesomeStack.Properties.Program

open Expecto

let tests =
  testList "all"
    [ StackProperties.all
    ]

[<EntryPoint>]
let main argv =
  runTestsWithArgs defaultConfig argv tests
