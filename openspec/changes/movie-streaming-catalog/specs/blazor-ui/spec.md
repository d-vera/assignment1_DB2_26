## ADDED Requirements

### Requirement: Application shell with navigation
The system SHALL provide a Blazor Server application with a sidebar or top navigation bar containing links to Movies, Actors, and Directors pages.

#### Scenario: Navigate between collection pages
- **WHEN** the user clicks on "Movies", "Actors", or "Directors" in the navigation menu
- **THEN** the corresponding collection list page is displayed

### Requirement: List page layout
Each collection's list page SHALL display records in a table with columns for key attributes, and action buttons for Edit and Delete on each row, plus a "Create New" button.

#### Scenario: View list page with data
- **WHEN** the user navigates to any collection list page that has active records
- **THEN** the page displays a table of records with Edit and Delete action buttons per row, and a "Create New" button at the top

### Requirement: Form page for create and edit
The system SHALL provide a form page for each collection that is used for both creating new records and editing existing ones, with appropriate form controls for each field type.

#### Scenario: Open create form
- **WHEN** the user clicks "Create New" on a collection list page
- **THEN** a form is displayed with empty fields for all attributes of that collection

#### Scenario: Open edit form
- **WHEN** the user clicks "Edit" on a record row
- **THEN** a form is displayed pre-populated with the selected record's current values

### Requirement: Delete confirmation
The system SHALL display a confirmation prompt before performing a logical delete to prevent accidental deletions.

#### Scenario: Confirm delete
- **WHEN** the user clicks "Delete" on a record and confirms the action
- **THEN** the system performs logical deletion and refreshes the list

#### Scenario: Cancel delete
- **WHEN** the user clicks "Delete" on a record and cancels the confirmation
- **THEN** no changes are made and the list remains unchanged

### Requirement: Home page
The system SHALL provide a home/landing page that gives an overview of the application and quick-access links to each collection.

#### Scenario: View home page
- **WHEN** the user opens the application root URL
- **THEN** a home page is displayed with the application name ("MiniNetflix") and navigation links to Movies, Actors, and Directors
