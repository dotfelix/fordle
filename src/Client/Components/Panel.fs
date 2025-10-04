module Panel

open Feliz

type Model = string list

let root model dispatch =
    let tiles =
        model
        |> Seq.map (fun tile ->
            Tile.root tile dispatch
        )
    Html.div [
        prop.className "flex my-2"
        tiles |> prop.children
    ]