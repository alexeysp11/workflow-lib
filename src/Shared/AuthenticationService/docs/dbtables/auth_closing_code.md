# auth_closing_code 

- **Authentication closing code** - authentication closing code (name: `auth_closing_code`):
    - Fields:
        - `auth_closing_code_id: integer` - authentication closing code ID,
        - `guid: string` - UID of the authentication closing code,
        - `name: string` - name.
    - Possible values:
        - `success` - success,
        - `rejectedToProvideVC` - refusal to provide a confirmation code,
        - `tooManyTries` - the number of attempts to confirm the code has been exhausted,
        - `timeout` - fell off due to timeout,
        - `overriden` - overwritten,
        - `cancelled` - cancellation.

Corresponds to the [AuthClosingCode](../models/AuthClosingCode.md) or [AuthClosingCodeType](../models/AuthClosingCodeType.md).
