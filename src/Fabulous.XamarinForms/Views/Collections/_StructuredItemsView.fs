namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IStructuredItemsView = inherit IItemsView

module StructuredItemsView =
    let Footer = Attributes.defineBindableWidget StructuredItemsView.FooterProperty
    
    let Header = Attributes.defineBindableWidget StructuredItemsView.HeaderProperty
    
    let ItemsSizingStrategy = Attributes.defineBindableEnum<ItemSizingStrategy> StructuredItemsView.ItemSizingStrategyProperty
    
    let ItemsLayout = Attributes.defineBindableWidget StructuredItemsView.ItemsLayoutProperty
    
[<Extension>]
type StructuredItemsViewModifiers =
    [<Extension>]
    static member inline footer<'msg, 'marker, 'contentMarker when 'marker :> IStructuredItemsView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(StructuredItemsView.Footer.WithValue(content.Compile()))
        
    [<Extension>]
    static member inline header<'msg, 'marker, 'contentMarker when 'marker :> IStructuredItemsView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(StructuredItemsView.Header.WithValue(content.Compile()))

    [<Extension>]
    static member inline itemsSizingStrategy<'msg, 'marker when 'marker :> IStructuredItemsView>(this: WidgetBuilder<'msg, 'marker>, value: ItemSizingStrategy) =
        this.AddScalar(StructuredItemsView.ItemsSizingStrategy.WithValue(value))
        
    [<Extension>]
    static member inline itemsLayout<'msg, 'marker, 'contentMarker when 'marker :> IStructuredItemsView and 'contentMarker :> Fabulous.XamarinForms.IItemsLayout>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(StructuredItemsView.ItemsLayout.WithValue(content.Compile()))