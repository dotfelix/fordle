module Index

open Elmish
open SAFE
open Shared

type Model = {
    Attempt: int
    Rows: string list list
}

let init () =
    let initailState = {
        Attempt = 1
        Rows = List.replicate 6 (List.replicate 5 "" )
    }
    initailState, Cmd.none

let update msg model =
    let updateState ={
        Attempt = model.Attempt
        Rows = model.Rows
    }
    updateState, Cmd.none

open Feliz

let topKeyboardChars = [
    "q"; "w"; "e"; "r"; "t"; "y"; "u"; "i"; "o"; "p"
]
let middleKeyboardChars = [
    "a"; "s"; "d"; "f"; "g"; "h"; "j"; "k"; "l"
]
let bottomKeyboardChars = [
    "enter"; "z"; "x"; "c"; "v"; "b"; "n"; "m"; "delete"
]

let view (model: Model) dispatch =
    Html.div [
            prop.className "h-screen w-screen flex flex-col items-center justify-center min-w-[560px]"
            prop.children [
                Html.div [
                    prop.children [
                        for row in model.Rows do
                            Panel.root 0 row dispatch
                    ]
                ]

                Html.div [
                    prop.className "m-4"
                ]
                Html.div [
                    prop.className ""
                    prop.children [
                        for keyChar in topKeyboardChars do
                            Keyboard.root keyChar dispatch
                    ]
                ]
                Html.div [
                    prop.className ""
                    prop.children [
                        for keyChar in middleKeyboardChars do
                            Keyboard.root keyChar dispatch
                    ]
                ]
                Html.div [
                    prop.className ""
                    prop.children [
                        for keyChar in bottomKeyboardChars do
                            Keyboard.root keyChar dispatch
                    ]
                ]

            ]
        ]
