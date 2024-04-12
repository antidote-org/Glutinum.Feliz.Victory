namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictoryBarCornerRadiusKey =
    | top
    | bottom
    | topLeft
    | topRight
    | bottomLeft
    | bottomRight

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictoryBarTTargetType =
    | data
    | labels
    | parent

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type VictoryBarAlignmentType =
    | start
    | middle
    | ``end``

[<Erase>]
[<Interface>]
type VictoryBarProps =
    inherit VictoryDatableProps<IVictoryBarProperty>
    inherit VictoryMultiLabelableProps<IVictoryBarProperty>

    static member inline custom (name : string) (value : obj) =
        unbox<IVictoryBarProperty>(name, value)

    static member inline alignment(alignment: VictoryBarAlignmentType) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "alignment" alignment

    static member inline barRatio(barRatio: float) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "barRatio" barRatio

    static member inline barWidth(barWidth: float) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "barWidth" barWidth

    static member inline cornerRadius(cornerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "cornerRadius" cornerRadius

    static member inline cornerRadius(cornerRadius: CallbackArgs -> float) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "cornerRadius" cornerRadius

    static member inline eventKey(eventKey: string) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: int) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs -> string) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs -> int) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "eventKey" eventKey

    static member inline events
        (events: EventPropTypeInterface<VictoryAreaTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "events" events

    static member inline getpath(props: VictoryBarProps -> string) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "getpath" (System.Func<_, _> props)

    static member inline horizontal(horizontal: bool) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "horizontal" horizontal

    static member inline style(style: VictoryStyleInterface list) =
        Interop.mkDelayedTypeProperty<IVictoryBarProperty> "style" (createObj !!style)

[<Global>]
[<AllowNullLiteral>]
type VictoryBarCornerRadiusObject private () =

    [<ParamObject; Emit("$0")>]
    new
        (
            ?top: float,
            ?bottom: float,
            ?topLeft: float,
            ?topRight: float,
            ?bottomLeft: float,
            ?bottomRight: float
        )
        =
        VictoryBarCornerRadiusObject()

    [<ParamObject; Emit("$0")>]
    new
        (
            ?top: CallbackArgs -> float,
            ?bottom: CallbackArgs -> float,
            ?topLeft: CallbackArgs -> float,
            ?topRight: CallbackArgs -> float,
            ?bottomLeft: CallbackArgs -> float,
            ?bottomRight: CallbackArgs -> float
        )
        =
        VictoryBarCornerRadiusObject()

    [<ParamObject; Emit("$0")>]
    new
        (
            ?top: U2<float, CallbackArgs -> float>,
            ?bottom: U2<float, CallbackArgs -> float>,
            ?topLeft: U2<float, CallbackArgs -> float>,
            ?topRight: U2<float, CallbackArgs -> float>,
            ?bottomLeft: U2<float, CallbackArgs -> float>,
            ?bottomRight: U2<float, CallbackArgs -> float>
        )
        =
        VictoryBarCornerRadiusObject()

    member val top: U2<float, CallbackArgs -> float> option = nativeOnly with get, set
    member val bottom: U2<float, CallbackArgs -> float> option = nativeOnly with get, set
    member val topLeft: U2<float, CallbackArgs -> float> option = nativeOnly with get, set
    member val topRight: U2<float, CallbackArgs -> float> option = nativeOnly with get, set
    member val bottomLeft: U2<float, CallbackArgs -> float> option = nativeOnly with get, set
    member val bottomRight: U2<float, CallbackArgs -> float> option = nativeOnly with get, set

[<Erase>]
[<Interface>]
type VictoryBar =
    inherit VictoryBarProps
