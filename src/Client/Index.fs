module Index

open Elmish

type Model = {
    Attempt: int
    WordIndex: int
    Rows: string list list
    KeyPress: Keyboard.Model
}

type Msg =
    | KeyPressedMsg of Keyboard.Msg
    | EnterPressedMsg of Keyboard.Msg
    | DeletePressedMsg of Keyboard.Msg

let init () =
    let kbKey, kbCmd = Keyboard.init ()

    let initailState = {
        Attempt = 0
        WordIndex = 0
        Rows = List.replicate 6 (List.replicate 5 "")
        KeyPress = kbKey
    }

    initailState, Cmd.batch [ Cmd.map KeyPressedMsg kbCmd ]

let update msg model =
    match msg with
    | KeyPressedMsg kbMsg ->
        if model.WordIndex >= 5 then
            model, Cmd.none
        else
            let k, cmd = Keyboard.update kbMsg model
            let rows =
                model.Rows
                |> List.mapi (fun outerIndex row ->
                    if outerIndex = model.Attempt then
                        row |> List.mapi (fun innerIndex oldChar ->
                            if innerIndex = model.WordIndex then k
                            else oldChar)
                    else
                        row
                )

            { model
                with
                Rows = rows
                KeyPress = k
                WordIndex = model.WordIndex + 1
            }, cmd

    | EnterPressedMsg _ ->
        if model.WordIndex < 5 then
            model, Cmd.none
        else
            { model with Attempt = model.Attempt + 1; WordIndex = 0 }, Cmd.none

    | DeletePressedMsg _ ->
        let wordIndex = model.WordIndex - 1

        if model.WordIndex <= 0 then
            model, Cmd.none
        else
            let rows =
                model.Rows
                |> List.mapi (fun outerIndex row ->
                    if outerIndex = model.Attempt then
                        row |> List.mapi (fun innerIndex oldChar ->
                            if innerIndex = wordIndex then ""
                            else oldChar)
                    else
                        row
                )
            { model with
                Rows = rows
                WordIndex = wordIndex
            }, Cmd.none

open Feliz

let topKeyboardChars = [ "q"; "w"; "e"; "r"; "t"; "y"; "u"; "i"; "o"; "p" ]
let middleKeyboardChars = [ "a"; "s"; "d"; "f"; "g"; "h"; "j"; "k"; "l" ]
let bottomKeyboardChars = [ "z"; "x"; "c"; "v"; "b"; "n"; "m" ]

let view model dispatch =
    Html.div [
        prop.className "h-screen w-screen flex flex-col items-center justify-center min-w-[560px]"
        prop.children [
            Html.div [
                model.Rows
                |> List.map (fun row ->
                    Panel.root row dispatch
                )
                |> prop.children
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
                    let mapKeys =
                        bottomKeyboardChars
                        |> List.map (fun key -> Keyboard.root key (KeyPressedMsg >> dispatch))

                    (Keyboard.root "enter" (EnterPressedMsg >> dispatch))
                    :: mapKeys
                    @ [Keyboard.root "delete" (DeletePressedMsg >> dispatch)]
                    |> Html.div
                ]
            ]
        ]
    ]