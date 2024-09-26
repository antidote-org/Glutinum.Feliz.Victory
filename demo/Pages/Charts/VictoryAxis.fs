module Demo.Pages.Charts.VictoryAxis.Component

open Demo.Components
open Feliz
open Glutinum.Feliz.Victory
open Demo.Html

open type Glutinum.Feliz.Victory.Exports

let private demo =
    let size = 400.0

    Svg.svg [
        svg.width size
        svg.height size
        svg.children [
            VictoryAxis [
                victoryAxis.crossAxis true
                victoryAxis.height size
                victoryAxis.width size
                victoryAxis.standalone false
                victoryAxis.offsetY (size / 2.0)
                victoryAxis.domain ((-10.0, 10.0))
                victoryAxis.theme VictoryTheme.material
            ]
            VictoryAxis [
                victoryAxis.crossAxis true
                victoryAxis.dependentAxis true
                victoryAxis.height size
                victoryAxis.width size
                victoryAxis.standalone false
                victoryAxis.offsetX (size / 2.0)
                victoryAxis.domain ((-10.0, 10.0))
                victoryAxis.theme VictoryTheme.material
            ]
        ]
    ]
    |> Html.previewChart

let private pageContent =
    [
        "Demo", demo
    ]

let tableOfContents = Sidebar.tableOfContents pageContent

let view =
    pageContent
    |> List.map (fun (title, content) -> renderExample title content)
    |> Html.div
    |> renderDemoPage "VictoryAxis"
