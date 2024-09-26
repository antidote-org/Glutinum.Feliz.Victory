namespace Glutinum.Feliz.Victory

module Utils =

    let inline resolveOp_Implicit< ^a, ^b when (^a or ^b): (static member op_Implicit: ^a -> ^b)>
        (value: ^a)
        : ^b
        =
        ((^a or ^b): (static member inline op_Implicit: ^a -> ^b) value)
