namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictorySliceTTargetType =
    | data
    | labels
    | parent

[<Erase>]
[<Interface>]
type VictorySliceBase =
    inherit VictoryDatableProps<IVictorySliceProperty>
    inherit VictoryLabelableProps<IVictoryStackProperty>
    inherit VictoryMultiLabelableProps<IVictorySliceProperty>
    inherit VictoryCommonProps<IVictorySliceProperty>

    static member inline custom (name: string) (value: obj) =
        unbox<IVictorySliceProperty> (name, value)

    static member inline ariaLabel(ariaLabel: string) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "ariaLabel" ariaLabel

    static member inline ariaLabel(cb: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "ariaLabel" cb

    static member inline cornerRadius(cornerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "cornerRadius" cornerRadius

    static member inline cornerRadius(cornerRadius: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "cornerRadius" cornerRadius

    static member inline datum(datum: obj) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "datum" datum

    static member inline innerRadius(innerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "innerRadius" innerRadius

    static member inline innerRadius(cb: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "innerRadius" cb

    static member inline padAngle(cornerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "cornerRadius" cornerRadius

    static member inline padAngle(cornerRadius: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "cornerRadius" cornerRadius

    static member inline pathComponent(pathComponent: ReactElement) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "pathComponent" pathComponent

    static member inline pathFunction(cb: obj -> string) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "pathFunction" cb

    static member inline radius(radius: float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "radius" radius

    static member inline radius(cb: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "radius" cb

    static member inline slice(slice: VictorySliceBase.slice) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "slice" slice

    static member inline sliceEndAngle(value: float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "sliceEndAngle" value

    static member inline sliceEndAngle(cb: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "sliceEndAngle" cb

    static member inline sliceStartAngle(value: float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "sliceStartAngle" value

    static member inline sliceStartAngle(cb: obj -> float) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "sliceStartAngle" cb

    static member inline style(style: VictoryStyleInterface list) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "style" (createObj !!style)

    static member inline tabIndex(tabIndex: int) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "tabIndex" tabIndex

    static member inline tabIndex(cb: CallbackArgs<'Datum> -> int) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "tabIndex" cb

    static member inline role(value: string) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "role" value

    static member inline shapeRendering(value: string) =
        Interop.mkDelayedTypeProperty<IVictorySliceProperty> "shapeRendering" value

[<Erase>]
[<Interface>]
type victorySlice =
    inherit VictorySliceBase

module VictorySliceBase =

    [<Global>]
    [<AllowNullLiteral>]
    type slice
        [<ParamObject; Emit("$0")>]
        (?startAngle: float, ?endAngel: float, ?padAngle: float, ?data: ResizeArray<obj>)
        =

        member val startAngle: float option = nativeOnly with get, set
        member val endAngel: float option = nativeOnly with get, set
        member val padAngle: float option = nativeOnly with get, set
        member val data: ResizeArray<obj> option = nativeOnly with get, set

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictorySliceLabelPositionType =
    | startAngle
    | centroid
    | endAngle

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictorySliceLabelPlacementType =
    | vertical
    | ``parallel``
    | perpendicular

// [<AllowNullLiteral>]
// [<Interface>]
// type SliceProps =
//     // inherit VictoryCommonProps
//     abstract member ariaLabel: StringOrCallback option with get, set
//     abstract member cornerRadius: SliceNumberOrCallback<SliceProps, string> option with get, set
//     abstract member datum: obj option with get, set
//     abstract member innerRadius: NumberOrCallback option with get, set
//     abstract member padAngle: SliceNumberOrCallback<SliceProps, string> option with get, set
//     abstract member pathComponent: React.ReactElement option with get, set
//     abstract member pathFunction: (SliceProps -> string) option with get, set
//     abstract member radius: SliceNumberOrCallback<SliceProps, string> option with get, set
//     abstract member slice: SliceProps.slice option with get, set
//     abstract member sliceEndAngle: SliceNumberOrCallback<SliceProps, string> option with get, set
//     abstract member sliceStartAngle: SliceNumberOrCallback<SliceProps, string> option with get, set
//     abstract member style: VictoryStyleInterface option with get, set
//     abstract member tabIndex: NumberOrCallback option with get, set
//     abstract member role: string option with get, set
//     abstract member shapeRendering: string option with get, set

module SliceProps =

    [<Global>]
    [<AllowNullLiteral>]
    type slice
        [<ParamObject; Emit("$0")>]
        (?startAngle: float, ?endAngle: float, ?padAngle: float, ?data: ResizeArray<obj>)
        =

        member val startAngle: float option = nativeOnly with get, set
        member val endAngle: float option = nativeOnly with get, set
        member val padAngle: float option = nativeOnly with get, set
        member val data: ResizeArray<obj> option = nativeOnly with get, set
