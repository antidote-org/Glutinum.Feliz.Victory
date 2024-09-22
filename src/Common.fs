namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Feliz

open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type AxisType =
    | x
    | y

type DatumValue = U3<float, string, JS.Date> option

// type Datum = obj

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type OrientationTypes =
    | top
    | bottom
    | left
    | right

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type ScaleName =
    | linear
    | time
    | log
    | sqrt

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type SortOrderPropType =
    | ascending
    | descending

type ScalePropType = ScaleName

type ID = U2<float, string>

type D3Scale = obj

[<AllowNullLiteral>]
[<Interface>]
type CallbackArgs<'Datum> =
    abstract active: bool option with get, set
    abstract data: ResizeArray<'Datum> option with get, set
    abstract datum: 'Datum option with get, set
    abstract horizontal: bool option with get, set
    abstract index: ID option with get, set
    abstract x: float option with get, set
    abstract y: float option with get, set

    abstract scale:
        U3<
            ScalePropType,
            D3Scale,
            {|
                x: U2<ScalePropType, D3Scale> option
                y: U2<ScalePropType, D3Scale> option
            |}
         > option with get, set

    abstract tick: obj option with get, set
    abstract ticks: obj option with get, set
    abstract text: obj option with get, set

[<AllowNullLiteral>]
[<Interface>]
type BlockProps =
    abstract member top: float option with get, set
    abstract member bottom: float option with get, set
    abstract member left: float option with get, set
    abstract member right: float option with get, set

module ForAxes =

    type Case1<'T> = 'T

    [<AllowNullLiteral>]
    [<Global>]
    type Case2<'T> [<ParamObject; Emit("$0")>] (?x: 'T, ?y: 'T) =
        member val x: 'T = jsNative with get, set
        member val y: 'T = jsNative with get, set

[<Erase>]
[<Interface>]
type VictoryDatableProps<'IDelayedTypeProperty> =

    static member inline categories(categories: CategoryPropType) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "categories" categories

    static member inline data(data: 'T list) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "data" (ResizeArray data)

    static member inline dataComponent(dataComponent: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "dataComponent" dataComponent

    static member inline domain(domain: float * float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domain" domain

    static member inline domain(domain: JS.Date * JS.Date) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domain" domain

    static member inline domain(domain: ForAxes.Case2<float * float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domain" domain

    static member inline domain(domain: ForAxes.Case2<JS.Date * JS.Date>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domain" domain

    static member inline domainPadding(domainPadding: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" domainPadding

    static member inline domainPadding(domainPadding: float * float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" domainPadding

    static member inline domainPadding(domainPadding: ForAxes.Case2<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" domainPadding

    static member inline domainPadding(domainPadding: ForAxes.Case2<float * float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" domainPadding

    static member inline samples(samples: int) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "samples" samples

    static member inline sortKey(sortKey: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: CallbackArgs<'Datum> -> ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortKey(sortKey: CallbackArgs<'Datum> -> ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortKey" sortKey

    static member inline sortOrder(sortOrder: SortOrderPropType) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortOrder" sortOrder

    static member inline sortOrder(sortOrder: ResizeArray<SortOrderPropType>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sortOrder" sortOrder

    static member inline x(x: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: CallbackArgs<'Datum> -> ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline x(x: CallbackArgs<'Datum> -> ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "x" x

    static member inline y(y: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: CallbackArgs<'Datum> -> ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y(y: CallbackArgs<'Datum> -> ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y" y

    static member inline y0(y0: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: CallbackArgs<'Datum> -> ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: CallbackArgs<'Datum> -> float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

    static member inline y0(y0: CallbackArgs<'Datum> -> ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "y0" y0

[<Erase>]
[<Interface>]
type VictoryLabelableProps<'IDelayedTypeProperty> =
    static member inline labelComponent(labelComponent: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labelComponent" labelComponent

[<Erase>]
[<Interface>]
type VictoryMultiLabelableProps<'IDelayedTypeProperty> =
    inherit VictoryLabelableProps<'IDelayedTypeProperty>

    static member inline labels(labels: ResizeArray<string>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labels" labels

    static member inline labels(labels: CallbackArgs<'Datum> -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labels" labels

    static member inline labels(labels: obj -> string option) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labels" labels

    static member inline labels(labels: obj -> ResizeArray<string> option) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labels" labels

    static member inline labels(labels: obj -> float option) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labels" labels

    static member inline labels(labels: obj -> ResizeArray<float> option) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "labels" labels

[<AllowNullLiteral>]
[<Interface>]
type VictoryStringOrNumberCallback =
    [<Emit("$0($1...)")>]
    abstract member Invoke: args: CallbackArgs<'Datum> -> U2<string, float>

[<AllowNullLiteral>]
[<Interface>]
type VictoryStringCallback =
    [<Emit("$0($1...)")>]
    abstract member Invoke: args: CallbackArgs<'Datum> -> string

type StringOrNumberOrCallback = U3<string, float, VictoryStringOrNumberCallback>

type StringOrCallback = U2<string, VictoryStringCallback>

type SliceNumberOrCallback = U2<float, obj>

[<AllowNullLiteral>]
[<Interface>]
type VictoryNumberCallback =
    [<Emit("$0($1...)")>]
    abstract member Invoke: args: CallbackArgs<'Datum> -> float

[<AllowNullLiteral>]
[<Interface>]
type VictoryPaddingCallback =
    [<Emit("$0($1...)")>]
    abstract member Invoke: args: CallbackArgs<'Datum> -> U2<float, BlockProps>

[<AllowNullLiteral>]
[<Interface>]
type VictoryOrientationCallback =
    [<Emit("$0($1...)")>]
    abstract member Invoke: args: CallbackArgs<'Datum> -> OrientationTypes

type NumberOrCallback = U2<float, VictoryNumberCallback>

type PaddingOrCallback = U3<float, BlockProps, VictoryPaddingCallback>

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type OrientationOrCallback =
    | top
    | bottom
    | left
    | right

[<AllowNullLiteral>]
[<Interface>]
type EventPropTypeInterface<'TTarget, 'TEventKey> =
    abstract member childName: U2<string, ResizeArray<StringOrNumberOrCallback>> option with get, set
    abstract member target: 'TTarget with get, set
    abstract member eventKey: 'TEventKey option with get, set
    abstract member eventHandlers: EventPropTypeInterface.eventHandlers with get, set

module EventPropTypeInterface =

    type eventHandlers = obj

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type InterpolationPropType =
    | basis
    | basisClosed
    | basisOpen
    | bundle
    | cardinal
    | cardinalClosed
    | cardinalOpen
    | catmullRom
    | catmullRomClosed
    | catmullRomOpen
    | linear
    | linearClosed
    | monotoneX
    | monotoneY
    | natural
    | radial
    | step
    | stepAfter
    | stepBefore

type VictoryStyleObject = IStyleAttribute list

[<Erase>]
[<Interface>]
type VictoryStyleInterface =
    static member inline parent(style: VictoryStyleObject) : VictoryStyleInterface =
        unbox ("parent", createObj !!style)

    static member inline data(style: VictoryStyleObject) : VictoryStyleInterface =
        unbox ("data", createObj !!style)

    // TODO: Map to VictoryLabelStyleObject but for that we would need to be able to inherit from
    // Feliz.style which is not possible at the moment because Feliz.style is not an interface
    static member inline labels(style: VictoryStyleObject) : VictoryStyleInterface =
        unbox ("labels", createObj !!style)

    static member inline border(style: VictoryStyleObject) : VictoryStyleInterface =
        unbox ("border", createObj !!style)

[<Erase>]
type CategoryPropType =
    | Case1 of ResizeArray<string>
    | Case2 of
        {|
            x: ResizeArray<string>
        |}
    | Case3 of
        {|
            y: ResizeArray<string>
        |}
    | Case4 of
        {|
            x: ResizeArray<string>
            y: ResizeArray<string>
        |}

    static member op_ErasedCast(x: ResizeArray<string>) = Case1 x

    static member op_ErasedCast
        (x:
            {|
                x: ResizeArray<string>
            |})
        =
        Case2 x

    static member op_ErasedCast
        (x:
            {|
                y: ResizeArray<string>
            |})
        =
        Case3 x

    static member op_ErasedCast
        (x:
            {|
                x: ResizeArray<string>
                y: ResizeArray<string>
            |})
        =
        Case4 x

    static member inline op_Implicit(x: ResizeArray<string>) = Case1 x

    static member inline op_Implicit
        (x:
            {|
                x: ResizeArray<string>
            |})
        =
        Case2 x

    static member inline op_Implicit
        (x:
            {|
                y: ResizeArray<string>
            |})
        =
        Case3 x

    static member inline op_Implicit
        (x:
            {|
                x: ResizeArray<string>
                y: ResizeArray<string>
            |})
        =
        Case4 x
