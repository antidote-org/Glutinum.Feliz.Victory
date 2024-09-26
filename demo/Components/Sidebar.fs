module Demo.Components.Sidebar

open Feliz

let link (activeRoute : Router.Route option) (route: Router.Route) (label: string) =
    Html.li [
        Html.a [
            prop.className [
                if activeRoute = Some route then
                    "is-active"
            ]
            prop.text label
            Router.href route
        ]
    ]

let linkWithToc (activeRoute : Router.Route option) (route: Router.Route) (label: string) (tableOfContents : ReactElement)=
    React.fragment [
        link activeRoute route label
        if activeRoute = Some route then
            tableOfContents
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

let tableOfContents (pageContent: (string * ReactElement) list) =
    Html.ul [
        prop.role "list"
        prop.className [
            missingCss.crowded
            missingCss.margin
            "table-of-contents"
        ]
        prop.children [
            pageContent
            |> List.map (fun (title, _) ->
                Html.li [
                    Html.a [
                        prop.href ("#" + title)
                        prop.text title
                    ]
                ]
            )
            |> React.fragment
        ]
    ]
