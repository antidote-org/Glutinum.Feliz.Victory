namespace Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<Global>]
[<AllowNullLiteral>]
type OriginType [<ParamObject; Emit("$0")>] (x: float, y: float) =

    member val x: float = nativeOnly with get, set
    member val y: float = nativeOnly with get, set
