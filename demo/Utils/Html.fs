module Demo.Html

open Feliz
open Demo.Components
open type Demo.Components.Components

let previewChart (child: ReactElement) =
    Html.div [
        // prop.className missingCss.textcolumns
        prop.style [
            unbox ("columns", 2)
            style.display.grid
            style.gridTemplateColumns [ length.fr 1; length.fr 1 ]
        ]
        prop.children [
            Html.div [
                prop.className missingCss.box
                prop.style [
                    style.marginTop (length.px 0)
                    style.width (length.px 500)
                ]
                prop.children [
                    child
                ]
            ]
//             Code """let test = 42

// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42
// let test = 42""" "fsharp"
        ]
    ]

let demoPage (title: string) (content: ReactElement) =
    React.fragment [
        Html.h1 [
            prop.text title
        ]
        content
    ]
