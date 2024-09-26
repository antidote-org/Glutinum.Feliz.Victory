module Demo.Pages.Charts.VictoryPie.Component

open Demo.Components
open Demo.Html
open Feliz
open Glutinum.Feliz.Victory

open type Glutinum.Feliz.Victory.Exports

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

let private simple =
    Html.div [
        VictoryPie [
            victoryPie.data data
            victoryPie.labels (fun (args : CallbackArgs<Data1>) ->
                match args.datum with
                | Some datum -> string datum.y
                | None -> ""
            )
            victoryPie.innerRadius 10
            victoryPie.cornerRadius 20
        ]
        |> Html.previewChart
    ]
    |> renderDemoPage "VictoryLine"


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
