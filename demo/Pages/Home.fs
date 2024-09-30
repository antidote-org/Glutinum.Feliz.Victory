module Demo.Pages.Home

open Feliz
open Glutinum.Feliz.Victory
open Demo.Html

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
    ]

let private data2013 =
    [
        QuarterData.Create 1 15000
        QuarterData.Create 2 12500
        QuarterData.Create 3 19500
        QuarterData.Create 4 13000
    ]

let private data2014 =
    [
        QuarterData.Create 1 11500
        QuarterData.Create 2 13250
        QuarterData.Create 3 20000
        QuarterData.Create 4 15500
    ]

let private data2015 =
    [
        QuarterData.Create 1 18000
        QuarterData.Create 2 13250
        QuarterData.Create 3 15000
        QuarterData.Create 4 12000
    ]

[<ReactComponent>]
let private DemoChart () =
    VictoryChart [
        victoryChart.domainPadding 20
        victoryChart.theme VictoryTheme.material
        victoryChart.children [
            VictoryAxis [
                victoryAxis.tickValues [
                    box 1
                    2
                    3
                    4
                ]
                victoryAxis.tickFormat [
                    box "Q1"
                    "Q2"
                    "Q3"
                    "Q4"
                ]
            ]
            VictoryAxis [
                victoryAxis.dependentAxis true
                victoryAxis.tickFormat (fun value i _ ->
                    let value: int = unbox value
                    $"${value / 1000}k"
                )
            ]
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
    |> Html.previewChart

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

        DemoChart()

        Html.h2 "Installation: "
        Html.pre [
            prop.className missingCss.box
            prop.children [
                Html.strong [
                    prop.className [
                        missingCss.titlebar
                        missingCss.block
                    ]
                    prop.text ".NET CLI"
                ]
                Html.code [
                    prop.className "language-bash"
                    prop.text
                        """
dotnet add package Glutinum.Feliz.Victory"""
                ]
            ]
        ]
        Html.pre [
            prop.className missingCss.box
            prop.children [
                Html.strong [
                    prop.className [
                        missingCss.titlebar
                        missingCss.block
                    ]
                    prop.text "NPM CLI"
                ]
                Html.code [
                    prop.className "language-bash"
                    prop.text
                        """
npm install victory"""
                ]
            ]
        ]

        Html.h2 "Usage: "
        Html.pre [
            prop.className missingCss.box
            prop.children [
                Html.strong [
                    prop.className [
                        missingCss.titlebar
                        missingCss.block
                    ]
                    prop.text "F# code"
                ]
                Html.code [
                    prop.className "language-fsharp"
                    prop.text
                        """
open Glutinum.Feliz.Victory
open type Glutinum.Feliz.Victory.Exports

VictoryChart [
    victoryChart.domainPadding 20
    victoryChart.theme VictoryTheme.material
    victoryChart.children [
        VictoryAxis [
            victoryAxis.tickValues [ box 1; 2; 3; 4 ]
            victoryAxis.tickFormat [ box "Q1"; "Q2"; "Q3"; "Q4" ]
        ]
        VictoryAxis [
            victoryAxis.dependentAxis true
            victoryAxis.tickFormat (fun value i _ ->
                let value : int = unbox value
                $"${value / 1000}k"
            )
        ]
        VictoryBar [
            victoryBar.barRatio 0.8
            victoryBar.alignment VictoryBarAlignmentType.start
            victoryBar.data data
        ]
    ]
]"""
                ]
            ]
        ]
    ]
