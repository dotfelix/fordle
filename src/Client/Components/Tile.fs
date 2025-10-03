module Tile

open Feliz

let root (attemptIndex: int) (tileIndex: int) model dispatch =
    Html.div [
            prop.className "inline-flex rounded-md mx-1"
            prop.children [
                Html.div [
                    prop.className "tile-default"
                    prop.text (sprintf "%s%s%s" ((string)attemptIndex) ((string)tileIndex) model)
                ]
            ]
        ]