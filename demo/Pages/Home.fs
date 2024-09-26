module Demo.Pages.Home

open Feliz
open Glutinum.Feliz.Victory
open System
open Browser

open type Glutinum.Feliz.Victory.Exports

type QuarterData =
    {
        Quarter: int
        Earnings: int
    }

    static member inline Create quarter earnings =
        {
            Quarter = quarter
            Earnings = earnings
        }

let private data2012 =
    [
        QuarterData.Create 1 13000
        QuarterData.Create 2 16500
        QuarterData.Create 3 14250
        QuarterData.Create 4 19000
    ];

let private data2013 =
    [
        QuarterData.Create 1 15000
        QuarterData.Create 2 12500
        QuarterData.Create 3 19500
        QuarterData.Create 4 13000
    ];

let private data2014 =
    [
        QuarterData.Create 1 11500
        QuarterData.Create 2 13250
        QuarterData.Create 3 20000
        QuarterData.Create 4 15500
    ];

let private data2015 =
    [
        QuarterData.Create 1 18000
        QuarterData.Create 2 13250
        QuarterData.Create 3 15000
        QuarterData.Create 4 12000
    ];

[<ReactComponent>]
let private DemoChart() =
    VictoryChart [
        victoryChart.domainPadding 20
        victoryChart.custom "theme" VictoryTheme.material
        victoryChart.children [
            // VictoryAxis
            VictoryStack [
                victoryStack.colorScale ColorScalePropType.Case1.warm
                victoryStack.children [
                    VictoryBar [
                        victoryBar.data data2012
                        victoryBar.x "Quarter"
                        victoryBar.y "Earnings"
                    ]
                    VictoryBar [
                        victoryBar.data data2013
                        victoryBar.x "Quarter"
                        victoryBar.y "Earnings"
                    ]
                    VictoryBar [
                        victoryBar.data data2014
                        victoryBar.x "Quarter"
                        victoryBar.y "Earnings"
                    ]
                    VictoryBar [
                        victoryBar.data data2015
                        victoryBar.x "Quarter"
                        victoryBar.y "Earnings"
                    ]
                ]
            ]
        ]
    ]

let render () =
    Html.div [
        Html.h1 "Getting Started"

        Html.p [
            Html.text "Bindings for the "
            Html.a [
                prop.href "https://commerce.nearform.com/open-source/victory"
                prop.text "Victory charting library"
            ]
        ]
        Html.p "Victory is a collection of React composable charting components"

        Html.div [
            prop.className missingCss.box
            prop.style [
                style.width (length.px 400)
            ]

            prop.children [
                DemoChart()
            ]
        ]
    ]
