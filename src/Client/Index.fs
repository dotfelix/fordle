module Index

open Elmish
open SAFE
open Shared

type Model = {
    Todos: RemoteData<Todo list>
    Input: string
}

type Msg =
    | SetInput of string
    | LoadTodos of ApiCall<unit, Todo list>
    | SaveTodo of ApiCall<string, Todo list>

let todosApi = Api.makeProxy<ITodosApi> ()

let init () = 0, Cmd.none

let update msg model =
    0, Cmd.none

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

let view model dispatch =
    Html.div [
            prop.className "h-screen w-screen flex flex-col items-center justify-center"
            prop.children [
                Html.div [
                    prop.className "p-6 m-4"
                    prop.children [
                        Tile.root model dispatch
                    ]
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
