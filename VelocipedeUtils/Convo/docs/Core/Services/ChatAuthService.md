# ChatAuthService Class 

*Namespace*: [Chat.Core.Services](Chat.Core.Services.md)

Service for authentication and getting session tokens (a part of the [AuthenticationService](../../Services/AuthenticationService.md) module).

## Remarks 

The [workflow-auth](https://github.com/alexeysp11/workflow-auth) library is used as an authentication service (in particular, the [AuthResolverDB](https://github.com/alexeysp11/workflow-auth/blob/main/docs/authbl/AuthResolverDB.md) class).

![AuthService](../../img/AuthService.png)

## Constructors 

### ChatAuthService()

Default constructor.

```C#
public ChatAuthService();
```

The [workflow-auth](https://github.com/alexeysp11/workflow-auth) library is responsible for communication with the database, so in the authentication service settings (class [AuthResolverSettings](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/ConfigParameters/AuthResolverSettings.md)) we specify the names of the database tables with which we will work, and send these settings to the constructor of the [AuthResolverDB](https://github.com/alexeysp11/workflow-auth/blob/main/docs/authbl/AuthResolverDB.md) class as follows:
```C#
         var configHelper = new ConfigHelper();
         var settings = new AuthResolverSettings
         {
             CheckUCConfig = configHelper.GetUCConfigs(),
             AuthDBSettings = configHelper.GetAuthDBSettings(usersTableName: "chat_users")
         };
         AuthResolver = new AuthResolverDB(settings);
```

## Methods

### AddUser(UserCredentials)

Method for adding the specified user into the database.

```C#
public UserCreationResult AddUser(UserCredentials request);
```

Under the hood, this method invokes the `AddUser()` method of the [AuthResolverDB](https://github.com/alexeysp11/workflow-auth/blob/main/docs/authbl/AuthResolverDB.md) class.

#### Parameters 

- `request`: [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)

Request that passes user credentials.

#### Returns 

[UserCreationResult](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCreationResult.md)

Response that stores info whether the user was successfully added.

### VerifyUserCredentials(UserCredentials)

Method for verifying the user credentials.

```C#
public VUCResponse VerifyUserCredentials(UserCredentials request);
```

Under the hood, this method invokes the `VerifyUserCredentials()` method of the [AuthResolverDB](https://github.com/alexeysp11/workflow-auth/blob/main/docs/authbl/AuthResolverDB.md) class.

#### Parameters 

- `request`: [UserCredentials](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/UserCredentials.md)

Request that passes user credentials.

#### Returns 

[VUCResponse](https://github.com/alexeysp11/workflow-auth/blob/main/docs/models/NetworkParameters/VUCResponse.md)

Response that stores info whether the user was successfully verified.
