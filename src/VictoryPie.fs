namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<Erase>]
[<Interface>]
type VictoryPieBase =
    inherit VictoryDatableProps<IVictoryPieProperty>
    inherit VictoryLabelableProps<IVictoryStackProperty>
    inherit VictoryMultiLabelableProps<IVictoryPieProperty>

    static member inline custom (name: string) (value: obj) =
        unbox<IVictoryPieProperty> (name, value)

    static member inline colorScale(colorScale: ColorScalePropType.Case1) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "colorScale" colorScale

    static member inline colorScale(colorScale: string list) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "colorScale" (ResizeArray colorScale)

    static member inline cornerRadius(cornerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "cornerRadius" cornerRadius

    static member inline cornerRadius(cornerRadius: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "cornerRadius" cornerRadius

    static member inline endAngle(endAngle: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "endAngle" endAngle

    static member inline eventKey(eventKey: string) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: int) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> int) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "eventKey" eventKey

    static member inline events
        (events: EventPropTypeInterface<VictorySliceTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "events" events

    static member inline innerRadius(innerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "innerRadius" innerRadius

    static member inline innerRadius(value: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "innerRadius" value

    static member inline labelIndicator(value: bool) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelIndicator" value

    static member inline labelIndicator(value: ReactElement) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelIndicator" value

    static member inline labelIndicatorInnerOffset(value: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelIndicatorInnerOffset" value

    static member inline labelIndicatorOuterOffset(value: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelIndicatorOuterOffset" value

    static member inline labelPlacement(value: VictorySliceLabelPlacementType) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelPlacement" value

    static member inline labelPlacement(value: obj -> VictorySliceLabelPlacementType) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelPlacement" value

    static member inline labelPosition(value: VictorySliceLabelPositionType) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelPosition" value

    static member inline labelPosition(value: obj -> VictorySliceLabelPositionType) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelPosition" value

    static member inline labelIndicatorComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelIndicatorComponent" value

    static member inline labelRadius(value: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelRadius" value

    static member inline labelRadius(value: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "labelRadius" value

    static member inline origin(value: OriginType) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "origin" value

    static member inline padAngle(padAngle: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "padAngle" padAngle

    static member inline padAngle(value: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "padAngle" value

    static member inline radius(radius: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "radius" radius

    static member inline radius(value: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "radius" value

    static member inline startAngle(startAngle: float) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "startAngle" startAngle

    static member inline style(style: VictoryStyleInterface list) =
        Interop.mkDelayedTypeProperty<IVictoryPieProperty> "style" (createObj !!style)

[<Erase>]
[<Interface>]
type VictoryPie =
    inherit VictoryPieBase
