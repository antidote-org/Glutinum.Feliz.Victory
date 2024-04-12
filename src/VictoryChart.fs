namespace Glutinum.Feliz.Victory

open Fable.Core
open Feliz

[<Erase>]
type victoryChart =

    static member inline children(elems: Fable.React.ReactElement seq) =
        Interop.mkVictoryChartProperty
            "children"
            (Interop.reactApi.Children.toArray (Array.ofSeq elems))

    static member inline custom (name : string) (value : obj) =
        Interop.mkVictoryChartProperty name value
