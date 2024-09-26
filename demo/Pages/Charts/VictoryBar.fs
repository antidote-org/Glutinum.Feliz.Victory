module Demo.Pages.Charts.VictoryBar.Component

open System
open Demo.Components
open Elmish
open Feliz
open Glutinum.Feliz.Victory
open Demo.Html
open Browser

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

type DataWithCategories =
    {
        x: string
        y: int
    }

    static member inline create x y =
        {
            x = x
            y = y
        }

let dataWithCategories =
    [
        DataWithCategories.create "cats" 1
        DataWithCategories.create "dogs" 2
        DataWithCategories.create "birds" 3
        DataWithCategories.create "fish" 2
        DataWithCategories.create "frogs" 1
    ]

let private alignment =
    VictoryChart [
        victoryChart.custom "theme" VictoryTheme.material
        victoryChart.children [
            VictoryBar [
                victoryBar.data data
                victoryBar.barRatio 0.8
                victoryBar.style [
                    VictoryStyleInterface.data [
                        style.fill "#c43a31"
                    ]
                ]
                victoryBar.alignment VictoryBarAlignmentType.start
            ]
        ]
    ]
    |> Html.previewChart

[<ReactComponent>]
let private animate () =
    let getData () =
        let pointsCount = Random().Next(5, 10)

        [
            for pointsCount in 1..pointsCount do
                yield Data1.create pointsCount (Random().Next(1, 20)) 0
        ]

    let data, setData = React.useState (getData ())

    React.useEffect (
        fun () -> window.setInterval ((fun () -> setData (getData ())), 3000) |> ignore
        , [||]
    )

    VictoryChart [
        victoryChart.custom "theme" VictoryTheme.material
        victoryChart.children [
            VictoryBar [
                victoryBar.custom
                    "animate"
                    {|
                        duration = 2000
                        onLoad =
                            {|
                                duration = 1000
                            |}
                    |}
                victoryBar.barRatio 0.8
                victoryBar.alignment VictoryBarAlignmentType.start
                victoryBar.data data
            ]
        ]
    ]
    |> Html.previewChart

let private pageContent =
    [
        "Alignment", alignment
        "Animate", animate ()
    ]

let tableOfContents = Sidebar.tableOfContents pageContent

let view (model: Model) (dispatch: Dispatch<Msg>) =
    pageContent
    |> List.map (fun (title, content) -> renderExample title content)
    |> Html.div
    |> renderDemoPage "VictoryBar"
