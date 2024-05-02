# auth_deactivation

- **Deactivation** - deactivation (name: `auth_deactivation`):
    - `auth_deactivation_id` - deactivation ID,
    - `deactivation_uid` - deactivation UID,
    - `deactivation_code: varchar` - deactivation code,
    - `dc_sending_dt: timestamp` - time of sending the confirmation code,
    - `deactivation_begin_dt: timestamp` - start of deactivation,
    - `deactivation_end_dt: timestamp` - end of deactivation,
    - `tries_number: integer` - number of attempts to enter the deactivation code,
    - `is_deprecated: boolean` - sign of "obsolete deactivation",
    - `is_overriden: boolean` - sign of "overwritten deactivation",
    - `deactivation_closing_code_id`: deactivation closing code.
