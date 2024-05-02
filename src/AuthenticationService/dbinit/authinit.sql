create table if not exists public.auth_session_token
(
    auth_session_token_id serial primary key,
    token_guid varchar(50) unique not null,
    token_begin_dt timestamp with time zone not null,
    token_end_dt timestamp with time zone not null,
    user_guid varchar(50) not null
);
create unique index auth_session_token_guid_idx ON public.auth_session_token (token_guid);
create table if not exists public.auth_signup
(
    auth_signup_id serial primary key,
    signup_guid varchar(50) unique not null,
    user_guid varchar(50) not null,
    verification_code varchar,
    vc_sending_dt timestamp with time zone,
    tries_number integer,
    signup_begin_dt timestamp with time zone not null,
    signup_end_dt timestamp with time zone,
    is_deprecated boolean,
    is_overriden boolean,
    auth_closing_code_id integer
);
create unique index auth_signup_guid_idx ON public.auth_signup (signup_guid);
create table if not exists public.auth_signin
(
    auth_signin_id serial primary key,
    signin_guid varchar(50) unique not null,
    user_guid varchar(50) not null,
    signin_begin_dt timestamp with time zone not null,
    signin_end_dt timestamp with time zone,
    is_deprecated boolean,
    is_overriden boolean,
    auth_closing_code_id integer
);
create unique index auth_signin_guid_idx ON public.auth_signin (signin_guid);
create table if not exists public.auth_closing_code
(
    auth_closing_code_id serial primary key,
    guid varchar(50) unique not null,
    name varchar(50) not null
);
