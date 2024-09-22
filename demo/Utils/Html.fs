module Demo.Html

open Feliz

let previewChart (child: ReactElement) =
    Html.div [
        prop.className missingCss.box
        prop.style [
            style.width (length.px 500)
        ]
        prop.children [
            child
        ]
    ]

let demoPage (title: string) (content: ReactElement) =
    React.fragment [
        Html.h1 [
            prop.text title
        ]
        content
    ]
