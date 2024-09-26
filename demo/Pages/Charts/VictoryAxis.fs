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
                VictoryAxis.crossAxis true
                VictoryAxis.height size
                VictoryAxis.width size
                VictoryAxis.standalone false
                VictoryAxis.offsetY (size / 2.0)
                VictoryAxis.domain ((-10.0, 10.0))
                VictoryAxis.theme VictoryTheme.material
            ]
            VictoryAxis [
                VictoryAxis.crossAxis true
                VictoryAxis.dependentAxis true
                VictoryAxis.height size
                VictoryAxis.width size
                VictoryAxis.standalone false
                VictoryAxis.offsetX (size / 2.0)
                VictoryAxis.domain ((-10.0, 10.0))
                VictoryAxis.theme VictoryTheme.material
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
