## 1. Project Setup

- [ ] 1.1 Create Blazor Server project (`dotnet new blazorserver -n MiniNetflix`)
- [ ] 1.2 Add `MongoDB.Driver` NuGet package (`dotnet add package MongoDB.Driver`)
- [ ] 1.3 Configure MongoDB connection string in `appsettings.json` (database: `MiniNetflixDB`, connection: `mongodb://localhost:27017`)
- [ ] 1.4 Register `IMongoClient` and `IMongoDatabase` as singletons in `Program.cs`

## 2. Models

- [ ] 2.1 Create `Movie.cs` model with attributes: Id, Title, Genre, ReleaseYear, DurationMinutes, Synopsis, Rating, Language, IsActive
- [ ] 2.2 Create `Actor.cs` model with attributes: Id, FirstName, LastName, BirthDate, Nationality, Biography, AwardsCount, PhotoUrl, IsActive
- [ ] 2.3 Create `Director.cs` model with attributes: Id, FirstName, LastName, BirthDate, Nationality, Biography, FilmCount, Specialization, IsActive

## 3. Services (CRUD + Filters + Text Search)

- [ ] 3.1 Create `MovieService.cs` with methods: GetAllAsync (with filters & text search), GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync (logical)
- [ ] 3.2 Create `ActorService.cs` with methods: GetAllAsync (with filters & text search), GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync (logical)
- [ ] 3.3 Create `DirectorService.cs` with methods: GetAllAsync (with filters & text search), GetByIdAsync, CreateAsync, UpdateAsync, DeleteAsync (logical)
- [ ] 3.4 Register all services in `Program.cs` DI container

## 4. MongoDB Text Indexes

- [ ] 4.1 Create text index on Movies collection (Title, Synopsis) — via service startup or seed script
- [ ] 4.2 Create text index on Actors collection (FirstName, LastName, Biography) — via service startup or seed script
- [ ] 4.3 Create text index on Directors collection (FirstName, LastName, Biography) — via service startup or seed script

## 5. Blazor Pages — Movies

- [ ] 5.1 Create `MovieList.razor` page with table, filter controls (genre dropdown, year range, min rating), text search box, and Edit/Delete action buttons
- [ ] 5.2 Create `MovieForm.razor` page for create and edit with form validation
- [ ] 5.3 Implement delete confirmation dialog for movies

## 6. Blazor Pages — Actors

- [ ] 6.1 Create `ActorList.razor` page with table, filter controls (nationality), text search box, and Edit/Delete action buttons
- [ ] 6.2 Create `ActorForm.razor` page for create and edit with form validation
- [ ] 6.3 Implement delete confirmation dialog for actors

## 7. Blazor Pages — Directors

- [ ] 7.1 Create `DirectorList.razor` page with table, filter controls (specialization), text search box, and Edit/Delete action buttons
- [ ] 7.2 Create `DirectorForm.razor` page for create and edit with form validation
- [ ] 7.3 Implement delete confirmation dialog for directors

## 8. Navigation & Layout

- [ ] 8.1 Update `NavMenu.razor` with links to Movies, Actors, and Directors pages
- [ ] 8.2 Create or update the Home page (`Index.razor`) with app name "MiniNetflix" and quick-access links

## 9. Verification & Polish

- [ ] 9.1 Verify full CRUD works on all 3 collections via the UI
- [ ] 9.2 Verify filters narrow results correctly on each page
- [ ] 9.3 Verify text search returns relevant results on each page
- [ ] 9.4 Verify logical delete hides records without physical removal (check in Compass)
- [ ] 9.5 Ensure `mongod --fork` startup command is documented in README
