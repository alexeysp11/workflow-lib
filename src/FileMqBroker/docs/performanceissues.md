# performanceissues

[English](performanceissues.md) | [Русский](performanceissues.ru.md)

## Performance issues with load testing

Two applications are used for load testing:
- [load generation](../loadtesting/README.ru.md): works quite stable.
- [backend service](../backendservice/README.ru.md): performance problems were discovered (the application takes a long time to process requests and stops periodically).

Possible causes of performance problems on the backend service:
- Incorrect work with the queue:
    - For the naive implementation, there is no check that the file is already in the queue for processing (i.e. the file will be added to the queue from the database until its status becomes `Processed`). See file: [ReadMqDispatcher.cs](../mqlibrary/src/QueueDispatchers/ReadMqDispatcher.cs).
    - There is no filter in the database query to exclude files that are already in the queue from the selection.
- Excessive allocation of objects in the managed heap:
    - You can make [MessageFile](../mqlibrary/src/Models/MessageFile.cs) a value type rather than a reference type (to reduce the overhead of calling the garbage collector). However, this requires careful testing.
    - Using `char[]` instead of `string` for structure fields can reduce memory allocation overhead on the managed heap, since character arrays (`char[]`) are meaningful data types. However, you must be aware of security and memory management when working with character arrays.
    - The application often generates queries to the database using `StringBuilder`. You can create a pool of `StringBuilder` objects by first defining the number of objects that corresponds to the maximum load. It is important to ensure proper access control to objects in the pool to avoid data races and other threading problems.
- Limitations due to the mandatory recording of message status in the database:
    - On the backend service side, there is no provision for the situation when a file is written to a directory, but not written to the database (accordingly, because of this, files may accumulate in the directory and not be deleted in a timely manner). You can write a background task that adds files that have been in the directory for a long time to the `RequestMessageFiles` table.