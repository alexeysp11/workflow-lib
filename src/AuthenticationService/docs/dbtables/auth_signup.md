# auth_signup 

- **Sign up** - sign up (name: `auth_signup`):
    - `auth_signup_id: integer` - sign up ID,
    - `signup_guid: varchar` - sign up GUID,
    - `user_guid: varchar` - GUID of the created user,
    - `verification_code: varchar` - sign up confirmation code,
    - `vc_sending_dt: timestamp` - time of sending the confirmation code,
    - `tries_number: integer` - number of attempts to enter the sign up code,
    - `signup_begin_dt: timestamp` - start of sign up,
    - `signup_end_dt: timestamp` - end of sign up,
    - `is_deprecated: boolean` - "deprecated" sign,
    - `is_overriden: boolean` - sign "overwritten",
    - `auth_closing_code_id: integer` -  closing code.

Corresponds to the [AuthSignUp](../models/AuthSignUp.md).
