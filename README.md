# ECommerceApp

In this project, I developed an ASP.NET mobile application to simulate a library system. The application allows users to create accounts, borrow books, and browse different genres. The system maintains a log of book rentals for each user.
The system's architecture consists of four main entities: Books, Genres, Members, and Borrowing Records. Each book belongs to a genre, and members can rent books. A borrowing record logs one book per member at a time.
I used Entity Framework to design the database. The models representing each entity were defined in separate files (Book.cs, Genre.cs, Member.cs, BorrowingRecord.cs) located in the Models folder. Data annotations were used to validate inputs, ensuring books have required fields like title, author, and genre.
CRUD operations were implemented using .NET controllers, which automatically generated basic operations for each model. The database was migrated, and the LibraryDB was created to store data.
The views were customized to enhance the UI, including layout adjustments and HTML files. Additional features like search and filter functionality were added for book management.
The result was a fully functional .NET application with validated inputs, CRUD operations, and error handling.

