module Demo.Pages.Containers.VictoryChart.Component

open Demo
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
        VictoryChart [
            VictoryChart.innerRadius 50
        ]
        |> Html.previewChart
    ]
    |> Html.demoPage "VictoryLine"


// open Fable.Core
// open Fable.Core.JsInterop

// Fable.Core.JS.console.log(import "Background" "victory")
