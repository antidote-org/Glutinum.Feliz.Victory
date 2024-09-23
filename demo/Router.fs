[<RequireQualifiedAccess>]
module Router

open Browser.Dom

// Makes writing url segments more natural
let inline (</>) a b = a + "/" + string b

[<RequireQualifiedAccess>]
type ChartRoute =
    | VictoryArea
    | VictoryBar
    | VictoryLine
    | VictoryPie

    static member toSegments = function
        | VictoryArea -> "victory-area"
        | VictoryBar -> "victory-bar"
        | VictoryLine -> "victory-line"
        | VictoryPie -> "victory-pie"

[<RequireQualifiedAccess>]
type ContainerRoute =
    | VictoryChart

    static member toSegments = function
        | VictoryChart -> "victory-chart"

[<RequireQualifiedAccess>]
type Route =
    | Home
    | Chart of ChartRoute
    | Container of ContainerRoute
    | NotFound

let private toHash page =
    let segmentsPart =
        match page with
        | Route.Home -> "home"
        | Route.Chart chart -> "chart" </> ChartRoute.toSegments chart
        | Route.Container container -> "container" </> ContainerRoute.toSegments container
        | Route.NotFound -> "not-found"

    "#" + segmentsPart

// Needs to be open here otherwise </> is shadowed by our inline operator
open Elmish.UrlParser
open Elmish.Navigation
open Feliz

let routeParser: Parser<Route -> Route, Route> =
    oneOf [
        map Route.Home (s "home")
        map (Route.Chart ChartRoute.VictoryArea) (s "chart" </> s "victory-area")
        map (Route.Chart ChartRoute.VictoryBar) (s "chart" </> s "victory-bar")
        map (Route.Chart ChartRoute.VictoryLine) (s "chart" </> s "victory-line")
        map (Route.Chart ChartRoute.VictoryPie) (s "chart" </> s "victory-pie")
        map (Route.Container ContainerRoute.VictoryChart) (s "container" </> s "victory-chart")
        map Route.Home top
    ]

let href route = prop.href (toHash route)

let modifyUrl route = route |> toHash |> Navigation.modifyUrl

let newUrl route = route |> toHash |> Navigation.newUrl

let modifyLocation route = window.location.href <- toHash route
