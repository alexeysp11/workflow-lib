# AuthResolverSettings Class 

Namespace: [WokflowLib.Authentication.Models.ConfigParameters](WokflowLib.Authentication.Models.ConfigParameters.md)

Settings for authentication resolver.

## Constructors 

### AuthResolverSettings()

Default constructor.

```C#
public AuthResolverSettings();
```

## Properties

### CheckUCConfig

Config properties that is used for checking if the user credentials were filled properly.

```C#
public CheckUCConfig CheckUCConfig { get; set; }
```

#### Property Value

[CheckUCConfig](CheckUCConfig.md)

Config properties that is used for checking if the user credentials were filled properly.

### AuthDBSettings

Settings for DB.

```C#
public AuthDBSettings AuthDBSettings { get; set; }
```

#### Property Value

[AuthDBSettings](AuthDBSettings.md)

Settings for DB.

### NetworkSettings

Settings for network communication.

```C#
public NetworkSettings NetworkSettings { get; set; }
```

#### Property Value

[NetworkSettings](NetworkSettings.md)

Settings for network communication.
