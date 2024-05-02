# IAuthResolver Interface 

Namespace: [WokflowLib.Authentication.AuthBL](WokflowLib.Authentication.AuthBL.md)

## Methods 

### CheckUserExistance(UserCredentials)

Method that checks if the specified user exists in the database.

```C#
public UserExistance CheckUserExistance(UserCredentials request);
```

#### Parameters 

- `request`: [UserCredentials](../models/NetworkParameters/UserCredentials.md)

User credentials.

#### Returns

[UserExistance](../models/NetworkParameters/UserExistance.md)

Esistance of the specified user.

#### Examples

Example of using `CheckUserExistance()` method is presented below:

```C#
    [HttpPost("CheckUserExistance")]
    public UserExistance CheckUserExistance(UserCredentials request)
    {
        return new AuthResolver().CheckUserExistance(request);
    }
```

### AddUser(UserCredentials)

Method that creates the specified user.

```C#
public UserCreationResult AddUser(UserCredentials request);
```

#### Parameters 

- `request`: [UserCredentials](../models/NetworkParameters/UserCredentials.md)

User credentials.

#### Returns

[UserCreationResult](../models/NetworkParameters/UserCreationResult.md)

Result that shows if the specified user is created successfully.

#### Examples

Example of using `AddUser()` method is presented below:

```C#
    [HttpPost("AddUser")]
    public UserCreationResult AddUser(UserCredentials request)
    {
        return new AuthResolver().AddUser(request);
    }
```

### VerifySignUp(VSURequest)

Method for verification of sign up completion.

```C#
public VSUResponse VerifySignUp(VSURequest request);
```

#### Parameters 

- `request`: [VSURequest](../models/NetworkParameters/VSURequest.md)

The request to confirm registration using a verification code.

#### Returns

[VSUResponse](../models/NetworkParameters/VSUResponse.md)

The response to confirmation of registration using the verification code.

#### Examples

Example of using `VerifySignUp()` method is presented below:

```C#
    [HttpPost("VerifySignUp")]
    public VSUResponse VerifySignUp(VSURequest request)
    {
        return new AuthResolver().VerifySignUp(request);
    }
```

### VerifyUserCredentials(UserCredentials)

Method for user verification.

```C#
public VUCResponse VerifyUserCredentials(UserCredentials request);
```

#### Parameters 

- `request`: [UserCredentials](../models/NetworkParameters/UserCredentials.md)

User credentials.

#### Returns

[VUCResponse](../models/NetworkParameters/VUCResponse.md)

The result of verification of user credintials.

#### Examples

Example of using `VerifyUserCredentials()` method is presented below:

```C#
    [HttpPost("VerifyUserCredentials")]
    public VUCResponse VerifyUserCredentials(UserCredentials request)
    {
        return new AuthResolver().VerifyUserCredentials(request);
    }
```

### GetTokenByUserUid(TokenRequest)

Method for getting and/or updating the session token by user UID.

```C#
public SessionToken GetTokenByUserUid(TokenRequest request);
```

#### Parameters 

- `request`: [TokenRequest](../models/NetworkParameters/TokenRequest.md)

The request to receive a session token for the user.

#### Returns

[SessionToken](../models/NetworkParameters/SessionToken.md)

Session token.

#### Examples

Example of using `GetTokenByUserUid()` method is presented below:

```C#
    [HttpPost("GetTokenByUserUid")]
    public SessionToken GetTokenByUserUid(TokenRequest request)
    {
        return new AuthResolver().GetTokenByUserUid(request);
    }
```
