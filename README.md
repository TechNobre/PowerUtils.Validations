# PowerUtils.Validations
Utils to help validation of the objects

![CI](https://github.com/TechNobre/PowerUtils.Validations/actions/workflows/main.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/PowerUtils.Validations.svg)](https://www.nuget.org/packages/PowerUtils.Validations)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.Validations.svg)](https://www.nuget.org/packages/PowerUtils.Validations)
[![License: MIT](https://img.shields.io/github/license/ofpinewood/http-exceptions.svg)](https://github.com/TechNobre/PowerUtils.Validations/blob/main/LICENSE)



## Support to
- .NET 5.0 and .NET 6.0



## Features
- [Installation](#Installation)
- [Validation exceptions](#validation-exceptions)
- [Validations](#Validations)



## Documentation

### Dependencies

- PowerUtils.Globalization [NuGet](https://www.nuget.org/packages/PowerUtils.Globalization/)
- PowerUtils.Net.Primitives [NuGet](https://www.nuget.org/packages/PowerUtils.Net.Primitives/)


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



### Validation exceptions <a name="validation-exceptions"></a>
- `BadRequestException`;
- `ConflictException`;
- `ForbiddenException`;
- `InvalidPropertyException`;
- `NotFoundException`;

### Validations <a name="Validations"></a>

// TODO: to document



## Contribution

*Help me to help others*




## LICENSE

[MIT](https://github.com/TechNobre/PowerUtils.Validations/blob/main/LICENSE)




## Release Notes


### v2.0.0 - 2021/11/23

#### Breaking Changes
- Now validation rule "Options" is case sensitive;
 
#### New Features
- Added new validation rule "OptionsIgnoreCase";
- Added new validation rule "OrderingDirectionIgnoreCase";


### v1.0.0 - 2021/11/21
- Kick start project