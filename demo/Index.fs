module Demo.Index

open Glutinum.Feliz.Victory
open Feliz
open Browser.Dom
open Fable.Core
open Elmish
open Demo.Components

[<ImportDefault("./Index.module.css")>]
let private classes: CssModules.Index = nativeOnly

[<RequireQualifiedAccess>]
[<NoComparison>]
type Page =
    | Home
    | Charts of Pages.Charts.Dispatcher.Model
    | Containers of Pages.Containers.Dispatcher.Model
    | NotFound

[<NoComparison>]
type Msg =
    | SetRoute of Router.Route option
    | ChartsMsg of Pages.Charts.Dispatcher.Msg
    | ContainersMsg of Pages.Containers.Dispatcher.Msg

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
        | Router.Route.Home ->
            { model with
                ActivePage = Page.Home
            },
            Cmd.none

        | Router.Route.NotFound ->
            { model with
                ActivePage = Page.NotFound
            },
            Cmd.none

        | Router.Route.Chart chartRoute ->
            let (subModel, subCmd) = Pages.Charts.Dispatcher.init chartRoute

            { model with
                ActivePage = Page.Charts subModel
            },
            Cmd.map ChartsMsg subCmd

        | Router.Route.Container containerRoute ->
            let (subModel, subCmd) = Pages.Containers.Dispatcher.init containerRoute

            { model with
                ActivePage = Page.Containers subModel
            },
            Cmd.map ContainersMsg subCmd

let private update (msg: Msg) (model: Model) =
    match msg with
    | SetRoute optRoute -> setRoute optRoute model

    | ChartsMsg subMsg ->
        match model.ActivePage with
        | Page.Charts subModel ->
            Pages.Charts.Dispatcher.update subMsg subModel
            |> Tuple.mapFirst Page.Charts
            |> Tuple.mapFirst (fun page ->
                { model with
                    ActivePage = page
                }
            )
            |> Tuple.mapSecond (Cmd.map ChartsMsg)

        | _ -> model, Cmd.none

    | ContainersMsg subMsg ->
        match model.ActivePage with
        | Page.Containers subModel ->
            Pages.Containers.Dispatcher.update subMsg subModel
            |> Tuple.mapFirst Page.Containers
            |> Tuple.mapFirst (fun page ->
                { model with
                    ActivePage = page
                }
            )
            |> Tuple.mapSecond (Cmd.map ContainersMsg)

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

    | Page.Charts subModel -> Pages.Charts.Dispatcher.view subModel (ChartsMsg >> dispatch)
    | Page.Containers subModel -> Pages.Containers.Dispatcher.view subModel (ContainersMsg >> dispatch)

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
                        Sidebar.link Router.Route.Home "Getting Started"

                        Pages.Charts.Dispatcher.sidebar
                        Pages.Containers.Dispatcher.sidebar
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
