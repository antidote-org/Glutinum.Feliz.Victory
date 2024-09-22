module Demo.Index

open Glutinum.Feliz.Victory
open Feliz
open Browser.Dom
open Fable.Core
open Elmish

[<ImportDefault("./Index.module.css")>]
let private classes: CssModules.Index = nativeOnly

module VictoryArea = Pages.VictoryArea.Component
module VictoryBar = Pages.VictoryBar.Component
module VictoryLine = Pages.VictoryLine.Component

[<RequireQualifiedAccess>]
[<NoComparison>]
type Page =
    | Home
    | VictoryArea of VictoryArea.Model
    | VictoryBar of VictoryBar.Model
    | VictoryLine of VictoryLine.Model
    | NotFound

[<NoComparison>]
type Msg =
    | SetRoute of Router.Route option
    | VictoryAreaMsg of VictoryArea.Msg
    | VictoryBarMsg of VictoryBar.Msg
    | VictoryLineMsg of VictoryLine.Msg

[<NoComparison>]
type Model =
    {
        CurrentRoute: Router.Route option
        ActivePage: Page
    }

let private setRoute (optRoute: Router.Route option) (model: Model) =
    let model =
        { model with
            CurrentRoute = optRoute
        }

    match optRoute with
    | None ->
        { model with
            ActivePage = Page.NotFound
        },
        Cmd.none

    | Some route ->
        match route with
        | Router.Route.VictoryArea ->
            let (subModel, subCmd) = VictoryArea.init ()

            { model with
                ActivePage = Page.VictoryArea subModel
            },
            Cmd.map VictoryAreaMsg subCmd

        | Router.Route.Home ->
            { model with
                ActivePage = Page.Home
            },
            Cmd.none

        | Router.Route.VictoryBar ->
            let (subModel, subCmd) = VictoryBar.init ()

            { model with
                ActivePage = Page.VictoryBar subModel
            },
            Cmd.map VictoryBarMsg subCmd

        | Router.Route.VictoryLine ->
            let (subModel, subCmd) = VictoryLine.init ()

            { model with
                ActivePage = Page.VictoryLine subModel
            },
            Cmd.map VictoryLineMsg subCmd

        | Router.Route.NotFound ->
            { model with
                ActivePage = Page.NotFound
            },
            Cmd.none

let private update (msg: Msg) (model: Model) =
    match msg with
    | SetRoute optRoute -> setRoute optRoute model

    | VictoryAreaMsg subMsg ->
        match model.ActivePage with
        | Page.VictoryArea subModel ->
            VictoryArea.update subMsg subModel
            |> Tuple.mapFirst Page.VictoryArea
            |> Tuple.mapFirst (fun page ->
                { model with
                    ActivePage = page
                }
            )
            |> Tuple.mapSecond (Cmd.map VictoryAreaMsg)

        | _ -> model, Cmd.none

    | VictoryBarMsg subMsg ->
        match model.ActivePage with
        | Page.VictoryBar subModel ->
            VictoryBar.update subMsg subModel
            |> Tuple.mapFirst Page.VictoryBar
            |> Tuple.mapFirst (fun page ->
                { model with
                    ActivePage = page
                }
            )
            |> Tuple.mapSecond (Cmd.map VictoryBarMsg)

        | _ -> model, Cmd.none

    | VictoryLineMsg subMsg ->
        match model.ActivePage with
        | Page.VictoryLine subModel ->
            VictoryLine.update subMsg subModel
            |> Tuple.mapFirst Page.VictoryLine
            |> Tuple.mapFirst (fun page ->
                { model with
                    ActivePage = page
                }
            )
            |> Tuple.mapSecond (Cmd.map VictoryLineMsg)

        | _ -> model, Cmd.none

let private init (location) =
    setRoute
        location
        {
            ActivePage = Page.Home
            CurrentRoute = None
        }

let private renderNavbar =
    Html.nav [
        Html.ul [
            Html.li [
                Html.strong "Glutinum.Feliz.Victory"
            ]
        ]
        Html.ul [
            Html.li [
                Html.a [
                    prop.text "Github"
                    prop.href "https://github.com/antidote-org/Glutinum.Feliz.Victory"
                ]
            ]
        ]
    ]

let private sidebarLink (route: Router.Route) (label: string) =
    Html.li [
        Html.a [
            prop.text label
            Router.href route
        ]
    ]

let private sidebarCategory (label: string) (links: ReactElement list) =
    Html.li [
        Html.p label
        Html.ul [
            prop.role "list"
            prop.className missingCss.margin
            prop.children links
        ]
    ]

let private renderPageContent (model: Model) (dispatch: Dispatch<Msg>) =
    match model.ActivePage with
    | Page.Home ->
        Html.div [
            prop.text "Home"
        ]

    | Page.NotFound ->
        Html.div [
            prop.text "Not Found"
        ]

    | Page.VictoryArea subModel -> VictoryArea.view subModel (VictoryAreaMsg >> dispatch)
    | Page.VictoryBar subModel -> VictoryBar.view subModel (VictoryBarMsg >> dispatch)
    | Page.VictoryLine subModel -> VictoryLine.view subModel (VictoryLineMsg >> dispatch)

let private view (model: Model) (dispatch: Dispatch<Msg>) =
    Html.div [
        prop.className [
            missingCss.``sidebar-layout``
            missingCss.fullscreen
        ]
        prop.children [
            Html.header [
                Html.ul [
                    prop.role "list"
                    prop.children [
                        sidebarLink Router.Route.Home "Getting Started"

                        sidebarCategory "Charts" [
                            sidebarLink Router.Route.VictoryArea "VictoryArea"
                            sidebarLink Router.Route.VictoryBar "VictoryBar"
                            sidebarLink Router.Route.VictoryLine "VictoryLine"
                        ]
                    ]
                ]
            ]

            Html.main [
                renderPageContent model dispatch
            ]
        ]
    ]

open Elmish.UrlParser
open Elmish.Navigation
open Elmish.React
open Elmish.HMR

Program.mkProgram init update view
|> Program.toNavigable (parseHash Router.routeParser) setRoute
|> Program.withReactSynchronous "root"
|> Program.run
