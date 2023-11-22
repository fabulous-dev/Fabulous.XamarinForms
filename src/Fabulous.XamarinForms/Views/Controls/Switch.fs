namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ISwitch =
    inherit IView

module Switch =
    let WidgetKey = Widgets.register<Switch>()

    let ColorOn = Attributes.defineBindableAppThemeColor Switch.OnColorProperty

    let ThumbColor = Attributes.defineBindableAppThemeColor Switch.ThumbColorProperty

    let IsToggledWithEvent =
        Attributes.defineBindableWithEvent "Switch_Toggled" Switch.IsToggledProperty (fun target -> (target :?> Switch).Toggled)

[<AutoOpen>]
module SwitchBuilders =
    type Fabulous.XamarinForms.View with

        static member inline Switch<'msg>(isToggled: bool, onToggled: bool -> 'msg) =
            WidgetBuilder<'msg, ISwitch>(
                Switch.WidgetKey,
                Switch.IsToggledWithEvent.WithValue(ValueEventData.create isToggled (fun (args: ToggledEventArgs) -> onToggled args.Value))
            )

[<Extension>]
type SwitchModifiers =
    /// <summary>Set the color of the thumbColor.</summary>
    /// <param name="light">The color of the thumbColor in the light theme.</param>
    /// <param name="dark">The color of the thumbColor in the dark theme.</param>
    [<Extension>]
    static member inline thumbColor(this: WidgetBuilder<'msg, #ISwitch>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Switch.ThumbColor.WithValue(AppTheme.create light dark))

    /// <summary>Set the color of the on state.</summary>
    /// <param name="light">The color of the on state in the light theme.</param>
    /// <param name="dark">The color of the on state in the dark theme.</param>
    [<Extension>]
    static member inline colorOn(this: WidgetBuilder<'msg, #ISwitch>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Switch.ColorOn.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct Switch control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISwitch>, value: ViewRef<Switch>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
