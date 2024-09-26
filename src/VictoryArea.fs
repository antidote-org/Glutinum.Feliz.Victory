namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictoryAreaTTargetType =
    | data
    | labels
    | parent

[<Erase>]
[<Interface>]
type VictoryAreaBase =
    inherit VictoryDatableProps<IAreaChartProperty>
    inherit VictoryMultiLabelableProps<IAreaChartProperty>
    inherit VictoryCommonProps<IAreaChartProperty>

    static member inline custom (name: string) (value: obj) =
        unbox<IAreaChartProperty> (name, value)

    static member inline eventKey(eventKey: string) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: int) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> int) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "eventKey" eventKey

    static member inline events
        (events: EventPropTypeInterface<VictoryAreaTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "events" events

    static member inline interpolation(interpolation: InterpolationPropType) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "interpolation" interpolation

    static member inline interpolation(interpolation: System.Action) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "interpolation" interpolation

    static member inline samples(samples: int) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "samples" samples

    static member inline style(style: VictoryStyleInterface list) =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "style" (createObj !!style)

[<Erase>]
[<Interface>]
type victoryArea =
    inherit VictoryAreaBase
