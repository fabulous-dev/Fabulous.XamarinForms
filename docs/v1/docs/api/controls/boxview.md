---
id: "v1-boxview"
title : "BoxView"
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
View.BoxView()
```

## Basic example with styling

```fs
View.BoxView(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.ViewColor
)
```

See also:

* [BoxView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/BoxView)
* [`Xamarin.Forms.BoxView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.BoxView)

## More examples

An example `BoxView` is as follows:

```fs
View.BoxView(
    color = Color.CornflowerBlue,
    cornerRadius = CornerRadius 10.,
    horizontalOptions = LayoutOptions.Center
)
```

<img src="https://user-images.githubusercontent.com/6429007/60753625-c1377b80-9fd5-11e9-91cc-eaef04a372cf.png" width="400">
