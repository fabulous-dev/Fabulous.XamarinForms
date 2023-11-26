namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICollectionView =
    inherit IReordableItemsView

module CollectionView =
    let WidgetKey = Widgets.register<CollectionView>()

[<AutoOpen>]
module CollectionViewBuilders =
    type Fabulous.XamarinForms.View with

        static member inline CollectionView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IView>(items: seq<'itemData>) =
            WidgetHelpers.buildItems<'msg, ICollectionView, 'itemData, 'itemMarker> CollectionView.WidgetKey ItemsView.ItemsSource items

        static member inline GroupedCollectionView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker
            when 'itemMarker :> IView and 'groupMarker :> IView and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItems<'msg, ICollectionView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                CollectionView.WidgetKey
                GroupableItemsView.GroupedItemsSource
                items

[<Extension>]
type CollectionViewModifiers =

    /// <summary>Link a ViewRef to access the direct CollectionView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ICollectionView>, value: ViewRef<CollectionView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
