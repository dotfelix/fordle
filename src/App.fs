module App

open Elmish
open Elmish.Navigation
open Elmish.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Elmish.React
open Elmish.Debug
open Elmish.HMR

importSideEffects "../sass/main.sass"

type Model = int

type Msg =
    | Increment
    | Decrement

let init () = 0

let update (msg: Msg) count =
    match msg with
    | Increment -> count + 1
    | Decrement -> count - 1

let view model dispatch =
    div
        [ ClassName "container" ]
        [ div
              [ ClassName "section" ]
              [ div
                    [ ClassName "columns is-mobile" ]
                    [ div
                          [ ClassName "column is-half is-offset-one-quarter" ]
                          [ button [ OnClick(fun _ -> dispatch Decrement) ] [ str "-" ]
                            div [] [ str (sprintf "%A" model) ]
                            button [ OnClick(fun _ -> dispatch Increment) ] [ str "+" ] ] ] ] ]

// App
Program.mkSimple init update view
#if DEBUG
|> Program.withDebugger
#endif
|> Program.withReactBatched "elmish-app"
|> Program.run
