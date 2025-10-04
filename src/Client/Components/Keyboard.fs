module Keyboard

open Feliz
open Elmish

type Model = string

type Msg =
    | KeyPressed of string
    | EnterPressed
    | DeletePressed

let init () = "", Cmd.none

let update msg model =
    match msg with
    | KeyPressed key -> key, Cmd.none

let root model dispatch =
    Html.div [
        prop.className "inline-flex rounded-md p-1"
        prop.children [
            Html.button [
                prop.className "btn-keyboard"
                prop.onClick (fun _ -> KeyPressed model |> dispatch)
                prop.text (sprintf "%s" model)
            ]
        ]
    ]