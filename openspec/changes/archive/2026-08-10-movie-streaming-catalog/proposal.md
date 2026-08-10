## Why

This project fulfills Assignment 1 for Database II: build a Blazor (.NET) application backed by MongoDB that demonstrates full CRUD operations, filtering, and text search across three collections. The topic chosen is a **Movie Streaming Catalog ("MiniNetflix")** — a domain that is intuitive, easy to explain during the individual defense, and maps naturally to three distinct collections with rich attributes.

**Defense date: August 11, 2026.**

## What Changes

- Create a MongoDB database with three collections: **Movies**, **Actors**, and **Directors**.
- Each collection has ≥ 6 attributes (excluding `_id`) and an `isActive` field for logical deletion.
- Build a Blazor Server (.NET) application with:
  - Full CRUD (Create, Read, Update, Logical Delete) for all three collections.
  - Filter controls (by genre, year, rating, nationality, etc.).
  - Text search across titles, synopses, and names.
  - A functional, clean UI to demonstrate all operations.

## Capabilities

### New Capabilities
- `movie-crud`: Full CRUD operations for the Movies collection, including create, read, update, and logical delete.
- `actor-crud`: Full CRUD operations for the Actors collection, including create, read, update, and logical delete.
- `director-crud`: Full CRUD operations for the Directors collection, including create, read, update, and logical delete.
- `search-and-filters`: Filtering by attributes (genre, year, rating, nationality) and full-text search across stored data.
- `blazor-ui`: Blazor Server application shell with navigation, layout, and pages for managing all three collections.

### Modified Capabilities
<!-- No existing capabilities to modify — this is a greenfield project. -->

## Impact

- **Database**: A new MongoDB database (`MiniNetflixDB`) with three collections will be created locally.
- **Application**: A new Blazor Server project using `MongoDB.Driver` NuGet package.
- **Dependencies**: .NET SDK (already installed), MongoDB Community 8.0 (already installed), `MongoDB.Driver` NuGet package.
- **Deployment**: Runs locally; defense will use a single laptop with `mongod` running via `--fork`.
