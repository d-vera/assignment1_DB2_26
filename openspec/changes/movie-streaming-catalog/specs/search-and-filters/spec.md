## ADDED Requirements

### Requirement: Filter movies by genre
The system SHALL allow the user to filter the movie list by selecting a genre from a dropdown.

#### Scenario: Filter movies by genre
- **WHEN** the user selects a genre from the genre filter dropdown on the Movies page
- **THEN** only movies matching that genre (and `IsActive == true`) are displayed

### Requirement: Filter movies by release year range
The system SHALL allow the user to filter movies by specifying a minimum and/or maximum release year.

#### Scenario: Filter movies by year range
- **WHEN** the user enters a minimum year, a maximum year, or both
- **THEN** only movies with `ReleaseYear` within the specified range are displayed

### Requirement: Filter movies by rating
The system SHALL allow the user to filter movies by a minimum rating threshold.

#### Scenario: Filter movies by minimum rating
- **WHEN** the user enters a minimum rating value
- **THEN** only movies with `Rating >= minimumRating` are displayed

### Requirement: Filter actors by nationality
The system SHALL allow the user to filter the actor list by nationality.

#### Scenario: Filter actors by nationality
- **WHEN** the user selects or types a nationality in the filter control on the Actors page
- **THEN** only actors matching that nationality (and `IsActive == true`) are displayed

### Requirement: Filter directors by specialization
The system SHALL allow the user to filter the director list by specialization (e.g., Action, Drama, Comedy).

#### Scenario: Filter directors by specialization
- **WHEN** the user selects a specialization from the filter control on the Directors page
- **THEN** only directors matching that specialization (and `IsActive == true`) are displayed

### Requirement: Text search across collections
The system SHALL provide a text search input on each collection's list page that searches across the text-indexed fields of that collection using MongoDB's `$text` operator.

#### Scenario: Text search on movies
- **WHEN** the user types a search term in the search box on the Movies page
- **THEN** the system returns movies whose Title or Synopsis match the search term

#### Scenario: Text search on actors
- **WHEN** the user types a search term in the search box on the Actors page
- **THEN** the system returns actors whose FirstName, LastName, or Biography match the search term

#### Scenario: Text search on directors
- **WHEN** the user types a search term in the search box on the Directors page
- **THEN** the system returns directors whose FirstName, LastName, or Biography match the search term

#### Scenario: Text search with no results
- **WHEN** the user types a search term that matches no documents
- **THEN** the system displays a message indicating no results were found

### Requirement: Combine filters with text search
The system SHALL allow the user to apply both attribute filters and text search simultaneously.

#### Scenario: Combined filter and search
- **WHEN** the user selects a genre filter AND enters a text search term on the Movies page
- **THEN** only movies matching both the genre filter and the text search are displayed
