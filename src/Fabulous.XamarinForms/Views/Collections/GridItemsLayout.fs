namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Xamarin.Forms

type IGridItemsLayout =
    inherit Fabulous.XamarinForms.IItemsLayout

module GridItemsLayout =
    let Span = Attributes.defineBindableInt GridItemsLayout.SpanProperty

    let WidgetKey =
        Widgets.registerWithFactory(fun widget ->
            let span =
                match widget.ScalarAttributes with
                | ValueNone -> ValueNone
                | ValueSome attrs ->
                    match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Span.Key) attrs with
                    | None -> ValueNone
                    | Some attr -> ValueSome(SmallScalars.Int.decode attr.NumericValue)

            let orientation =
                match widget.ScalarAttributes with
                | ValueNone -> failwith "GridItemsLayout must have an orientation attribute"
                | ValueSome attrs ->
                    match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = ItemsLayout.Orientation.Key) attrs with
                    | None -> failwith "GridItemsLayout must have an orientation attribute"
                    | Some attr -> SmallScalars.IntEnum.decode<ItemsLayoutOrientation> attr.NumericValue

            match span with
            | ValueNone -> GridItemsLayout(orientation)
            | ValueSome span -> GridItemsLayout(span, orientation))

    let HorizontalItemSpacing =
        Attributes.defineBindableFloat GridItemsLayout.HorizontalItemSpacingProperty

    let VerticalItemSpacing =
        Attributes.defineBindableFloat GridItemsLayout.VerticalItemSpacingProperty

[<AutoOpen>]
module GridItemsBuilders =
    type Fabulous.XamarinForms.View with

        static member inline GridItemsLayout(orientation: ItemsLayoutOrientation) =
            WidgetBuilder<'msg, IGridItemsLayout>(GridItemsLayout.WidgetKey, ItemsLayout.Orientation.WithValue(orientation))

[<Extension>]
type GridItemsLayoutExtensions =
    [<Extension>]
    static member inline horizontalItemSpacing(this: WidgetBuilder<'msg, #IGridItemsLayout>, value: float) =
        this.AddScalar(GridItemsLayout.HorizontalItemSpacing.WithValue(value))

    [<Extension>]
    static member inline span(this: WidgetBuilder<'msg, #IGridItemsLayout>, value: int) =
        this.AddScalar(GridItemsLayout.Span.WithValue(value))

    [<Extension>]
    static member inline verticalItemSpacing(this: WidgetBuilder<'msg, #IGridItemsLayout>, value: float) =
        this.AddScalar(GridItemsLayout.VerticalItemSpacing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct GridItemsLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IListView>, value: ViewRef<GridItemsLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
