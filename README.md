# Project-Zero (.NET + Angular)

A starter/template for projects using the .NET + Angular stack.  
Goal: kick-start new projects faster without rewriting boilerplate.

## What you get
**Backend**
- EF Core setup (migrations, patterns, lazy loading)
- JWT auth and RBAC (Role-Based Access Control)
- error handling (result pattern)
- event logging
- auditing (columns / trail)
- CQ[R]S (commands/queries), etc.

**Frontend**
- auth, guards/permissions
- layout (menu)
- generic components
- backend communication and error handling
- tables (paging/sort/filter)
- i18n
- validation, etc.

## Requirements
- .NET SDK
- Node.js + npm

### Run locally
1) Backend: `dotnet restore` / `dotnet run`
2) Frontend: `npm install` / `npm start`

## Documentation
- Architecture and conventions: `/docs`
