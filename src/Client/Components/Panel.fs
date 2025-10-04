module Panel

open Feliz

let root (letter:string)  (attemptIndex: int) (model: string list) dispatch =
    let tiles =
        model
        |> Seq.mapi (fun tileIndex tile ->
            if attemptIndex = 0 && tileIndex = 0  then
                Tile.root letter attemptIndex tileIndex model dispatch
            else
                Tile.root "" attemptIndex tileIndex tile dispatch
        )
    Html.div [
        prop.className "flex my-2"
        tiles |> prop.children
    ]