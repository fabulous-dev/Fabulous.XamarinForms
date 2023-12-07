namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICell =
    inherit IElement

module Cell =
    let IsEnabled = Attributes.defineBindableBool Cell.IsEnabledProperty

    let Height =
        Attributes.defineFloat "Cell_Height" (fun _ newValueOpt node ->
            let cell = node.Target :?> Cell

            let value =
                match newValueOpt with
                | ValueNone -> cell.Height
                | ValueSome v -> v

            cell.Height <- value)

    let Appearing =
        Attributes.defineEventNoArg "Cell_Appearing" (fun target -> (target :?> Cell).Appearing)

    let Disappearing =
        Attributes.defineEventNoArg "Cell_Disappearing" (fun target -> (target :?> Cell).Disappearing)

    let Tapped =
        Attributes.defineEventNoArg "Cell_Tapped" (fun target -> (target :?> Cell).Tapped)

    let ContextActions =
        Attributes.defineListWidgetCollection "Cell_ContextActions" (fun target -> (target :?> Cell).ContextActions)

[<Extension>]
type CellModifiers =

    /// <summary>Sets a value that indicates whether the cell IsEnabled</summary>
    /// <param name="value">true if the cell IsEnabled; otherwise, false.</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #ICell>, value: bool) =
        this.AddScalar(Cell.IsEnabled.WithValue(value))

    /// <summary>Sets the height of the cell</summary>
    /// <param name="value">The height of the cell</param>
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #ICell>, value: float) =
        this.AddScalar(Cell.Height.WithValue(value))

    [<Extension>]
    static member inline onAppearing(this: WidgetBuilder<'msg, #ICell>, onAppearing: 'msg) =
        this.AddScalar(Cell.Appearing.WithValue(MsgValue onAppearing))

    [<Extension>]
    static member inline onDisappearing(this: WidgetBuilder<'msg, #ICell>, onDisappearing: 'msg) =
        this.AddScalar(Cell.Disappearing.WithValue(MsgValue onDisappearing))

    [<Extension>]
    static member inline onTapped(this: WidgetBuilder<'msg, #ICell>, onTapped: 'msg) =
        this.AddScalar(Cell.Tapped.WithValue(MsgValue onTapped))

    [<Extension>]
    static member inline contextActions<'msg, 'marker when 'marker :> ICell>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IMenuItem> Cell.ContextActions this
