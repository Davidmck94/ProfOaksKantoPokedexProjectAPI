# ProfOaksKantoPokedex

This project was created in Visual Studio with ASP.NET Core, Entity Framework Core and written in C# for the most part.
This is a beginner/ intermediate project I was tasked with by my learning provider Multiverse.

The ultimate goal of this project was to design and build a fully-functional, back-end-only API, complete with Authentication and Authorization, protecting some (or all) routes with Authorization.

The API holds seeded information on Pokemon found only in the Kanto region with some basic stat information and a list of some of the moves they learn.
This information is held in a SQLite database where the user is able to complete the following:

- read entries from the database
- add entries to the database
- delete entries from the database
- edit entries in the database
- do all of the above by accessing RESTful routes

Whilst the API already has Authentication and Authorization implemented, for all routes, I will be looking to upgrade this whilst adding a UI to allow users to login, using Duende Identity Server.
