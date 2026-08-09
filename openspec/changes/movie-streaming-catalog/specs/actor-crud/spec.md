## ADDED Requirements

### Requirement: Create an actor
The system SHALL allow the user to create a new actor document in the Actors collection with the following attributes: FirstName (string), LastName (string), BirthDate (DateTime), Nationality (string), Biography (string), AwardsCount (int), PhotoUrl (string), and IsActive (bool, default true).

#### Scenario: Successfully create an actor
- **WHEN** the user fills in all required fields (FirstName, LastName, BirthDate, Nationality, Biography, AwardsCount) and submits the form
- **THEN** the system inserts a new document into the Actors collection with `IsActive = true` and the user is redirected to the actor list

#### Scenario: Create actor with missing required fields
- **WHEN** the user submits the actor form with one or more required fields empty
- **THEN** the system displays validation errors and does not insert the document

### Requirement: Read actors
The system SHALL display a list of all actors where `IsActive == true`, showing key attributes (FirstName, LastName, Nationality, AwardsCount).

#### Scenario: View actor list
- **WHEN** the user navigates to the Actors page
- **THEN** the system displays all actors where `IsActive == true` in a table or card layout

#### Scenario: Empty actor list
- **WHEN** there are no active actors in the collection
- **THEN** the system displays a message indicating no actors are available

### Requirement: Update an actor
The system SHALL allow the user to modify any attribute of an existing actor document.

#### Scenario: Successfully update an actor
- **WHEN** the user selects an existing actor, modifies one or more fields, and submits the form
- **THEN** the system updates the document in MongoDB and the updated values are reflected in the actor list

### Requirement: Logical delete an actor
The system SHALL implement logical deletion by setting `IsActive = false` instead of physically removing the document.

#### Scenario: Logically delete an actor
- **WHEN** the user clicks the delete button on an actor
- **THEN** the system sets `IsActive = false` on that document and the actor no longer appears in the active actor list
