namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type IGroupableItemsView = inherit ISelectableItemsView

module GroupableItemsView =
        let GroupedItemsSource =
            Attributes.defineSimpleScalar<GroupedWidgetItems>
                "CollectionView_GroupedItemsSource"
                (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
                (fun _ newValueOpt node ->
                    let collectionView = node.Target :?> GroupableItemsView

                    match newValueOpt with
                    | ValueNone ->
                        collectionView.IsGrouped <- false
                        collectionView.ClearValue(CollectionView.ItemsSourceProperty)
                        collectionView.ClearValue(CollectionView.GroupHeaderTemplateProperty)
                        collectionView.ClearValue(CollectionView.GroupFooterTemplateProperty)
                        collectionView.ClearValue(CollectionView.ItemTemplateProperty)

                    | ValueSome value ->
                        collectionView.IsGrouped <- true

                        collectionView.SetValue(CollectionView.ItemTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.ItemTemplate))

                        collectionView.SetValue(CollectionView.GroupHeaderTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.HeaderTemplate))

                        if value.FooterTemplate.IsSome then
                            collectionView.SetValue(
                                CollectionView.GroupFooterTemplateProperty,
                                WidgetDataTemplateSelector(node, unbox >> value.FooterTemplate.Value)
                            )

                        collectionView.SetValue(CollectionView.ItemsSourceProperty, value.OriginalItems))