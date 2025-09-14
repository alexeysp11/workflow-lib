# auth_signin

- **Sign in** - sign in to the application (name: `auth_signin`):
    - `auth_signin_id: integer` - sign in ID,
    - `signin_guid: integer` - sign in GUID,
    - `user_guid: varchar` - GUID of the existing user,
    - `signin_begin_dt: timestamp` - start of registration,
    - `signin_end_dt: timestamp` - end of registration,
    - `is_deprecated: boolean` - "deprecated" sign,
    - `is_overriden: boolean` - sign "overwritten",
    - `auth_closing_code_id: integer` -  closing code.

Corresponds to the [AuthSignIn](../models/AuthSignIn.md).
