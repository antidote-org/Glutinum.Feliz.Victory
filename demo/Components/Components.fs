module Demo.Components

open Fable.Core.JsInterop
open Feliz

type ICodeProperty = interface end

type Components =

    static member Code (code: string) (language: string) =
        Interop.reactApi.createElement (
            import "default" "${outDir}/Code.tsx",
            {|
                code = code
                language = language
            |}
        )
