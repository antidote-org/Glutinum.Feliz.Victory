namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<Erase>]
[<Interface>]
type VictoryStackProps =
    inherit VictoryLabelableProps<IVictoryStackProperty>
    inherit VictoryMultiLabelableProps<IVictoryStackProperty>

    static member inline bins(bins: int) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "bins" bins

    static member inline bins(bins: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "bins" bins

    static member inline bins(bins: ResizeArray<JS.Date>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "bins" bins

    static member inline categories(categories: CategoryPropType) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "categories" categories

    static member inline categories(categories) =
        let x: CategoryPropType = Utils.resolveOp_Implicit categories

        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "categories" (x)

    static member inline children(children: ReactElement list) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty>
            "children"
            (Interop.reactApi.Children.toArray (Array.ofSeq children))

    static member inline children(children: ReactElement) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty>
            "children"
            (Interop.reactApi.Children.toArray (
                Array.ofSeq [
                    children
                ]
            ))

    static member inline colorScale(colorScale: ColorScalePropType.Case1) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "colorScale" colorScale

    static member inline colorScale(colorScale: string list) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "colorScale" (ResizeArray colorScale)

    static member inline domain(domain: float * float) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "domain" domain

    static member inline domain(domain: JS.Date * JS.Date) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "domain" domain

    static member inline domain(domain: ForAxes.Case2<float * float>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "domain" domain

    static member inline domain(domain: ForAxes.Case2<JS.Date * JS.Date>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "domain" domain

    static member inline events
        (events: EventPropTypeInterface<VictoryAreaTTargetType, U2<string, float>>)
        =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "events" events

    static member inline eventKey(eventKey: string) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: int) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "eventKey" eventKey

    static member inline eventKey(eventKey: CallbackArgs<'Datum> -> int) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "eventKey" eventKey

    static member inline fillInMissingData(fillInMissingData: bool) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "fillInMissingData" fillInMissingData

    static member inline style(style: VictoryStyleInterface) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "style" style

    static member inline xOffset(xOffset: float) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "xOffset" xOffset

[<Erase>]
[<Interface>]
type VictoryStack =
    inherit VictoryStackProps
