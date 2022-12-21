---
id: "v1-indicatorview"
title : "IndicatorView"
description: ""
lead: ""
date: 2022-03-31T00:00:00+00:00
lastmod: 2022-03-31T00:00:00+00:00
draft: false
images: []
menu:
    docs:
        parent: "controls"
toc: true
---

## Basic example

```fs
View.StackLayout([
    View.IndicatorView(
        ref = indicatorRef,
        indicatorColor = Color.Red,
        selectedIndicatorColor = Color.Blue,
        indicatorsShape = IndicatorShape.Square
    )
    View.CarouselView(
        indicatorView = indicatorRef,
        items = [
            View.Label("First CarouselView with IndicatorView")
            View.Label("Second CarouselView with IndicatorView")
            View.Label("Third CarouselView with IndicatorView")
        ]
    )
])
```

## Basic example with styling

```fs
View.StackLayout([
    View.IndicatorView(
        horizontalOptions = style.Position,
        verticalOptions = style.Position,
        backgroundColor = style.LayoutColor,
        padding = style.Padding,
        ref = indicatorRef,
        indicatorColor = Color.Red,
        selectedIndicatorColor = Color.Blue,
        indicatorsShape = IndicatorShape.Square
    )
    View.CarouselView(
        indicatorView = indicatorRef,
        items = [
            View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor,
                padding = style.Padding,
                text = "First CarouselView with IndicatorView"
            )
            View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor2,
                padding = style.Padding,
                text = "Second CarouselView with IndicatorView"
            )
            View.Label(
                horizontalOptions = style.Position,
                verticalOptions = style.Position,
                backgroundColor = style.ViewColor3,
                padding = style.Padding,
                text = "Third CarouselView with IndicatorView"
            )
        ]
    )
])
```

See also:

* [IndicatorView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/IndicatorView)
* [`Xamarin.Forms.IndicatorView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.IndicatorView)
