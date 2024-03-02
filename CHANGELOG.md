# [4.0.0](https://github.com/TechNobre/PowerUtils.Validations/compare/v3.1.0...v4.0.0) (2024-03-02)


### Bug Fixes

* Deprecated package ([c59f9a9](https://github.com/TechNobre/PowerUtils.Validations/commit/c59f9a98058f53789f6341e853f387a99fd1877b))
* Deprecated package ([926a7ea](https://github.com/TechNobre/PowerUtils.Validations/commit/926a7ea31352330b948a9d2953fe3ea6a8fda0c5))


### BREAKING CHANGES

* Deprecated package
* Deprecated package

# [3.1.0](https://github.com/TechNobre/PowerUtils.Validations/compare/v3.0.0...v3.1.0) (2022-08-26)


### Features

* Add rule to validate latitude and longitude nullable ([73e6374](https://github.com/TechNobre/PowerUtils.Validations/commit/73e63749f1ed29a2d1c327743fe966b956a95af4))
* Add support to debug in runtime `Microsoft.SourceLink.GitHub` ([d6bc421](https://github.com/TechNobre/PowerUtils.Validations/commit/d6bc421e9199e0771d0b5d4c8840af18aad78ce0))

# [3.0.0](https://github.com/TechNobre/PowerUtils.Validations/compare/v2.1.0...v3.0.0) (2022-03-15)


### Breaking Changes
- Exceptions module has been moved to [PowerUtils.GuardClauses.Validations](https://github.com/TechNobre/PowerUtils.GuardClauses.Validations) project so it can be used individually;
- ErrorCodes module has been moved to [PowerUtils.Validations.Primitives](https://github.com/TechNobre/PowerUtils.Validations.Primitives) project so it can be used individually;
- Error codes for status code 409-Conflict changed from `ALREADY_EXISTS` to `DUPLICATED`;
- Removed unused property `Message` from object `ValidationNotification`;
- Removed the constructor `ValidationNotification(string property, string errorCode, string message)`;
- Object `ValidationNotification` named to `ValidationFailure`;
- Interface `IValidationNotificationsPipeline` named to `IValidationNotifications`;
- Object `ValidationNotificationsPipeline` named to `ValidationNotifications`;
- Helper `ValidationsContractNotificationsErrors` named to `ValidationsContractExtensions`;
- Helper `*ValidationsContract` named to `*ValidationRules`;
- Remove unused property `IgnoreProperties` from `IValidationsContract`;




# [2.1.0](https://github.com/TechNobre/PowerUtils.Validations/compare/v2.0.0...v2.1.0) (2021-11-29)


### New Features
- Added new exception `UnauthorizedException`;
- Added new error code `UNAUTHORIZED`;


### Bug fixed
- Bug fixed the StatusCode of the `ForbiddenException`;


### Enhancements
- Improved the level of protection of static properties for ValidationExceptions;
- Updated documentation;




# [2.0.0](https://github.com/TechNobre/PowerUtils.Validations/compare/v1.0.0...v2.0.0) (2021-11-23)


### New Features
- Added new validation rule "OptionsIgnoreCase";
- Added new validation rule "OrderingDirectionIgnoreCase";


### Breaking Changes
- Now validation rule "Options" is case sensitive;




# 1.0.0 (2021-11-21)

- Start project
