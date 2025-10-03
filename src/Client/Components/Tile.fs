module Tile

open Feliz

let root model dispatch =
    Html.div [
            prop.className "inline-flex rounded-md p-2 sm:p-4"
            prop.children [
                Html.p [
                    prop.className "text-black text-base sm:text-lg mb-2"
                    prop.text "Your Todos:"
                ]
            ]
        ]