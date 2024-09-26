module EasyBuild.Commands.Demo

open Spectre.Console.Cli
open SimpleExec
open EasyBuild.Workspace
open BlackFox.CommandLine

type DemoSettings() =
    inherit CommandSettings()

    [<CommandOption("-w|--watch")>]
    member val IsWatch = false with get, set

type DemoCommand() =
    inherit Command<DemoSettings>()
    interface ICommandLimiter<DemoSettings>

    override __.Execute(context, settings) =

        Command.Run("npm", "install")

        // Make sure we have CssModules.fs generated
        Command.Run("npx", "fcm", workingDirectory = Workspace.demo.``.``)

        if settings.IsWatch then
            Async.Parallel [
                Command.RunAsync(
                    "dotnet",
                    CmdLine.empty
                    |> CmdLine.appendRaw "fable"
                    |> CmdLine.appendRaw "watch"
                    |> CmdLine.appendRaw Workspace.demo.``.``
                    |> CmdLine.appendRaw "--test:MSBuildCracker"
                    |> CmdLine.appendRaw "--verbose"
                    |> CmdLine.toString
                )
                |> Async.AwaitTask

                Command.RunAsync("npx", "vite", workingDirectory = Workspace.demo.``.``)
                |> Async.AwaitTask

                // We need to have a server to serve the source files to mimic the hosting from Github Raw
                Command.RunAsync("npx", "http-server --cors", workingDirectory = Workspace.``.``)
                |> Async.AwaitTask

                Command.RunAsync(
                    "npx",
                    CmdLine.empty
                    |> CmdLine.appendRaw "nodemon"
                    |> CmdLine.appendPrefix "-e" "module.css"
                    |> CmdLine.appendPrefix "--exec" "fcm"
                    |> CmdLine.toString,
                    workingDirectory = Workspace.demo.``.``
                )
                |> Async.AwaitTask
            ]
            |> Async.RunSynchronously
            |> ignore

        else
            Command.Run(
                "dotnet",
                CmdLine.empty
                |> CmdLine.appendRaw "fable"
                |> CmdLine.appendRaw Workspace.demo.``.``
                |> CmdLine.appendRaw "--test:MSBuildCracker"
                |> CmdLine.toString
            )

            Command.Run("npx", "vite build", workingDirectory = Workspace.demo.``.``)

        0
