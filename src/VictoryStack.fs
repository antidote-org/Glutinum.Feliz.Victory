namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<Erase>]
[<Interface>]
type VictoryStackProps =
    inherit VictoryLabelableProps<IVictoryStackProperty>
    inherit VictoryMultiLabelableProps<IVictoryStackProperty>

    static member inline bins (bins: int) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "bins" bins

    static member inline bins (bins: ResizeArray<int>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "bins" bins

    static member inline bins (bins: ResizeArray<JS.Date>) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "bins" bins

    static member inline categories (categories: CategoryPropType) =
        Interop.mkDelayedTypeProperty<IVictoryStackProperty> "categories" categories

[<Erase>]
[<Interface>]
type VictoryStack =
    inherit VictoryStackProps
