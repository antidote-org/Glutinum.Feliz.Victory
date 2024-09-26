module Demo.Pages.Charts.VictoryPie.Component

open Demo
open Demo.Html
open Elmish
open Feliz
open Glutinum.Feliz.Victory

open type Glutinum.Feliz.Victory.Exports

type Model =
    {
        Name: string
    }

type Msg = | NoOp

let init () =
    {
        Name = "Pie"
    },
    Cmd.none

let update msg model =
    match msg with
    | _ -> model, Cmd.none

type Data1 =
    {
        x: int
        y: int
    }

    static member inline create x y =
        {
            x = x
            y = y
        }

let private data =
    [
        Data1.create 1 2
        Data1.create 2 3
        Data1.create 3 5
        Data1.create 4 4
        Data1.create 5 7
    ]

let view (model: Model) (dispatch: Dispatch<Msg>) =
    Html.div [
        VictoryPie [
            VictoryPie.data data
            VictoryPie.labels (fun (args : CallbackArgs<Data1>) ->
                match args.datum with
                | Some datum -> string datum.y
                | None -> ""
            )
            VictoryPie.innerRadius 10
            VictoryPie.cornerRadius 20
        ]
        |> Html.previewChart
    ]
    |> renderDemoPage "VictoryLine"
