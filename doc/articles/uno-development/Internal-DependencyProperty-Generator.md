# The DependencyProperty Generator

Uno provides an internal `DependencyPproperty` code generator, used to provide the boiler plate for the property, as well as the handling of local-precedence property value caching.

This generator is not available outside of Uno as it is very specific to the needs of the internals of Uno.

## DependencyProperty declaration

To declare a dependency property, the following code must be provided:

```csharp
[Uno.UI.Xaml.GeneratedDependencyProperty(DefaultValue = "")]
public string MyString
{
    get => GetMyStringValue();
    set => SetMyStringValue(value);
}
```

This will automatically generate the `MyStringProperty` member.

## DependencyProperty property changed

```csharp
[Uno.UI.Xaml.GeneratedDependencyProperty(DefaultValue = "")]
public string MyString
{
    get => GetMyStringValue();
    set => SetMyStringValue(value);
}

private void OnMyStringChanged(string oldValue, string newValue) 
{
}
```

Declaring an `OnMyStringChanged` will automatically include that method for the property changed. To ensure that the method is defined and used, set the `PropertyChangedCallback` attribute parameter.

The following callback signature is also supported:

```csharp
private void OnMyStringChanged(DependencyPropertyChangedEventArgs args) 
{
}
```

## Attached DependencyProperties generation

Attached dependency properties need to be declared this way, with the `GeneratedDependencyProperty` located on the `GetXXX` method:

```csharp
[GeneratedDependencyProperty(DefaultValue = 0.0d, AttachedBackingFieldOwner = typeof(UIElement))]
public static double GetLeft(DependencyObject obj)
    => GetLeftValue(obj);

public static void SetLeft(DependencyObject obj, double value)
    => SetLeftValue(obj, value);
```

This dependency property will be declared as `LeftProperty`, with the local-precedence cache backing field included in the `UIElement` class.

## DependencyProperty local precedence caching

This feature is about storing the current value that can be read through the C# property getter, or the `GetXXX` method of an attached property. The objective of this feature is to avoid spending time in the dependency property system to read the value, and avoid the type cast required when getting a `DependencyProperty` value.

Backing fields are automatically generated and maintained current through `FrameworkPropertyMetadata.BackingFieldUpdateCallback` which is invoked when the highest precedence value of a `DependencyProperty` is changed.

## GeneratedDependencyProperty options
Other attribute properties are available on `GeneratedDependencyProperty` to include:
- `PropertyChangedCallback` to force the inclusion of a property changed callback method and fail the build if there is none
- `CoerceCallback` to force the inclusion of a coerce callback method and fail the build if there is none
- `Options` to specify which `FrameworkPropertyMetadataOptions` to use
- `LocalCache` to enable or disable local precedence value caching (enabled by default)
- `GenerateAsField` to control whether a `DependencyProperty` declaration is generated as a property or a field (defaults to property)
- `IsPublic` to control the visibility of the `DependencyProperty` declaration
- `AttachedBackingFieldOwner` to provide the type hosting the local cache backing field for attached properties
- `ChangedCallbackName` to control the name of the property changed callback method
