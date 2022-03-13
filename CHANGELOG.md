# Changelog




## [3.0.0] - 2022-03-13
[Full Changelog](https://github.com/TechNobre/PowerUtils.Validations/compare/v2.1.0...v3.0.0)


### Breaking Changes
- Exceptions module has been moved to [PowerUtils.GuardClauses.Validations](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations) project so it can be used individually;
- ErrorCodes module has been moved to [PowerUtils.Validations.Primitives](https://github.com/TechNobre/PowerUtils.Validations.Primitives) project so it can be used individually;
- Error codes for status code 409-Conflict changed from `ALREADY_EXISTS` to `DUPLICATED`;
- Removed unused property `Message` from object `ValidationNotification`;
- Removed the constructor `ValidationNotification(string property, string errorCode, string message)`;




## [2.1.0] - 2021-11-29
[Full Changelog](https://github.com/TechNobre/PowerUtils.Validations/compare/v2.0.0...v2.1.0)


### New Features
- Added new exception `UnauthorizedException`;
- Added new error code `UNAUTHORIZED`;


### Bug fixed
- Bug fixed the StatusCode of the `ForbiddenException`;


### Enhancements
- Improved the level of protection of static properties for ValidationExceptions;
- Updated documentation;




## [2.0.0] - 2021-11-23
[Full Changelog](https://github.com/TechNobre/PowerUtils.Validations/compare/v1.0.0...v2.0.0)


### New Features
- Added new validation rule "OptionsIgnoreCase";
- Added new validation rule "OrderingDirectionIgnoreCase";


### Breaking Changes
- Now validation rule "Options" is case sensitive;




## [1.0.0] - 2021-11-21

- Start project