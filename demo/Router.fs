[<RequireQualifiedAccess>]
module Router

open Elmish.UrlParser
open Elmish.Navigation
open Feliz
open Browser.Dom

[<RequireQualifiedAccess>]
type Route =
    | Home
    | VictoryArea
    | VictoryBar
    | VictoryLine
    | NotFound

let private toHash page =
    let segmentsPart =
        match page with
        | Route.Home -> "home"
        | Route.VictoryArea -> "victory-area"
        | Route.VictoryBar -> "victory-bar"
        | Route.VictoryLine -> "victory-line"
        | Route.NotFound -> "not-found"

    "#" + segmentsPart

let routeParser: Parser<Route -> Route, Route> =
    oneOf [
        map Route.Home (s "home")
        map Route.VictoryArea (s "victory-area")
        map Route.VictoryBar (s "victory-bar")
        map Route.VictoryLine (s "victory-line")
        map Route.Home top
    ]

let href route = prop.href (toHash route)

let modifyUrl route = route |> toHash |> Navigation.modifyUrl

let newUrl route = route |> toHash |> Navigation.newUrl

let modifyLocation route = window.location.href <- toHash route
