namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

type Exports =

    static member inline VictoryChart(properties: #IVictoryChartProperty seq) =
        Interop.reactApi.createElement (import "VictoryChart" "victory", createObj !!properties)

    static member inline VictoryArea(properties: #IAreaChartProperty seq) =
        Interop.reactApi.createElement (import "VictoryArea" "victory", createObj !!properties)

    static member inline VictoryBar(properties: #IVictoryBarProperty seq) =
        Interop.reactApi.createElement (import "VictoryBar" "victory", createObj !!properties)

    static member inline VictoryStack(properties: #IVictoryStackProperty seq) =
        Interop.reactApi.createElement (import "VictoryStack" "victory", createObj !!properties)
