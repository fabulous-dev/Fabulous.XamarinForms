namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ILinearItemsLayout = inherit Fabulous.XamarinForms.IItemsLayout

module LinearItemsLayout =    
    let WidgetKey = Widgets.registerWithFactory(fun widget ->                
        let orientation =
            match widget.ScalarAttributes with
            | ValueNone -> failwith "LinearItemsLayout must have an orientation attribute"
            | ValueSome attrs ->
                match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = ItemsLayout.Orientation.Key) attrs with
                | None -> failwith "LinearItemsLayout must have an orientation attribute"
                | Some attr -> SmallScalars.IntEnum.decode<ItemsLayoutOrientation> attr.NumericValue
        
        LinearItemsLayout(orientation)
    )
    
    let ItemSpacing = Attributes.defineBindableWithEquality<float> LinearItemsLayout.ItemSpacingProperty

[<AutoOpen>]
module LinearItemsBuilders =
    type Fabulous.XamarinForms.View with
        static member inline LinearItemsLayout(orientation: ItemsLayoutOrientation) =
            WidgetBuilder<'msg, ILinearItemsLayout>(
                LinearItemsLayout.WidgetKey,
                ItemsLayout.Orientation.WithValue(orientation)
            )
            
[<Extension>]
type LinearItemsLayoutExtensions =
    [<Extension>]
    static member inline itemSpacing(this: WidgetBuilder<'msg, #ILinearItemsLayout>, value: float) =
        this.AddScalar(LinearItemsLayout.ItemSpacing.WithValue(value))
        
    /// <summary>Link a ViewRef to access the direct LinearItemsLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IListView>, value: ViewRef<LinearItemsLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))