﻿namespace FabulousContacts.Controls

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type UnderlinedLabel() =
    inherit Label()

[<AutoOpen>]
module FabulousUnderlinedLabel =
    let UnderlinedLabelKey = Widgets.register<UnderlinedLabel>()

    type IUnderlinedLabel =
        inherit ILabel

    type Fabulous.XamarinForms.View with

        static member inline UnderlinedLabel<'msg>(text) =
            WidgetBuilder<'msg, IUnderlinedLabel>(UnderlinedLabelKey, Label.Text.WithValue(text))
