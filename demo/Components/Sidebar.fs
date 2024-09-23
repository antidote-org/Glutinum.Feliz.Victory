module Demo.Components.Sidebar

open Feliz

let link (route: Router.Route) (label: string) =
    Html.li [
        Html.a [
            prop.text label
            Router.href route
        ]
    ]

let category (label: string) (links: ReactElement list) =
    Html.li [
        Html.p [
            prop.className missingCss.bold
            prop.text label
        ]
        Html.ul [
            prop.role "list"
            prop.className missingCss.margin
            prop.children links
        ]
    ]
