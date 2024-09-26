module Demo.Pages.Charts.Dispatcher

open Elmish
open Demo.Components

type Model =
    | VictoryArea of VictoryArea.Component.Model
    | VictoryBar of VictoryBar.Component.Model
    | VictoryLine of VictoryLine.Component.Model
    | VictoryPie of VictoryPie.Component.Model
    | VictoryAxis

type Msg =
    | VictoryAreaMsg of VictoryArea.Component.Msg
    | VictoryBarMsg of VictoryBar.Component.Msg
    | VictoryLineMsg of VictoryLine.Component.Msg
    | VictoryPieMsg of VictoryPie.Component.Msg

let init (route: Router.ChartRoute) =
    match route with
    | Router.ChartRoute.VictoryArea ->
        let (subModel, subCmd) = VictoryArea.Component.init ()

        VictoryArea subModel, Cmd.map VictoryAreaMsg subCmd

    | Router.ChartRoute.VictoryBar ->
        let (subModel, subCmd) = VictoryBar.Component.init ()

        VictoryBar subModel, Cmd.map VictoryBarMsg subCmd

    | Router.ChartRoute.VictoryLine ->
        let (subModel, subCmd) = VictoryLine.Component.init ()

        VictoryLine subModel, Cmd.map VictoryLineMsg subCmd

    | Router.ChartRoute.VictoryPie ->
        let (subModel, subCmd) = VictoryPie.Component.init ()

        VictoryPie subModel, Cmd.map VictoryPieMsg subCmd

    | Router.ChartRoute.VictoryAxis -> VictoryAxis, Cmd.none

let update msg model =
    match msg with
    | VictoryAreaMsg subMsg ->
        match model with
        | VictoryArea subModel ->
            let (newSubModel, subCmd) = VictoryArea.Component.update subMsg subModel

            VictoryArea newSubModel, Cmd.map VictoryAreaMsg subCmd

        | _ -> model, Cmd.none

    | VictoryBarMsg subMsg ->
        match model with
        | VictoryBar subModel ->
            let (newSubModel, subCmd) = VictoryBar.Component.update subMsg subModel

            VictoryBar newSubModel, Cmd.map VictoryBarMsg subCmd

        | _ -> model, Cmd.none

    | VictoryLineMsg subMsg ->
        match model with
        | VictoryLine subModel ->
            let (newSubModel, subCmd) = VictoryLine.Component.update subMsg subModel

            VictoryLine newSubModel, Cmd.map VictoryLineMsg subCmd

        | _ -> model, Cmd.none

    | VictoryPieMsg subMsg ->
        match model with
        | VictoryPie subModel ->
            let (newSubModel, subCmd) = VictoryPie.Component.update subMsg subModel

            VictoryPie newSubModel, Cmd.map VictoryPieMsg subCmd

        | _ -> model, Cmd.none

let view model dispatch =
    match model with
    | VictoryArea subModel -> VictoryArea.Component.view subModel (VictoryAreaMsg >> dispatch)
    | VictoryBar subModel -> VictoryBar.Component.view subModel (VictoryBarMsg >> dispatch)
    | VictoryLine subModel -> VictoryLine.Component.view subModel (VictoryLineMsg >> dispatch)
    | VictoryPie subModel -> VictoryPie.Component.view subModel (VictoryPieMsg >> dispatch)
    | VictoryAxis -> VictoryAxis.Component.view

let sidebar (currentRoute: Router.Route option) =
    Sidebar.category "Charts" [
        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryAxis)
            "VictoryAxis"
            VictoryAxis.Component.tableOfContents

        Sidebar.link currentRoute (Router.Route.Chart Router.ChartRoute.VictoryArea) "VictoryArea"

        Sidebar.linkWithToc
            currentRoute
            (Router.Route.Chart Router.ChartRoute.VictoryBar)
            "VictoryBar"
            VictoryBar.Component.tableOfContents

        Sidebar.link currentRoute (Router.Route.Chart Router.ChartRoute.VictoryLine) "VictoryLine"

        Sidebar.link currentRoute (Router.Route.Chart Router.ChartRoute.VictoryPie) "VictoryPie"
    ]
