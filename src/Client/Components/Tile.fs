module Tile

open Feliz

let root model dispatch =
    Html.div [
            prop.className "inline-flex rounded-md mx-1 box-border"
            prop.children [
                Html.div [
                    prop.className "tile-default"
                    prop.text (sprintf "%s" model)
                ]
            ]
        ]