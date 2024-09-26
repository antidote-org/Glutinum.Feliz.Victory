module Demo.Pages.Containers.Dispatcher

open Elmish
open Demo.Components

type Model =
    | VictoryChart

type Msg =
    | NoOp

let init (route: Router.ContainerRoute) =
    match route with
    | Router.ContainerRoute.VictoryChart ->
        VictoryChart, Cmd.none

let update msg model =
    match msg with
    | NoOp -> model, Cmd.none

let view model dispatch =
    match model with
    | VictoryChart -> VictoryChart.Component.view

let sidebar (currentRoute: Router.Route option) =
    Sidebar.category "Containers" [
        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Container Router.ContainerRoute.VictoryChart)
            "VictoryChart"
            VictoryChart.Component.tableOfContents
    ]
