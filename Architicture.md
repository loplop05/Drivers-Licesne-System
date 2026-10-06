# AGENTS.md

## Project Overview

This is a C# Windows Forms application built using a 3-tier architecture.

The project uses:

- C#
- .NET
- Windows Forms
- SQL Server
- ADO.NET
- 3-tier architecture
- DataTable / DataSet where appropriate

The main architectural layers are:

1. Data Access Layer (DAL)
2. Business Logic Layer (BL)
3. Presentation Layer (PL / WinForms)

The existing architecture should be preserved. Do not introduce unnecessary new architectural patterns, frameworks, abstractions, or dependencies.

---

## IMPORTANT: Understand Before Changing

Before modifying code:

1. Inspect the repository structure.
2. Identify the relevant project/layer.
3. Read the related classes and methods.
4. Trace the complete flow of the feature:
   UI → Business Layer → Data Access Layer → Database
5. Check how similar functionality is already implemented elsewhere.
6. Reuse existing patterns whenever possible.
7. Do not modify unrelated files.

For non-trivial tasks, do not immediately start editing.

First determine:

- Which files are involved.
- Which classes are involved.
- Which methods are called.
- How data flows through the application.
- Whether the requested behavior already exists partially somewhere else.

If the request is ambiguous, inspect the codebase first and make the most reasonable interpretation based on the existing implementation.

---

## Architecture

### Data Access Layer (DAL)

The DAL is responsible for communication with SQL Server.

Typical responsibilities:

- SQL queries
- Stored procedures
- Connection handling
- Parameters
- Executing commands
- Reading data
- Returning values/DataTables

Do not put business rules inside the DAL.

Follow the existing database access style instead of introducing a new database framework.

---

### Business Logic Layer (BL)

The Business Layer contains business entities and business logic.

Typical classes use the existing project convention such as:

- `clsUsers`
- `clsPeople`
- `clsUser`
- etc.

The Business Layer communicates with the DAL.

Business classes should not directly manipulate WinForms controls.

Do not put UI logic inside business classes.

---

### Presentation Layer (PL)

The Presentation Layer contains Windows Forms.

Typical responsibilities:

- Forms
- Controls
- User interaction
- Validation
- Displaying data
- Calling Business Layer methods

Forms should communicate with Business Layer classes rather than directly accessing SQL Server.

---

## Existing Code Style

Prefer the coding style already used in the project.

Do not rewrite existing code just to make it "more modern".

Do not introduce:

- unnecessary LINQ
- unnecessary design patterns
- dependency injection frameworks
- repositories
- services
- interfaces
- async/await
- external libraries

unless the existing project already uses them or the task explicitly requires them.

Keep implementations simple and understandable.

---

## Naming

Respect the existing naming conventions.

Examples of existing conventions may include:

- `clsUsers`
- `clsPeople`
- `_RefreshUsersList`
- `frmManageUsers`

Do not rename existing classes, methods, controls, or variables unless explicitly requested.

---

## WinForms

When working with Forms:

- Inspect the existing Designer-generated controls before changing code.
- Do not manually modify `.Designer.cs` unless necessary.
- Preserve existing control names.
- Follow the existing event-handler structure.
- Reuse existing helper methods when possible.

Before creating a new method, check whether an equivalent helper already exists.

---

## Database

Before changing database-related code:

1. Find the existing DAL method.
2. Find the corresponding Business Layer method.
3. Check how parameters are currently passed.
4. Check the database schema or existing SQL queries if available.
5. Follow the existing SQL naming and parameter conventions.

Do not invent database columns, table names, or relationships when they can be determined from the repository.

Do not change the database schema unless explicitly requested.

---

## Debugging

When fixing an error:

1. Read the complete relevant method.
2. Identify the actual type/value flow.
3. Trace where the problematic value originates.
4. Check callers and related methods.
5. Fix the root cause instead of hiding the error.

Do not simply add casts, null checks, or try/catch blocks without understanding why the problem occurs.

For example, if a method expects an `int` but receives a `string`, inspect the method signature and the source of the value before changing the code.

---

## Changes

Keep changes minimal.

Do not modify unrelated code.

Do not perform broad refactoring unless explicitly requested.

If one small change solves the problem, prefer the small change.

Preserve existing behavior unless the requested change requires otherwise.

---

## Before Editing

For every meaningful task, investigate the relevant codebase first.

Use repository search to find:

- class definitions
- method definitions
- method calls
- related forms
- related DAL methods
- related BL methods
- related SQL queries
- similar implementations

Do not assume where something is located.

---

## After Editing

After making changes:

1. Re-read the modified code.
2. Check for compile errors.
3. Check for incorrect namespaces/usings.
4. Check method signatures and callers.
5. Check type compatibility.
6. Check that the change follows the existing architecture.
7. Run the available build/test process when possible.

If a build/test cannot be run, clearly state that instead of claiming it was verified.

---

## Important Rule: Do Not Stop Too Early

Do not stop after finding the first relevant file.

When investigating a feature, trace the complete flow through the codebase.

For example:

Form
→ event handler
→ Business Layer method
→ Data Access method
→ SQL query
→ database

Also inspect the reverse flow when relevant:

database
→ DAL
→ BL object/DataTable
→ Form
→ controls

Continue investigating until you have enough context to make a safe change.

---

## Context Management

The repository is the source of truth.

Do not rely only on previous conversation context.

When starting a new task:

- inspect the relevant files again
- verify assumptions against the current code
- do not assume previous code is unchanged

Important project knowledge should be documented in this file or other project documentation rather than assumed to remain in conversation context.

---

## Communication

When asked to implement something:

For simple tasks:
- briefly explain what you found
- make the change
- explain what changed

For complex tasks:
1. Explain your understanding.
2. Identify relevant files.
3. Explain the intended approach.
4. Implement the change.
5. Verify the result.
6. Summarize the changes.

Do not provide unnecessarily long explanations.

Do not claim something works unless it was actually verified.

---

## User Preference

Prefer simple, practical, beginner-friendly C# solutions.

The goal is to maintain a clean and understandable codebase, not to demonstrate advanced programming techniques.

When multiple solutions are possible, prefer the solution that:

1. Fits the existing architecture.
2. Matches existing project patterns.
3. Is easy to understand.
4. Requires the fewest unnecessary changes.
5. Is reliable and maintainable.