namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms.Shapes

type IRotateTransform =
    inherit ITransform

module RotateTransform =
    let WidgetKey = Widgets.register<RotateTransform>()

    let Angle = Attributes.defineBindableFloat RotateTransform.AngleProperty

    let CenterX = Attributes.defineBindableFloat RotateTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat RotateTransform.CenterYProperty

[<AutoOpen>]
module RotateTransformBuilders =

    type Fabulous.XamarinForms.View with

        static member inline RotateTransform<'msg>(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )
