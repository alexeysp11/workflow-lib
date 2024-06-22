# StartConversation Process

[English](StartConversation.md) | [Русский](StartConversation.ru.md)

## Description 

- Loading correspondence with the interlocutor:
    - The user is on the “Dialogue” page (with the selected interlocutor).
    - A request is sent to the backend in order to receive all messages associated with this dialogue.
        - It is possible to limit the number of uploaded messages and the period.
        - When the user has reached the oldest message, if the last message upload did not include the latest message, the "Load earlier messages" button will be displayed. If the user clicks on this button, a request will again be sent to the backend to receive all messages.
    - The number of requested messages can be limited in the request body in order to reduce network load

![StartConversationDiagram](../../../img/ActivityDiagrams/StartConversationDiagram.png)
