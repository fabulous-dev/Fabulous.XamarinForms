namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Xamarin.Forms

type IItemsLayout = interface end

module ItemsLayout =
    let Orientation: SmallScalarAttributeDefinition<ItemsLayoutOrientation> = Attributes.defineSmallScalar "ItemsLayout_Orientation" SmallScalars.IntEnum.decode (fun _ _ _ -> ())
    let SnapPointsAlignment = Attributes.defineBindableEnum<SnapPointsAlignment> ItemsLayout.SnapPointsAlignmentProperty
    let SnapPointsType = Attributes.defineBindableEnum<SnapPointsType> ItemsLayout.SnapPointsTypeProperty
    
[<Extension>]
type ItemsLayoutModifiers =
    [<Extension>]
    static member snapPointsAlignment(this: WidgetBuilder<'msg, #IItemsLayout>, value: SnapPointsAlignment) =
        this.AddScalar(ItemsLayout.SnapPointsAlignment.WithValue(value))
    
    [<Extension>]
    static member snapPointsType(this: WidgetBuilder<'msg, #IItemsLayout>, value: SnapPointsType) =
        this.AddScalar(ItemsLayout.SnapPointsType.WithValue(value))