<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128638859/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2407)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Winforms Property Grid - Property display name localization

This example applies the `System.ComponentModel.DisplayName` attribute to properties to enable localization:

![Winforms Property Grid - Property display name localization](https://raw.githubusercontent.com/DevExpress-Examples/how-to-localize-the-properties-display-names-for-the-propertygridcontrol-e2407/13.1.4%2B/media/winforms-propertygrid-localization.png)

```csharp
public class Product {
    // ...
    [CustomDisplayNameAttribute("ProductCode")]
    public string ProductCode {
        get { return productCode; }
        set { productCode = value; }
    }
    [CustomDisplayNameAttribute("Name")]
    public string Name {
        get { return name; }
        set { name = value; }
    }
}
```


## Files to Review

* [Form1.cs](./CS/WindowsApplication3/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication3/Form1.vb))
