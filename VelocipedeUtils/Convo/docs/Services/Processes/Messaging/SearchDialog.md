# SearchDialog Process

[English](SearchDialog.md) | [Русский](SearchDialog.ru.md)

Processes a client request to receive all messages (for all time or after a certain time).

## Description 

- Selecting a dialog to start communication:
    - The user is on the "Start Dialogue" page.
    - The user enters the login/email/phone number of the potential dialog in the search field;
    - A request is sent to the backend to check whether such a user exists in the database:
        - If the user is not found, the backend sends a "User not found" response.
        - If at least one user is found, then we display all users that match the specified filter.
    - If the user clicks "Cancel", the entered data in the search field is erased.
    - If the user clicks on the “Find” button again, the request is not sent, because the data in the search field has not been changed.
    - If the user clicks on the user, then a redirection occurs to the “Dialogue” page (the correspondence with the selected dialog is loaded).

![SearchDialogDiagram](../../../img/ActivityDiagrams/SearchDialogDiagram.png)
