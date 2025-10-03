module Keyboard

open Feliz

let root model dispatch =
    Html.div [
            prop.className "inline-flex rounded-md p-1"
            prop.children [
                Html.button [
                    prop.className "text-black sm:text-lg text-center uppercase bg-gray-200 px-4 py-2 rounded font-bold hover:bg-gray-300 hover:shadow-md"
                    prop.onClick (fun _ -> dispatch (sprintf "%s" model))
                    prop.text (sprintf "%s" model)
                ]
            ]
        ]