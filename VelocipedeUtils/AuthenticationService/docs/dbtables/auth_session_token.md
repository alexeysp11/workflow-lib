# auth_session_token

- **Session token** - session token (name: `auth_session_token`):
    - `auth_session_token_id: integer` - token ID,
    - `token_guid: varchar` - generated token GUID,
    - `token_begin_dt: timestamp` - the beginning of the token,
    - `token_end_dt: timestamp` - end of token validity,
    - `user_guid: varchar` - user GUID (the user himself and his personal data are not stored on the service side).

Corresponds to the [SessionToken](../models/NetworkParameters/SessionToken.md).
