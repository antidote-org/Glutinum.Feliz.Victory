namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictoryLineTTargetType =
    | data
    | labels
    | parent

[<Erase>]
[<Interface>]
type VictoryLineBase =
    inherit VictoryDatableProps<IVictoryLineProperty>
    inherit VictoryLabelableProps<IVictoryLineProperty>
    inherit VictoryMultiLabelableProps<IVictoryLineProperty>

    static member inline custom (name: string) (value: obj) =
        unbox<IVictoryLineProperty> (name, value)

    static member inline eventKey(eventKey: string) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: int) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> int) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "eventKey" eventKey

    static member inline events
        (events: EventPropTypeInterface<VictoryLineTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "events" events

    static member inline interpolation(interpolation: InterpolationPropType) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "interpolation" interpolation

    static member inline interpolation(interpolation: System.Action) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "interpolation" interpolation

    static member inline samples(samples: int) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "samples" samples

    static member inline style(style: VictoryStyleInterface list) =
        Interop.mkDelayedTypeProperty<IVictoryLineProperty> "style" (createObj !!style)

[<Erase>]
[<Interface>]
type VictoryLine =
    inherit VictoryLineBase
