module Keyboard

open Feliz

let root model dispatch =
    Html.div [
            prop.className "inline-flex rounded-md p-1"
            prop.children [
                Html.button [
                    prop.className "btn-keyboard"
                    prop.onClick (fun _ -> dispatch (printf "%s" model))
                    prop.text (sprintf "%s" model)
                ]
            ]
        ]