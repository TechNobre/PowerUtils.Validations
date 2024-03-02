# PowerUtils.Validations

# :warning: DEPRECATED

This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary or if you prefer, you can use a good projects like [FluentValidation](https://www.nuget.org/packages/FluentValidation) and [Flunt](https://www.nuget.org/packages/Flunt).

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.Validations/main/assets/logo/logo_128x128.png)

***Utils to help validation of the objects***

[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.Validations.svg)](https://github.com/TechNobre/PowerUtils.Validations/blob/main/LICENSE)


- [Support to ](#support-to-)
- [Dependencies ](#dependencies-)
- [How to use ](#how-to-use-)
    - [Install NuGet package ](#install-nuget-package-)
  - [ValidationsContract ](#validationscontract-)
  - [ValidationNotifications ](#validationnotifications-)
  - [Rules ](#rules-)



## Support to <a name="support-to"></a>
- .NET 5.0
- .NET 6.0



## Dependencies <a name="dependencies"></a>

- PowerUtils.Validations.Primitives [NuGet](https://www.nuget.org/packages/PowerUtils.Validations.Primitives/)
- PowerUtils.Globalization [NuGet](https://www.nuget.org/packages/PowerUtils.Globalization/)
- PowerUtils.Text [NuGet](https://www.nuget.org/packages/PowerUtils.Text/)



## How to use <a name="how-to-use"></a>

#### Install NuGet package <a name="Installation"></a>
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.Validations

**Nuget**
```bash
Install-Package PowerUtils.Validations
```

**.NET CLI**
```
dotnet add package PowerUtils.Validations
```



### ValidationsContract <a name="ValidationsContract"></a>
```csharp
var act = new ValidationsContract<int>(5)
    .RuleFor("Fake")
    .Min(10);

// True
var result = act.Invalid;
```

```csharp
public class CountryValidation : ValidationsContract<Country>
{
    public CountryValidation(Country source) : base(source)
    {
        RuleFor(r => r.CountryCode)
            .CountryCodeISO2();
    }
}
```


### ValidationNotifications <a name="ValidationNotifications"></a>
- __Properties:__
  - `HttpStatusCode StatusCode`;
  - `bool Valid`;
  - `bool Invalid`;
  - `IReadOnlyCollection<ValidationFailure> Notifications`;
- __Methods:__
  - `IValidationNotifications AddNotification(string property, string errorCode)`;
  - `IValidationNotifications AddBadNotification(string property, string errorCode)`;
  - `IValidationNotifications AddBadNotification(ValidationFailure notification)`;
  - `IValidationNotifications AddBadNotifications(IReadOnlyCollection<ValidationFailure> notifications)`;
  - `IValidationNotifications AddBadNotifications(IList<ValidationFailure> notifications)`;
  - `IValidationNotifications AddBadNotifications(ICollection<ValidationFailure> notifications)`;
  - `IValidationNotifications AddBadNotifications(IEnumerable<ValidationFailure> notifications)`;
  - `IValidationNotifications AddBadNotifications(IValidationsContract validations)`;
  - `void SetForbiddenStatus(string property)`;
  - `void SetNotFoundStatus(string property)`;
  - `void SetConflictStatus(string property)`;
  - `void SetNotificationStatus(HttpStatusCode statusCode, string property, string errorCode)`;
  - `void Clear()`;


### Rules <a name="Rules"></a>
- __General:__
  - `.Gender();`
  - `.GenderWithOther();`
  - `.ForbiddenValue(options);`
- __Objects:__
  - `.Required();`
- __Collections:__
  - `.Min(min);`
  - `.Max(max);`
  - `.Range(min, max);`
- __DateTimes:__
  - `.Date(minDate, maxDate);`
  - `.MinDateTimeUtcNow();`
  - `.MaxDateTimeUtcNow();`
- __Globalization:__
  - `.CountryCodeISO2();`
  - `.Latitude();`
  - `.Longitude();`
- __Guids:__
  - `.Required();`
- __Numerics:__
  - `.MinZero();`
  - `.Min(min);`
  - `.Max(max);`
  - `.Range(min, max);`
- __Pagination:__
  - `.OrderingDirectionIgnoreCase();`
- __Strings:__
  - `.Required();`
  - `.Options(options);`
  - `.OptionsIgnoreCase(options);`
  - `.MaxLength(maxLength);`
  - `.MinLength(minLength);`
  - `.Length(minLength, maxLength);`
  - `.EmailAddress();`
  - `.ForbiddenValue(options);`
