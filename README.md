# Fabulous for Xamarin.Forms

[![build](https://img.shields.io/github/actions/workflow/status/fabulous-dev/Fabulous.XamarinForms/build.yml?branch=main)](https://github.com/fabulous-dev/Fabulous.XamarinForms/actions/workflows/build.yml) [![NuGet version](https://img.shields.io/nuget/v/Fabulous.XamarinForms)](https://www.nuget.org/packages/Fabulous.XamarinForms) [![NuGet downloads](https://img.shields.io/nuget/dt/Fabulous.XamarinForms)](https://www.nuget.org/packages/Fabulous.XamarinForms) [![Discord](https://img.shields.io/discord/716980335593914419?label=discord&logo=discord)](https://discord.gg/bpTJMbSSYK) [![Twitter Follow](https://img.shields.io/twitter/follow/FabulousAppDev?style=social)](https://twitter.com/FabulousAppDev)

Fabulous.XamarinForms brings the great development experience of Fabulous to Xamarin.Forms, allowing you to harvest the vast ecosystem of Xamarin.Forms with a tailored declarative UI DSL and clean architecture.

Deploy to any platform supported by Xamarin.Forms, such as Android, iOS, macOS, Windows, Linux and more!

```fs
/// A simple Counter app

type Model =
    { Count: int }

type Msg =
    | Increment
    | Decrement

let init () =
    { Count = 0 }

let update msg model =
    match msg with
    | Increment -> { model with Count = model.Count + 1 }
    | Decrement -> { model with Count = model.Count - 1 }

let view model =
    Application(
        ContentPage(
            "Counter app",
            VStack(spacing = 16.) {
                Image(Aspect.AspectFit, "fabulous.png")

                Label($"Count is {model.Count}")

                Button("Increment", Increment)
                Button("Decrement", Decrement)
            }
        )
    )
```

To learn more about Fabulous, visit https://fabulous.dev.

### Getting Started

You can start your new Fabulous.XamarinForms app in a matter of seconds using the dotnet CLI templates.  
For a starter guide see our [documentation](https://docs.fabulous.dev/v2/xamarin.forms/getting-started).

```sh
dotnet new -i Fabulous.XamarinForms.Templates
dotnet new fabulous-xf -n MyApp
```

If you are developing with Visual Studio on Windows, use the `fabulous-xf-vswin` template instead.
```sh
dotnet new fabulous-xf-vswin -n MyApp
```

### Documentation

Documentation can be found at https://docs.fabulous.dev/v2/xamarin.forms

### Sponsor Fabulous

Donating is a fantastic way to support all the efforts going into making Fabulous the best declarative UI framework for dotnet.

If you need support see Commercial Support section below.

### Commercial support

If you would like us to provide you with:

- training and workshops,
- support services,
- and consulting services.

Feel free to contact us on Twitter: [@Tim_Lariviere](https://twitter.com/Tim_Lariviere), [@efgpdev](https://twitter.com/efgpdev)
