module Demo.Pages.Containers.Dispatcher

open Elmish
open Demo.Components

type Model =
    | VictoryChart of VictoryChart.Component.Model

type Msg =
    | VictoryChartMsg of VictoryChart.Component.Msg

let init (route: Router.ContainerRoute) =
    match route with
    | Router.ContainerRoute.VictoryChart ->
        let (subModel, subCmd) = VictoryChart.Component.init ()

        VictoryChart subModel, Cmd.map VictoryChartMsg subCmd

let update msg model =
    match msg with
    | VictoryChartMsg subMsg ->
        match model with
        | VictoryChart subModel ->
            let (newSubModel, subCmd) = VictoryChart.Component.update subMsg subModel

            VictoryChart newSubModel, Cmd.map VictoryChartMsg subCmd

        // | _ -> model, Cmd.none

let view model dispatch =
    match model with
    | VictoryChart subModel -> VictoryChart.Component.view subModel (VictoryChartMsg >> dispatch)

let sidebar (currentRoute: Router.Route option) =
    Sidebar.category "Containers" [
        Sidebar.link currentRoute (Router.Route.Container Router.ContainerRoute.VictoryChart) "VictoryChart"
    ]
