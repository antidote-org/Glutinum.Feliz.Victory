namespace rec Glutinum.Feliz.Victory

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Glutinum.Feliz.Victory.Types

[<AllowNullLiteral>]
[<Interface>]
type VictoryThemeBase =
    abstract material: IVictoryTheme with get, set
    abstract grayscale: IVictoryTheme with get, set
    abstract clean: IVictoryTheme with get, set
