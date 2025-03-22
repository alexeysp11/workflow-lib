# PixelTerminalUI

[English](README.md) | [Русский](README.ru.md)

If your project already uses TCP and is well tested, then using `IHostedService` with TCP will be a faster solution for development. It will allow you to keep the existing infrastructure and minimize the risks associated with changes.

However, if you plan to scale the service in the future and want to be able to handle requests without having to maintain a persistent connection, then it is worth considering using gRPC or WebAPI. These technologies offer higher-level abstractions that simplify development, testing, and support.

## Testing

### Approach 1: Create a C# application to communicate over TCP

You can create a simple C# console application that will connect to your TCP server, send requests, and receive responses.

### Approach 2: Using Telnet

Telnet is a simple way to interact with a TCP server via the command line. To use Telnet to test your service:

1. Make sure Telnet is installed on your system (on Windows, you may need to enable it through Programs and Features).

2. Open a command prompt (cmd) and type the following command:

```bat
telnet 127.0.0.1 5000
```

Here `127.0.0.1` is your server address and `5000` is the port it is listening on.

3. Once connected, you can enter text commands and send them to the server. For example, enter:

```
Hello Server!
```

Press Enter to send the message.

4. If your server is configured to send responses, you will see them in the Telnet window.
