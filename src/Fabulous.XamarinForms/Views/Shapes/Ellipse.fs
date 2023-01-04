namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IEllipse =
    inherit IShape


module Ellipse =

    let WidgetKey = Widgets.register<Ellipse>()

[<AutoOpen>]
module EllipseBuilders =

    type Fabulous.XamarinForms.View with

        static member inline Ellipse<'msg>(strokeThickness: float, strokeLight: Brush, ?strokeDark: Brush) =
            WidgetBuilder<'msg, IEllipse>(
                Ellipse.WidgetKey,
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

[<Extension>]
type EllipseModifiers =
    /// <summary>Link a ViewRef to access the direct Ellipse control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IEllipse>, value: ViewRef<Ellipse>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
