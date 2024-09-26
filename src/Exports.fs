namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

type Exports =

    static member inline VictoryChart(properties: #IVictoryChartProperty seq) =
        Interop.reactApi.createElement (import "VictoryChart" "victory", createObj !!properties)

    static member inline VictoryChart(properties: ReactElement list) =
        Interop.reactApi.createElement (
            import "VictoryChart" "victory",
            {|
                children = Interop.reactApi.Children.toArray (Array.ofSeq properties)
            |}
        )

    static member inline VictoryChart(value: ReactElement) =
        Interop.reactApi.createElement (
            import "VictoryChart" "victory",
            {|
                children = value
            |}
        )

    static member inline VictoryArea(properties: #IAreaChartProperty seq) =
        Interop.reactApi.createElement (import "VictoryArea" "victory", createObj !!properties)

    static member inline VictoryBar(properties: #IVictoryBarProperty seq) =
        Interop.reactApi.createElement (import "VictoryBar" "victory", createObj !!properties)

    static member inline VictoryLine(properties: #IVictoryLineProperty seq) =
        Interop.reactApi.createElement (import "VictoryLine" "victory", createObj !!properties)

    static member inline VictoryStack(properties: #IVictoryStackProperty seq) =
        Interop.reactApi.createElement (import "VictoryStack" "victory", createObj !!properties)

    static member inline VictoryPie(properties: #IVictoryPieProperty seq) =
        Interop.reactApi.createElement (import "VictoryPie" "victory", createObj !!properties)

    static member inline VictoryAxis(properties: #IVictoryAxisProperty seq) =
        Interop.reactApi.createElement (import "VictoryAxis" "victory", createObj !!properties)

    [<Import("VictoryTheme", "victory")>]
    static member inline VictoryTheme: VictoryThemeBase = nativeOnly
