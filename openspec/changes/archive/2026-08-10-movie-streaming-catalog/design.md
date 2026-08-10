## Context

This is a greenfield project for a Database II university assignment. The goal is to build a Blazor Server application connected to a local MongoDB instance, demonstrating full CRUD, filtering, and text search across three collections (Movies, Actors, Directors) in a "Movie Streaming Catalog" domain.

**Current state**: MongoDB 8.0, MongoDB Compass, .NET SDK, and the MongoDB VS Code extension are already installed on macOS. The `mongod` process runs via `--fork` due to a known `launchctl` plist issue.

**Constraints**:
- Defense date is **August 11, 2026** — minimal time, so simplicity is key.
- Single laptop demo — everything runs locally.
- No relationships between collections are required by the assignment.
- Logical delete only (no physical removal of documents).

## Goals / Non-Goals

**Goals:**
- Deliver a fully functional Blazor Server app with CRUD on 3 MongoDB collections.
- Implement filters (dropdowns, date ranges, numeric ranges) and text search.
- Use logical deletion (`isActive` flag) on all collections.
- Keep the codebase simple enough that every team member can explain any part during defense.
- Ensure the app runs reliably on the defense laptop.

**Non-Goals:**
- Authentication / authorization — not required.
- Deployment to cloud or containers — local only.
- Relationships / references between collections (joins, `$lookup`) — not required.
- Pagination — nice-to-have but not required for the assignment.
- Unit or integration tests — not required given timeline.
- CSS framework complexity — functional UI is sufficient (Bootstrap via Blazor defaults).

## Decisions

### 1. Blazor Server (not Blazor WebAssembly)

**Choice**: Blazor Server  
**Rationale**: Simpler setup, no separate API project needed, direct MongoDB driver access from server-side code. The app runs on one machine so latency isn't a concern.  
**Alternative considered**: Blazor WASM + ASP.NET API — adds unnecessary complexity for a local demo.

### 2. Project structure — Single Blazor Server project

**Choice**: One `dotnet new blazorserver` project with folders for Models, Services, and Pages.  
**Rationale**: Minimum viable architecture. No need for separate class libraries or microservices.  
**Structure**:
```
MiniNetflix/
├── Models/
│   ├── Movie.cs
│   ├── Actor.cs
│   └── Director.cs
├── Services/
│   ├── MovieService.cs
│   ├── ActorService.cs
│   └── DirectorService.cs
├── Pages/
│   ├── Movies/
│   │   ├── MovieList.razor
│   │   └── MovieForm.razor
│   ├── Actors/
│   │   ├── ActorList.razor
│   │   └── ActorForm.razor
│   └── Directors/
│       ├── DirectorList.razor
│       └── DirectorForm.razor
├── Program.cs
└── appsettings.json
```

### 3. MongoDB Driver — Official C# driver (`MongoDB.Driver`)

**Choice**: `MongoDB.Driver` NuGet package.  
**Rationale**: Official, well-documented, strongly-typed with LINQ support. Used in all Blazor + MongoDB tutorials.  
**Alternative considered**: `MongoFramework` (EF-like ORM) — adds abstraction we don't need.

### 4. MongoDB connection — Singleton `IMongoDatabase` via DI

**Choice**: Register `IMongoClient` and `IMongoDatabase` as singletons in `Program.cs`. Each service receives `IMongoDatabase` via constructor injection.  
**Rationale**: Thread-safe, recommended by MongoDB docs. Connection string in `appsettings.json`.

### 5. Logical deletion — `IsActive` boolean field

**Choice**: Every document has `IsActive = true` by default. Delete sets it to `false`. All queries filter by `IsActive == true` by default.  
**Rationale**: Simplest logical delete pattern, directly satisfies the assignment requirement.

### 6. Text search — MongoDB text index + `$text` query

**Choice**: Create a MongoDB text index on searchable string fields (title, synopsis, names, biography). Use `$text` operator for full-text search.  
**Rationale**: Native MongoDB feature, no external dependency. The `MongoDB.Driver` supports `Builders<T>.Filter.Text(searchTerm)`.  
**Alternative considered**: Client-side `Contains()` filtering — doesn't scale, doesn't demonstrate MongoDB capabilities.

### 7. Filters — Server-side `FilterDefinition<T>` composition

**Choice**: Build filters using `Builders<T>.Filter` and combine with `&` operator. Pass filter parameters from Razor components to services.  
**Rationale**: Clean, composable, keeps logic server-side. Blazor Server makes this natural.

## Risks / Trade-offs

| Risk | Mitigation |
|------|------------|
| `mongod` not running on defense day | Add a startup check script; document the `--fork` command in README |
| Blazor Server requires persistent SignalR connection | Local-only, so connection stability is not a concern |
| Text index must be created before text search works | Seed script or service startup code creates indexes automatically |
| Team members unfamiliar with C# / Blazor | Keep code patterns simple and repetitive across all 3 collections |
| Time pressure (defense in ~2 days) | Prioritize CRUD first (12 pts), then filters/search (6 pts), then UI polish (3 pts) |
