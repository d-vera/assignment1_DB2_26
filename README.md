# MiniNetflix — Movie Streaming Catalog

**Database II — Assignment 1**  
Blazor Server + MongoDB CRUD Application

## Prerequisites

- .NET SDK 10.0+
- MongoDB Community 8.0+
- MongoDB Compass (optional, for visual inspection)

## Starting MongoDB

Due to a known `launchctl` plist issue on macOS, start `mongod` directly:

```bash
mongod --config /opt/homebrew/etc/mongod.conf --fork
```

Verify it's running:

```bash
mongosh --eval "db.runCommand({ ping: 1 })"
```

Stop when finished:

```bash
mongosh --eval "db.adminCommand({ shutdown: 1 })"
```

## Running the Application

```bash
cd MiniNetflix
dotnet run
```

Then open [http://localhost:5000](http://localhost:5000) in your browser.

## Collections

| Collection | Attributes |
|------------|-----------|
| **Movies** | Title, Genre, ReleaseYear, DurationMinutes, Synopsis, Rating, Language, IsActive |
| **Actors** | FirstName, LastName, BirthDate, Nationality, Biography, AwardsCount, PhotoUrl, IsActive |
| **Directors** | FirstName, LastName, BirthDate, Nationality, Biography, FilmCount, Specialization, IsActive |

## Features

- ✅ Full CRUD on all 3 collections
- ✅ Logical delete (IsActive flag)
- ✅ Filters (genre, year range, rating, nationality, specialization)
- ✅ Text search via MongoDB `$text` index
- ✅ Form validation with DataAnnotations