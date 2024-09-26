namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<Erase>]
[<Interface>]
type VictoryChartBase =
    inherit VictoryDatableProps<IVictoryChartProperty>
    inherit VictoryLabelableProps<IVictoryStackProperty>
    inherit VictoryMultiLabelableProps<IVictoryChartProperty>

    static member inline custom (name: string) (value: obj) =
        unbox<IVictoryChartProperty> (name, value)

    static member inline backgroundComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "backgroundComponent" value

    static member inline categories(categories: CategoryPropType) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "categories" categories

    static member inline categories(categories) =
        let x: CategoryPropType = Utils.resolveOp_Implicit categories

        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "categories" (x)

    static member inline children(value: ReactElement) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "children" value

    static member inline children(value: ReactElement list) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty>
            "children"
            (Interop.reactApi.Children.toArray (Array.ofSeq value))

    static member inline desc(value: string) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "desc" value

    static member inline defaultAxes(value: AxesType) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "defaultAxes" value

    static member inline defaultPolarAxes(value: AxesType) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "defaultPolarAxes" value

    static member inline domain(value: float * float) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "domain" value

    static member inline domain(value: JS.Date * JS.Date) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "domain" value

    static member inline domain(value: ForAxes<float * float>) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "domain" value

    static member inline domain(value: ForAxes<JS.Date * JS.Date>) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "domain" value

    static member inline endAngle(endAngle: float) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "endAngle" endAngle

    static member inline eventKey(eventKey: string) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: int) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> int) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "eventKey" eventKey

    static member inline events
        (events: EventPropTypeInterface<VictoryAreaTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IAreaChartProperty> "events" events

    static member inline innerRadius(innerRadius: float) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "innerRadius" innerRadius

    static member inline preprendDefaultAxes(value: bool) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "preprendDefaultAxes" value

    static member inline startAngle(startAngle: float) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "startAngle" startAngle

    static member inline title(value: string) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "title" value

    static member inline style(style: VictoryStyleInterface list) =
        Interop.mkDelayedTypeProperty<IVictoryChartProperty> "style" (createObj !!style)

[<Erase>]
[<Interface>]
type victoryChart =
    inherit VictoryChartBase

[<Global>]
[<AllowNullLiteral>]
type AxesType [<ParamObject; Emit("$0")>] (?dependent: ReactElement, ?independent: ReactElement) =

    member val dependent: ReactElement option = nativeOnly with get, set
    member val independent: ReactElement option = nativeOnly with get, set

[<Global>]
[<AllowNullLiteral>]
type ForAxes<'T> [<ParamObject; Emit("$0")>] (?x: 'T, ?y: 'T) =

    member val x: 'T option = nativeOnly with get, set
    member val y: 'T option = nativeOnly with get, set
