# Templates for Fabulous.XamarinForms

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

## How to use the templates

Using the dotnet CLI, install the templates:

```sh
dotnet new -i Fabulous.XamarinForms.Templates
```

Then, you will be able to create new Fabulous.XamarinForms projects with `dotnet new`:

```sh
dotnet new fabulous-xf -n MyApp
```

If you're using Visual Studio on Windows, prefer the `fabulous-xf-vswin` template instead.

```sh
dotnet new fabulous-xf-vswin -n MyApp
```