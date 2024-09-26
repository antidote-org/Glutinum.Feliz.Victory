module Demo.Html

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Feliz.UseDeferred
open System.Text.RegularExpressions
open Demo.Components
open type Demo.Components.Components

open System.Runtime.CompilerServices
open System.Runtime.InteropServices

let private fileCache = Map<string, string> []

type Html =
    [<ReactComponent>]
    static member previewChart
        (
            child: ReactElement,
            [<CallerFilePath; Optional; DefaultParameterValue("")>] filePath: string,
            [<CallerLineNumber; Optional; DefaultParameterValue(0)>] fileLine: int,
            [<CallerMemberName; Optional; DefaultParameterValue("")>] memberName: string
        )
        =
        let loadData =
            promise {
                let index = filePath.IndexOf("/demo/")
                let sourceFile = filePath.Substring(index)
                let baseUrl =
                    #if DEBUG
                    "http://127.0.0.1:8080"
                    #else
                    "https://raw.githubusercontent.com/antidote-org/Glutinum.Feliz.Victory/refs/heads/main"
                    #endif

                let! res = Fetch.fetch $"%s{baseUrl}/%s{sourceFile}" []
                let! text = res.text()

                let lines = text.Replace("\r", "").Split("\n")

                let locator = Regex($"^let.*%s{memberName}.*=")

                let res =
                    lines
                    // Skip until we find the correct let binding
                    |> Array.skipWhile (fun line ->
                        let m = locator.Match(line)

                        not m.Success
                    )
                    // Skip the let binding line
                    |> Array.skip 1
                    // Capture text until the next top level let binding
                    |> Array.takeWhile (fun line ->
                        // not (line.StartsWith("let "))
                        not (line.EndsWith("Html.previewChart"))
                    )
                    |> Array.map (fun line ->
                        // Remove the leading indentation
                        if line.Length > 4 then
                            line.Substring(4)
                        else
                            line
                    )
                    |> String.concat "\n"

                return res
            }
            |> Async.AwaitPromise

        let data = React.useDeferred(loadData, [| |])

        Html.div [
            // prop.className missingCss.textcolumns
            prop.className "example"
            prop.style [
                unbox ("columns", 2)
                style.display.grid
                style.gridTemplateColumns [
                    length.fr 1
                    length.fr 1
                ]
                style.gap (length.px 20)
            ]
            prop.children [
                Html.div [
                    prop.className missingCss.box
                    prop.style [
                        style.marginTop (length.px 0)
                        style.maxHeight (length.px 400)
                    ]
                    prop.children [
                        child
                    ]
                ]
                match data with
                | Deferred.HasNotStartedYet
                | Deferred.InProgress ->
                    Html.div [
                        prop.text "Loading..."
                    ]
                | Deferred.Resolved code ->
                    Code code "fsharp"
                | Deferred.Failed ex ->
                    Html.div [
                        prop.text (sprintf "Error: %s" ex.Message)
                    ]
            ]
        ]

let renderDemoPage (title: string) (content: ReactElement) =
    React.fragment [
        Html.h1 [
            prop.text title
        ]

        content
    ]

let renderExample (title: string) (child: ReactElement) =
    React.fragment [
        Html.h2 [
            prop.id title
            prop.children [
                Html.text title
                Html.a [
                    prop.href (sprintf "#%s" title)
                    prop.text "#"
                    prop.className missingCss.``permalink-anchor``
                    prop.style [
                        style.marginLeft (length.rem 0.5)
                    ]
                ]
            ]
        ]
        child
    ]
