module Demo.Pages.Charts.Dispatcher

open Elmish
open Demo.Components

type Model =
    | VictoryArea
    | VictoryBar
    | VictoryLine
    | VictoryPie
    | VictoryAxis

type Msg = | NoOp

let init (route: Router.ChartRoute) =
    match route with
    | Router.ChartRoute.VictoryArea -> VictoryArea, Cmd.none
    | Router.ChartRoute.VictoryBar -> VictoryBar, Cmd.none
    | Router.ChartRoute.VictoryLine -> VictoryLine, Cmd.none
    | Router.ChartRoute.VictoryPie -> VictoryPie, Cmd.none
    | Router.ChartRoute.VictoryAxis -> VictoryAxis, Cmd.none

let update msg model =
    match msg with
    | NoOp -> model, Cmd.none

let view model dispatch =
    match model with
    | VictoryArea -> VictoryArea.Component.view
    | VictoryBar -> VictoryBar.Component.view
    | VictoryLine -> VictoryLine.Component.view
    | VictoryPie -> VictoryPie.Component.view
    | VictoryAxis -> VictoryAxis.Component.view

let sidebar (currentRoute: Router.Route option) =
    Sidebar.category "Charts" [
        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryAxis)
            "VictoryAxis"
            VictoryAxis.Component.tableOfContents

        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryArea)
            "VictoryArea"
            VictoryArea.Component.tableOfContents

        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryBar)
            "VictoryBar"
            VictoryBar.Component.tableOfContents

        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryLine)
            "VictoryLine"
            VictoryLine.Component.tableOfContents

        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryPie)
            "VictoryPie"
            VictoryLine.Component.tableOfContents
    ]
