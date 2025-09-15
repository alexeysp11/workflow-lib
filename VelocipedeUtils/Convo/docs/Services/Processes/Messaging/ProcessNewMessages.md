# ProcessNewMessages Process

[English](ProcessNewMessages.md) | [Русский](ProcessNewMessages.ru.md)

## Description 

- Processes messages from users:
     - Receives a message from the sender;
     - Writes a message to the `MessagingDB` database;
     - If the recipient is online and “Disable notifications” is not checked for this chat, then we send a message:
         - If the message has been sent, then mark the message as “sent”.
         - If we can’t send, then we mark the message as “waiting to be sent”, set the recipient’s status to offline and send information about the status via RabbitMQ to the **Last seen service** service.
     - If the recipient is offline, then we mark the message as “waiting to be sent.”

![ProcessNewMessagesDiagram](../../../img/ActivityDiagrams/ProcessNewMessagesDiagram.png)
