# AssetService

[English](AssetService.md) | [Русский](AssetService.ru.md)

A service that is responsible for working with files (storing, processing, receiving and sending).

![SystemOverview](../img/SystemOverview.png)

## Description 

- Storing files on the app's server
- Processing files to ensure they are compatible with the app
- Sending and receiving files (user to user, user to server, server to user)

## Objects 

- File 
- Storage (location, capacity)
- Processing object (compression and decompression, file type conversion, virus scanning)
- Network object (sending and receiving files over the network, checking network connectivity and speed)
