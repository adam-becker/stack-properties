module AwesomeStack.Properties.StackProperties

open Expecto
open Hedgehog

open AwesomeStack

let testProperty name property = testCase name (fun () ->
  Property.checkBool property
)

let capacityGen = Gen.int (Range.linear 1 100)

let emptyStackGen : Gen<Stack<int>> =
  capacityGen
  |> Gen.map (fun capacity -> Stack.Empty(capacity))

let fullStackGen : Gen<Stack<int>> =
  capacityGen
  |> Gen.map (fun capacity -> Stack.Full(capacity))

let halfFullStackGen : Gen<Stack<int>> = gen {
  let! count = Gen.int (Range.linear 1 100)
  let capacity = count * 2
  let stack = Stack.Empty(capacity)

  for i in 1 .. count do
    stack.Push(i)

  return stack
}

let all =
  testList "stack" [
    testProperty "empty stack is always empty." <| property {
      let! stack = emptyStackGen
      stack.IsEmpty
    }

    testProperty "full stack is always full." <| property {
      let! stack = fullStackGen
      stack.IsFull
    }

    testProperty "pushing N times onto an empty stack with capacity N fills the stack." <| property {
      let! stack = emptyStackGen

      for i in 1 .. stack.Capacity do
        stack.Push(i)
      
      stack.IsFull
    }

    testProperty "popping N times from a full stack with capacity N drains the stack." <| property {
      let! stack = fullStackGen

      for _ in 1 .. stack.Capacity do
        stack.Pop() |> ignore<int>
      
      stack.IsEmpty
    }

    testProperty "push increments count by 1." <| property {
      let! stack = halfFullStackGen
      let count = stack.Count
      stack.Push(0)
      stack.Count = count + 1
    }

    testProperty "pop decrements count by 1." <| property {
      let! stack = halfFullStackGen
      let count = stack.Count
      stack.Pop() |> ignore<int>
      stack.Count = count - 1
    }
  ]
