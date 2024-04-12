module Demo

open Glutinum.Feliz.Victory
open Feliz
open Browser.Dom
open Fable.Core.JsInterop

open type Glutinum.Feliz.Victory.Exports

let data =
    [
        {|
            x = 1
            y = 2
            y0 = 0
        |}
        {|
            x = 2
            y = 3
            y0 = 1
        |}
        {|
            x = 3
            y = 5
            y0 = 1
        |}
        {|
            x = 4
            y = 4
            y0 = 2
        |}
        {|
            x = 5
            y = 6
            y0 = 2
        |}
    ]

let dataWithCategories =
    [
        {|
            x = "cats"
            y = 1
        |}
        {|
            x = "dogs"
            y = 2
        |}
        {|
            x = "birds"
            y = 3
        |}
        {|
            x = "fish"
            y = 2
        |}
        {|
            x = "frogs"
            y = 1
        |}
    ]

let categories =
    ResizeArray [
        "dogs"
        "birds"
        "cats"
        "fish"
        "frogs"
    ]

[<ReactComponent>]
let private Component () =
    Html.div [
        prop.style [
            style.width (length.rem 50)
            style.height (length.rem 50)
        ]
        prop.children [
        //     VictoryChart [
        //         victoryChart.custom "domainPadding" {| x = 20 |}
        //         victoryChart.children [
        //             // VictoryArea [
        //             //     // victoryArea.domain ((1.0, 50.0))
        //             //     VictoryArea.data data
        //             //     VictoryArea.labels (
        //             //         fun o ->
        //             //             o?datum?y |> unbox<string> |> Some
        //             //     )
        //             //     VictoryArea.style [
        //             //         VictoryStyleInterface.data [
        //             //             style.fill "#c43a31"
        //             //         ]
        //             //     ]
        //             // ]
        //             // VictoryBar [
        //             //     VictoryBar.data data
        //             //     VictoryBar.barRatio 0.8
        //             //     VictoryBar.style [
        //             //         VictoryStyleInterface.data [
        //             //             style.fill "#c43a31"
        //             //         ]
        //             //     ]
        //             // ]
        //             VictoryBar [
        //                 // VictoryBar.categories (
        //                 //     CategoryPropType.op_Implicit (
        //                 //         ResizeArray [
        //                 //             "cats"
        //                 //             "dogs"
        //                 //             "birds"
        //                 //             "fish"
        //                 //             "frogs"
        //                 //         ]
        //                 //     )
        //                 // )
        //                 VictoryBar.custom "categories" categories
        //                 VictoryBar.data dataWithCategories
        //             ]
        //         ]
        //     ]
        // ]
            VictoryChart [
                victoryChart.custom "domainPadding" {| x = 25 |}
                victoryChart.children [
                    VictoryBar [
                        VictoryBar.data dataWithCategories
                    ]
                ]

            ]
        ]
    ]

ReactDOM.createRoot(document.getElementById ("root")).render (Component())
