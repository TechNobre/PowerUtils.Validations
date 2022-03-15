# PowerUtils.Validations
Utils to help validation of the objects

![Tests](https://github.com/TechNobre/PowerUtils.Validations/actions/workflows/test-project.yml/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.Validations&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.Validations)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.Validations&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.Validations)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.Validations.svg)](https://www.nuget.org/packages/PowerUtils.Validations)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.Validations.svg)](https://www.nuget.org/packages/PowerUtils.Validations)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.Validations.svg)](https://github.com/TechNobre/PowerUtils.Validations/blob/main/LICENSE)



## Support to
- .NET 5.0
- .NET 6.0



## Features
- [ValidationsContract](#ValidationsContract)
- [ValidationNotifications](#ValidationNotifications)
- [Rules](#Rules)



## Documentation

### Dependencies

- PowerUtils.Validations.Primitives [NuGet](https://www.nuget.org/packages/PowerUtils.Validations.Primitives/)
- PowerUtils.Globalization [NuGet](https://www.nuget.org/packages/PowerUtils.Globalization/)
- PowerUtils.Text [NuGet](https://www.nuget.org/packages/PowerUtils.Text/)


### How to use

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



## Contribution

*Help me to help others*




## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.Validations/blob/main/LICENSE)



## Changelog

[Here](./CHANGELOG.md)
