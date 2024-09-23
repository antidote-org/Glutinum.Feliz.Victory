namespace Glutinum.Feliz.Victory

module Utils =

    let inline resolveOp_Implicit (value: ^a) : ^b =
        ((^a or ^b): (static member inline op_Implicit: ^a -> ^b) value)
