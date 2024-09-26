namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictoryAxisTTargetType =
    | axis
    | axisLabel
    | grid
    | ticks
    | tickLabels
    | parent

[<Erase>]
[<Interface>]
type VictoryAxisBase =
    inherit VictorySingleLabelableProps<IVictoryAxisProperty>
    inherit VictoryAxisCommonProps<IVictoryAxisProperty>
    inherit VictoryCommonProps<IVictoryAxisProperty>

    static member inline custom (name: string) (value: obj) =
        unbox<IVictoryAxisProperty> (name, value)

    static member inline crossAxis(value: bool) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "crossAxis" value

    static member inline domain(value: float * float) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "domain" value

    static member inline domain(value: JS.Date * JS.Date) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "domain" value

    static member inline domain(domain: ForAxes.Case2<float * float>) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "domain" domain

    static member inline domain(domain: ForAxes.Case2<JS.Date * JS.Date>) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "domain" domain

    static member inline events
        (events: EventPropTypeInterface<VictoryAxisTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "events" events

    static member inline fixLabelOverlap(value: bool) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "fixLabelOverlap" value

    static member inline offsetX(value: float) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "offsetX" value

    static member inline offsetY(value: float) =
        Interop.mkDelayedTypeProperty<IVictoryAxisProperty> "offsetY" value

[<Erase>]
[<Interface>]
type VictoryAxis =
    inherit VictoryAxisBase
