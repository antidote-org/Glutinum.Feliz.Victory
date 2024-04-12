namespace Glutinum.Feliz.Victory

open Glutinum.Feliz.Victory.Types
open Fable.Core.JsInterop

module Interop =

    let inline mkVictoryChartProperty (name : string) (value : obj) : IVictoryChartProperty = unbox(name, value)

    let inline mkAreaChartProperty (name : string) (value : obj) : IAreaChartProperty = unbox(name, value)

    let inline mkVictoryDatableProps (name : string) (value : obj) : IVictoryDatableProps = unbox(name, value)

    let inline mkDelayedTypeProperty<'IDelayedTypeProperty> (name : string) (value : obj) : 'IDelayedTypeProperty = unbox(name, value)

//     let registerFunctions () =
//         // Allow to transform the inner properties of an object from a list
//         // into a POJO (Plain Old JavaScript Object)
//         // See VictoryStyleInterface
//         // The other solution would be to
//         emitJsStatement (createObj) """
// window.GlutinumFelizVictory_ObjectifyObjectProperties = function (o) {
//     let result = {};
//     for (const [key, value] of Object.entries(o)) {
//         result[key] = $0(value);
//     }
//     return result;
// }
//         """
