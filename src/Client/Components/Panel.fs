module Panel

open Feliz

let root (attemptIndex: int) (model: string list) dispatch =
    Html.div [
        prop.className "my-2"
        prop.children [
            model
            |> List.mapi (fun tileIndex tile ->
                Tile.root attemptIndex tileIndex tile dispatch
            )
            |> Html.div
        ]
    ]