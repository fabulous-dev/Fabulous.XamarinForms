---
id: "v1-shell"
title : "Shell"
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

Xamarin.Forms Shell reduces the complexity of mobile application development by providing the fundamental features that most mobile applications require. This includes a common navigation user experience, a URI-based navigation scheme, and an integrated search handler.

`Unfortunately Shell is only partially supported in Fabulous for technical reasons, so it is recommended not to use it for the moment.`

```fs
View.Shell(
    title = "TitleShell",
    items = [
        View.FlyoutItem(
            title = "Flyout",
            flyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
            items = [
                View.Tab(
                    title = "Seiten",
                    items = [
                        View.ShellContent(
                            title = "welcome",
                            content =
                                View.ContentPage(
                                    View.Label("welcome ...")
                                )
                        )
                        View.ShellContent(
                            title = "stuff",
                            content =
                                View.ContentPage(
                                    View.Label("stuff ...")
                                )
                        )
                    ]
                )
                View.ShellContent(
                    title = "more",
                    content =
                        View.ContentPage(
                            View.Label("more stuff ...")
                        )
                )
            ]
        )
        View.MenuItem(text = "config")
    ]
)
```

See also:

* [Xamarin guide to Shell](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/shell)
* [`Xamarin.Forms.Core.Shell`](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.shell)
