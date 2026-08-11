## ADDED Requirements

### Requirement: Create a movie
The system SHALL allow the user to create a new movie document in the Movies collection with the following attributes: Title (string), Genre (string), ReleaseYear (int), DurationMinutes (int), Synopsis (string), Rating (decimal), Language (string), and IsActive (bool, default true).

#### Scenario: Successfully create a movie
- **WHEN** the user fills in all required fields (Title, Genre, ReleaseYear, DurationMinutes, Synopsis, Rating, Language) and submits the form
- **THEN** the system inserts a new document into the Movies collection with `IsActive = true` and the user is redirected to the movie list

#### Scenario: Create movie with custom language string
- **WHEN** the user submits the form with any language string (such as `"Español"` or `"French"`)
- **THEN** the system inserts the document into MongoDB without text index language override conflicts and redirects to the movie list

#### Scenario: Create movie with missing required fields
- **WHEN** the user submits the movie form with one or more required fields empty
- **THEN** the system displays validation errors and does not insert the document

#### Scenario: Form error feedback on database failure
- **WHEN** a database operation fails during form submission
- **THEN** the system displays an inline error alert banner on the form instead of triggering an unhandled circuit crash

### Requirement: Read movies
The system SHALL display a list of all movies where `IsActive == true`, showing key attributes (Title, Genre, ReleaseYear, Rating).

#### Scenario: View movie list
- **WHEN** the user navigates to the Movies page
- **THEN** the system displays all movies where `IsActive == true` in a table or card layout

#### Scenario: Empty movie list
- **WHEN** there are no active movies in the collection
- **THEN** the system displays a message indicating no movies are available

### Requirement: Update a movie
The system SHALL allow the user to modify any attribute of an existing movie document.

#### Scenario: Successfully update a movie
- **WHEN** the user selects an existing movie, modifies one or more fields, and submits the form
- **THEN** the system updates the document in MongoDB and the updated values are reflected in the movie list

### Requirement: Logical delete a movie
The system SHALL implement logical deletion by setting `IsActive = false` instead of physically removing the document.

#### Scenario: Logically delete a movie
- **WHEN** the user clicks the delete button on a movie
- **THEN** the system sets `IsActive = false` on that document and the movie no longer appears in the active movie list
