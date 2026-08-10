## ADDED Requirements

### Requirement: Create a director
The system SHALL allow the user to create a new director document in the Directors collection with the following attributes: FirstName (string), LastName (string), BirthDate (DateTime), Nationality (string), Biography (string), FilmCount (int), Specialization (string), and IsActive (bool, default true).

#### Scenario: Successfully create a director
- **WHEN** the user fills in all required fields (FirstName, LastName, BirthDate, Nationality, Biography, FilmCount, Specialization) and submits the form
- **THEN** the system inserts a new document into the Directors collection with `IsActive = true` and the user is redirected to the director list

#### Scenario: Create director with missing required fields
- **WHEN** the user submits the director form with one or more required fields empty
- **THEN** the system displays validation errors and does not insert the document

### Requirement: Read directors
The system SHALL display a list of all directors where `IsActive == true`, showing key attributes (FirstName, LastName, Nationality, Specialization).

#### Scenario: View director list
- **WHEN** the user navigates to the Directors page
- **THEN** the system displays all directors where `IsActive == true` in a table or card layout

#### Scenario: Empty director list
- **WHEN** there are no active directors in the collection
- **THEN** the system displays a message indicating no directors are available

### Requirement: Update a director
The system SHALL allow the user to modify any attribute of an existing director document.

#### Scenario: Successfully update a director
- **WHEN** the user selects an existing director, modifies one or more fields, and submits the form
- **THEN** the system updates the document in MongoDB and the updated values are reflected in the director list

### Requirement: Logical delete a director
The system SHALL implement logical deletion by setting `IsActive = false` instead of physically removing the document.

#### Scenario: Logically delete a director
- **WHEN** the user clicks the delete button on a director
- **THEN** the system sets `IsActive = false` on that document and the director no longer appears in the active director list
