namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Xamarin.Forms
open Fabulous

type ISelectableItemsView = inherit IStructuredItemsView

module SelectableItemsView =
    let SelectionMode =
        Attributes.defineBindableEnum<SelectionMode> CollectionView.SelectionModeProperty

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs> "CollectionView_SelectionChanged" (fun target -> (target :?> CollectionView).SelectionChanged)
        
[<Extension>]
type SelectableItemsView =
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #ISelectableItemsView>, value: SelectionMode) =
        this.AddScalar(SelectableItemsView.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #ISelectableItemsView>, onSelectionChanged: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(SelectableItemsView.SelectionChanged.WithValue(fun args -> onSelectionChanged args |> box))