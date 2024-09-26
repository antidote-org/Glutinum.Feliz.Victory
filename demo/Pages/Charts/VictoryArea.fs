module Demo.Pages.Charts.VictoryArea.Component

open Demo.Html
open Demo.Components
open Feliz
open Glutinum.Feliz.Victory

open type Glutinum.Feliz.Victory.Exports

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

let private simple =
    VictoryChart [
        victoryChart.children [
            VictoryArea [
                victoryArea.data [
                    Data1.create 1 2 0
                    Data1.create 2 3 1
                    Data1.create 3 5 1
                    Data1.create 4 4 2
                    Data1.create 5 6 2
                ]
            ]
        ]
    ]
    |> Html.previewChart

let private pageContent =
    [
        "Demo", simple
    ]

let tableOfContents = Sidebar.tableOfContents pageContent

let view =
    pageContent
    |> List.map (fun (title, content) -> renderExample title content)
    |> Html.div
    |> renderDemoPage "VictoryBar"
