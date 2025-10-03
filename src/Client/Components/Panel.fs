module Panel

open Feliz

let root index (model: string list) dispatch =
    Html.div [
        prop.className "my-2"
        prop.children [
            for tile in model do
                Tile.root tile dispatch
        ]
    ]