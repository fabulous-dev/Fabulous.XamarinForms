namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IItemsView =
    inherit IView

module ItemsView =
    let ItemsSource<'T> =
        Attributes.defineSimpleScalar<WidgetItems<'T>>
            "ItemsView_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ItemsView

                match newValueOpt with
                | ValueNone ->
                    itemsView.ClearValue(ItemsView.ItemTemplateProperty)
                    itemsView.ClearValue(ItemsView.ItemsSourceProperty)
                | ValueSome value ->
                    itemsView.SetValue(ItemsView.ItemTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.Template))

                    itemsView.SetValue(ItemsView.ItemsSourceProperty, value.OriginalItems))

    let EmptyView = Attributes.defineBindableWidget ItemsView.EmptyViewProperty

    let RemainingItemsThreshold =
        Attributes.defineBindableInt ItemsView.RemainingItemsThresholdProperty

    let RemainingItemsThresholdReached =
        Attributes.defineEventNoArg "ItemsView_RemainingItemsThresholdReached" (fun target -> (target :?> ItemsView).RemainingItemsThresholdReached)

    let HorizontalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ItemsView.HorizontalScrollBarVisibilityProperty

    let VerticalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ItemsView.VerticalScrollBarVisibilityProperty

    let ItemsUpdatingScrollMode =
        Attributes.defineBindableEnum<ItemsUpdatingScrollMode> ItemsView.ItemsUpdatingScrollModeProperty

    let ScrollToRequested =
        Attributes.defineEvent<ScrollToRequestEventArgs> "ItemsView_ScrolledRequested" (fun target -> (target :?> ItemsView).ScrollToRequested)

    let Scrolled =
        Attributes.defineEvent<ItemsViewScrolledEventArgs> "ItemsView_Scrolled" (fun target -> (target :?> ItemsView).Scrolled)

[<Extension>]
type ItemsViewModifiers =

    /// <summary>The threshold of items not yet visible in the list at which the RemainingItemsThresholdReached event will be fired.</summary>
    /// <param name="value">The threshold of items not yet visible in the list</param>
    /// <param="onThresholdReached">Event executed when the RemainingItemsThreshold is reached</param>
    [<Extension>]
    static member inline remainingItemsThreshold(this: WidgetBuilder<'msg, #IItemsView>, value: int, onThresholdReached: 'msg) =
        this
            .AddScalar(ItemsView.RemainingItemsThreshold.WithValue(value))
            .AddScalar(ItemsView.RemainingItemsThresholdReached.WithValue(onThresholdReached))

    /// <summary>Sets the visibility of the horizontal scroll bar.</summary>
    /// <param name="value">true if the horizontal scroll is enabled; otherwise, false.</param>
    [<Extension>]
    static member inline horizontalScrollBarVisibility(this: WidgetBuilder<'msg, #IItemsView>, value: ScrollBarVisibility) =
        this.AddScalar(ItemsView.HorizontalScrollBarVisibility.WithValue(value))

    /// <summary>Sets the visibility of the vertical scroll bar.</summary>
    /// <param name="value">true if the vertical scroll is enabled; otherwise, false.</param>
    [<Extension>]
    static member inline verticalScrollBarVisibility(this: WidgetBuilder<'msg, #IItemsView>, value: ScrollBarVisibility) =
        this.AddScalar(ItemsView.VerticalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline itemsUpdatingScrollMode(this: WidgetBuilder<'msg, #IItemsView>, value: ItemsUpdatingScrollMode) =
        this.AddScalar(ItemsView.ItemsUpdatingScrollMode.WithValue(value))

    [<Extension>]
    static member inline onScrollToRequested(this: WidgetBuilder<'msg, #IItemsView>, onScrollToRequested: ScrollToRequestEventArgs -> 'msg) =
        this.AddScalar(ItemsView.ScrollToRequested.WithValue(fun args -> onScrollToRequested args |> box))

    [<Extension>]
    static member inline onScrolled(this: WidgetBuilder<'msg, #IItemsView>, onScrolled: ItemsViewScrolledEventArgs -> 'msg) =
        this.AddScalar(ItemsView.Scrolled.WithValue(fun args -> onScrolled args |> box))

    [<Extension>]
    static member inline emptyView<'msg, 'marker, 'contentMarker when 'marker :> IItemsView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(ItemsView.EmptyView.WithValue(content.Compile()))
