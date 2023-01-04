---
id: "v1-collectionview"
title : "CollectionView"
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

displays a scrollable list of selectable data items, using different layout specifications

Please read the Xamarin.Forms documentation to check whether this control is available for the platforms you target.

## Basic example

```fs
View.CollectionView([
    View.Label("First CollectionView")
    View.Label("Second CollectionView")
    View.Label("Third CollectionView")
])
```

## Basic example with styling

```fs
View.CollectionView(
    horizontalOptions = style.Position,
    verticalOptions = style.Position,
    backgroundColor = style.LayoutColor,
    items = [
        View.Label(
            horizontalOptions = style.Position,
            verticalOptions = style.Position,
            backgroundColor = style.ViewColor,
            padding = style.Padding,
            text = "First CollectionView"
        )
        View.Label(
            horizontalOptions = style.Position,
            verticalOptions = style.Position,
            backgroundColor = style.ViewColor2,
            padding = style.Padding,
            text = "Second CollectionView"
        )
        View.Label(
            horizontalOptions = style.Position,
            verticalOptions = style.Position,
            backgroundColor = style.ViewColor3,
            padding = style.Padding,
            text = "Third CollectionView"
        )
    ] 
)
```

See also:

* [CollectionView in Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/CollectionView)
* [`Xamarin.Forms.CollectionView`](https://docs.microsoft.com/en-us/dotnet/api/Xamarin.Forms.CollectionView)

## More examples

<img src="https://user-images.githubusercontent.com/52166903/60262083-4683a780-98d5-11e9-8afc-cde4d594171b.png" width="400">
