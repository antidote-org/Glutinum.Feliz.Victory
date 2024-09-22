module Demo.Pages.VictoryLine.Component

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
        Name = "Area"
    },
    Cmd.none

let update msg model =
    match msg with
    | _ -> model, Cmd.none

type Data1 =
    {
        x: int
        y: int
        y0: int
    }

    static member inline create x y y0 =
        {
            x = x
            y = y
            y0 = y0
        }

let private data =
    [
        Data1.create 1 2 0
        Data1.create 2 3 1
        Data1.create 3 5 1
        Data1.create 4 4 2
        Data1.create 5 6 2
    ]

let view (model: Model) (dispatch: Dispatch<Msg>) =
    Html.div [
        VictoryChart [
            victoryChart.custom "domainPadding" 20
            victoryChart.children [
                VictoryBar [
                    VictoryBar.data data
                    VictoryBar.barRatio 0.8
                    VictoryBar.style [
                        VictoryStyleInterface.data [
                            style.fill "#c43a31"
                        ]
                    ]
                ]
            ]
        ]
        |> Html.previewChart
    ]
    |> Html.demoPage "VictoryLine"
