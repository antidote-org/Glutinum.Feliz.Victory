namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Feliz

open Fable.Core
open Fable.Core.JsInterop

type IVictoryTheme = obj

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

    // static member inline categories(categories: CategoryPropType) =
    //     Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "categories" categories

    static member inline categories(categories) =
        categories
        |> Utils.resolveOp_Implicit<_, CategoryPropType>
        |> Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "categories"

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
type VictorySingleLabelableProps<'IDelayedTypeProperty> =
    inherit VictoryLabelableProps<'IDelayedTypeProperty>

    static member inline label(value: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "label" value

    static member inline label(value: obj -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "label" value

    static member inline label(value: obj -> float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "label" value

    static member inline label(value: obj -> obj) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "label" value

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

type ColorScalePropType = U2<ColorScalePropType.Case1, ResizeArray<string>>

module ColorScalePropType =

    [<RequireQualifiedAccess>]
    [<StringEnum(CaseRules.None)>]
    type Case1 =
        | grayscale
        | qualitative
        | heatmap
        | warm
        | cool
        | red
        | green
        | blue

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

[<RequireQualifiedAccess>]
[<Erase>]
type CategoryPropType =
    // U4<ResizeArray<string>, CategoryPropType.U4.Case2, CategoryPropType.U4.Case3, CategoryPropType.U4.Case4>
    | Case1 of ResizeArray<string>
    | Case2 of CategoryPropType.U4.Case2
    | Case3 of CategoryPropType.U4.Case3
    | Case4 of CategoryPropType.U4.Case4

    static member inline op_Implicit(categories: ResizeArray<string>) = Case1(categories)
    static member inline op_Implicit(categories: CategoryPropType.U4.Case2) = Case2(categories)
    static member inline op_Implicit(categories: CategoryPropType.U4.Case3) = Case3(categories)
    static member inline op_Implicit(categories: CategoryPropType.U4.Case4) = Case4(categories)

module CategoryPropType =

    module U4 =

        [<Global>]
        [<AllowNullLiteral>]
        type Case2 [<ParamObject; Emit("$0")>] (x: ResizeArray<string>) =

            member val x: ResizeArray<string> = nativeOnly with get, set

        [<Global>]
        [<AllowNullLiteral>]
        type Case3 [<ParamObject; Emit("$0")>] (y: ResizeArray<string>) =

            member val y: ResizeArray<string> = nativeOnly with get, set

        [<Global>]
        [<AllowNullLiteral>]
        type Case4 [<ParamObject; Emit("$0")>] (x: ResizeArray<string>, y: ResizeArray<string>) =

            member val x: ResizeArray<string> = nativeOnly with get, set
            member val y: ResizeArray<string> = nativeOnly with get, set

[<RequireQualifiedAccess>]
type CategoryPropType2 =
    // U4<ResizeArray<string>, CategoryPropType2.U4.Case2, CategoryPropType2.U4.Case3, CategoryPropType2.U4.Case4>
    | Case1 of ResizeArray<string>
    | Case2 of CategoryPropType2.U4.Case2

    static member op_Implicit(categories: ResizeArray<string>) = CategoryPropType2.Case1(categories)

    static member op_Implicit(categories: CategoryPropType2.U4.Case2) =
        CategoryPropType2.Case2(categories)

module CategoryPropType2 =

    module U4 =

        [<Global>]
        [<AllowNullLiteral>]
        type Case2 [<ParamObject; Emit("$0")>] (x: ResizeArray<string>) =

            member val x: ResizeArray<string> = nativeOnly with get, set

        [<Global>]
        [<AllowNullLiteral>]
        type Case3 [<ParamObject; Emit("$0")>] (y: ResizeArray<string>) =

            member val y: ResizeArray<string> = nativeOnly with get, set

        [<Global>]
        [<AllowNullLiteral>]
        type Case4 [<ParamObject; Emit("$0")>] (x: ResizeArray<string>, y: ResizeArray<string>) =

            member val x: ResizeArray<string> = nativeOnly with get, set
            member val y: ResizeArray<string> = nativeOnly with get, set

[<AllowNullLiteral>]
[<Interface>]
type VictoryAxisCommonProps<'IDelayedTypeProperty> =
    static member inline axisComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "axisComponent" value

    static member inline axisLabelComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "axisLabelComponent" value

    static member inline axisValue(value: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "axisValue" value

    static member inline axisValue(value: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "axisValue" value

    static member inline axisValue(value: obj) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "axisValue" value

    static member inline axisValue(value: JS.Date) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "axisValue" value

    static member inline dependentAxis(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "dependentAxis" value

    static member inline disableInlineStyles(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "disableInlineStyles" value

    static member inline gridComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "gridComponent" value

    static member inline invertAxis(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "invertAxis" value

    static member inline style(value: VictoryAxisCommonProps.Style list) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "style" (createObj !!value)

    static member inline tickComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickComponent" value

    static member inline tickCount(value: int) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickCount" value

    static member inline tickLabelComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickLabelComponent" value

    static member inline tickFormat(value: ResizeArray<obj>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickFormat" value

    static member inline tickFormat(value: obj list) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickFormat" (ResizeArray value)

    static member inline tickFormat(value: obj -> int -> ResizeArray<obj> -> string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty>
            "tickFormat"
            (System.Func<_, _, _> value)

    static member inline tickFormat(value: obj -> int -> ResizeArray<obj> -> float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickFormat" value

    static member inline tickValues(value: ResizeArray<obj>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickValues" value

    static member inline tickValues(value: obj list) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "tickValues" (ResizeArray value)

module VictoryAxisCommonProps =

    [<AllowNullLiteral>]
    [<Interface>]
    type Style =

        static member inline parent(style: VictoryStyleObject) : Style =
            unbox ("parent", createObj !!style)

        static member inline axis(style: VictoryStyleObject) : Style =
            unbox ("axis", createObj !!style)

        static member inline axisLabel(style: VictoryStyleObject) : Style =
            unbox ("axisLabel", createObj !!style)

        static member inline axisLabel(style: VictoryStyleObject list) : Style =
            let value = style |> List.map (unbox >> createObj) |> ResizeArray

            unbox ("axisLabel", value)

        static member inline grid(style: VictoryStyleObject) : Style =
            unbox ("grid", createObj !!style)

        static member inline ticks(style: VictoryStyleObject) : Style =
            unbox ("ticks", createObj !!style)

        static member inline tickLabels(style: VictoryStyleObject) : Style =
            unbox ("tickLabels", createObj !!style)

        static member inline tickLabels(style: VictoryStyleObject list) : Style =
            let value = style |> List.map (unbox >> createObj) |> ResizeArray

            unbox ("tickLabels", value)

[<AllowNullLiteral>]
[<Interface>]
type VictoryCommonThemeProps<'IDelayedTypeProperty> =

    static member inline animate(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "animate" value

    static member inline animate(value: obj) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "animate" value

    static member inline colorScale(value: ColorScalePropType) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "colorScale" value

    static member inline containerComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "containerComponent" value

    static member inline disableInlineStyles(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "disableInlineStyles" value

    static member inline domainPadding(value: float * float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" value

    static member inline domainPadding(value: JS.Date * JS.Date) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" value

    static member inline domainPadding(value: ForAxes.Case2<float * float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" value

    static member inline domainPadding(value: ForAxes.Case2<JS.Date * JS.Date>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "domainPadding" value

    static member inline externalEventMutations
        (value:
            ResizeArray<
                EventCallbackInterface<U2<string, ResizeArray<string>>, StringOrNumberOrList>
             >)
        =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "externalEventMutations" value

    static member inline groupComponent(value: ReactElement) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "groupComponent" value

    static member inline height(value: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "height" value

    static member inline horizontal(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "horizontal" value

    static member inline maxDomain(value: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "maxDomain" value

    static member inline maxDomain(value: VictoryCommonThemeProps.maxDomain.U2.Case2) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "maxDomain" value

    static member inline minDomain(value: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "minDomain" value

    static member inline minDomain(value: VictoryCommonThemeProps.minDomain.U2.Case2) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "minDomain" value

    static member inline name(value: string) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "name" value

    static member inline origin(value: OriginType) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "origin" value

    static member inline padding(value: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "padding" value

    static member inline padding(value: BlockProps) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "padding" value

    static member inline polar(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "polar" value

    static member inline range(value: ResizeArray<float>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "range" value

    static member inline range(value: ForAxes.Case2<ResizeArray<float>>) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "range" value

    static member inline scale(value: ScalePropType) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "scale" value

    static member inline scale(value: D3Scale) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "scale" value

    static member inline scale(value: VictoryCommonThemeProps.scale.U3.Case3) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "scale" value

    static member inline sharedEvents(value: VictoryCommonThemeProps.sharedEvents) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "sharedEvents" value

    static member inline singleQuadrantDomainPadding(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "singleQuadrantDomainPadding" value

    static member inline singleQuadrantDomainPadding
        (value: VictoryCommonThemeProps.singleQuadrantDomainPadding.U2.Case2)
        =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "singleQuadrantDomainPadding" value

    static member inline standalone(value: bool) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "standalone" value

    static member inline width(value: float) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "width" value

module VictoryCommonThemeProps =

    [<Global>]
    [<AllowNullLiteral>]
    type sharedEvents
        [<ParamObject; Emit("$0")>]
        (events: ResizeArray<obj>, getEventState: System.Action)
        =

        member val events: ResizeArray<obj> = nativeOnly with get, set
        member val getEventState: System.Action = nativeOnly with get, set

    module maxDomain =

        module U2 =

            [<Global>]
            [<AllowNullLiteral>]
            type Case2 [<ParamObject; Emit("$0")>] (?x: float, ?y: float) =

                member val x: float option = nativeOnly with get, set
                member val y: float option = nativeOnly with get, set

    module minDomain =

        module U2 =

            [<Global>]
            [<AllowNullLiteral>]
            type Case2 [<ParamObject; Emit("$0")>] (?x: float, ?y: float) =

                member val x: float option = nativeOnly with get, set
                member val y: float option = nativeOnly with get, set

    module scale =

        module U3 =

            [<Global>]
            [<AllowNullLiteral>]
            type Case3 private () =

                [<ParamObject; Emit("$0")>]
                new(?x: ScalePropType, ?y: ScalePropType) = Case3()

                [<ParamObject; Emit("$0")>]
                new(?x: D3Scale, ?y: D3Scale) = Case3()

                member val x: U2<obj, obj> option = nativeOnly with get, set
                member val y: U2<obj, obj> option = nativeOnly with get, set

    module singleQuadrantDomainPadding =

        module U2 =

            [<Global>]
            [<AllowNullLiteral>]
            type Case2 [<ParamObject; Emit("$0")>] (?x: bool, ?y: bool) =

                member val x: bool option = nativeOnly with get, set
                member val y: bool option = nativeOnly with get, set

[<AllowNullLiteral>]
[<Interface>]
type EventCallbackInterface<'TTarget, 'TEventKey> =
    abstract member childName: U2<string, ResizeArray<string>> option with get, set
    abstract member target: 'TTarget option with get, set
    abstract member eventKey: 'TEventKey option with get, set
    abstract member mutation: (obj -> obj) with get, set
    abstract member callback: (obj -> obj) option with get, set

type StringOrNumberOrList = U3<string, float, ResizeArray<U2<string, float>>>

[<AllowNullLiteral>]
[<Interface>]
type VictoryCommonProps<'IDelayedTypeProperty> =
    inherit VictoryCommonThemeProps<'IDelayedTypeProperty>

    static member inline theme(theme: IVictoryTheme) =
        Interop.mkDelayedTypeProperty<'IDelayedTypeProperty> "theme" theme

[<Global>]
[<AllowNullLiteral>]
type OriginType [<ParamObject; Emit("$0")>] (x: float, y: float) =

    member val x: float = nativeOnly with get, set
    member val y: float = nativeOnly with get, set
