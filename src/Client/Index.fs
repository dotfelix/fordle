module Index

open Elmish

type Model = { Attempt: int; WordIndex : int; Rows: string list list ; KeyPress: Keyboard.Model }

type Msg =
    | NoOp
    | KeyPressedMsg of Keyboard.Msg

let init () =
    let kbKey, kbCmd = Keyboard.init()

    let initailState = {
        Attempt = 0
        WordIndex = 0
        Rows = List.replicate 6 (List.replicate 5 "")
        KeyPress = kbKey
    }

    initailState, Cmd.batch [
        Cmd.map KeyPressedMsg kbCmd
    ]

let update msg model =
    match msg with
    | KeyPressedMsg kbMsg ->
        let k, cmd = Keyboard.update kbMsg model
        { model with KeyPress = k}, cmd
    | NoOp -> model, Cmd.none

open Feliz

let topKeyboardChars = [ "q"; "w"; "e"; "r"; "t"; "y"; "u"; "i"; "o"; "p" ]
let middleKeyboardChars = [ "a"; "s"; "d"; "f"; "g"; "h"; "j"; "k"; "l" ]
let bottomKeyboardChars = [ "enter"; "z"; "x"; "c"; "v"; "b"; "n"; "m"; "delete" ]

let view model dispatch =
    Html.div [
        prop.className "h-screen w-screen flex flex-col items-center justify-center min-w-[560px]"
        prop.children [
            Html.div [
                prop.children [
                    model.Rows
                    |> List.mapi (fun i row -> Panel.root model.KeyPress i row dispatch)
                    |> Html.div
                ]
            ]

            Html.div [ prop.className "m-4" ]
            Html.div [
                prop.className ""
                prop.children [
                    topKeyboardChars
                    |> List.map (fun key -> Keyboard.root key (KeyPressedMsg >> dispatch))
                    |> Html.div
                ]
            ]
            Html.div [
                prop.className ""
                prop.children [
                    middleKeyboardChars
                    |> List.map (fun key -> Keyboard.root key (KeyPressedMsg >> dispatch))
                    |> Html.div
                ]
            ]
            Html.div [
                prop.className ""
                prop.children [
                    bottomKeyboardChars
                    |> List.map (fun key -> Keyboard.root key (KeyPressedMsg >> dispatch))
                    |> Html.div
                ]
            ]
        ]
    ]