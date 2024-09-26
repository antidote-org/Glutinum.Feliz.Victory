module Demo.Pages.Containers.VictoryChart.Component


open Demo.Components
open Demo.Html
open Feliz
open Glutinum.Feliz.Victory

open type Glutinum.Feliz.Victory.Exports

let private simple =
    VictoryChart [
        victoryChart.innerRadius 50
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
