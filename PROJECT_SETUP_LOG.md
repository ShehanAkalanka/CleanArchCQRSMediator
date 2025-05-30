# Clean Architecture CQRS MediatR Project Setup Log
CleanArchCQRSMediator/
├── CleanArchCQRSMediator.Domain/          # Core business logic
├── CleanArchCQRSMediator.Application/     # Application layer (CQRS handlers)
├── CleanArchCQRSMediator.Infrastructure/  # Data access & external services
└── CleanArchCQRSMediator.Api/             # Web API presentation layer
```

---

## 📦 Package Dependencies

### Domain Layer (`CleanArchCQRSMediator.Domain`)
- ✅ **MediatR** (Version 12.5.0)
  - Purpose: Provides contracts (`IRequest`, `INotification`) for CQRS
  - No implementation dependencies in Domain layer

### Application Layer (`CleanArchCQRSMediator.Application`)
- ✅ **AutoMapper.Extensions.Microsoft.DependencyInjection** (Version 12.0.1)
  - Purpose: Object mapping between DTOs and Domain entities
- ✅ **FluentValidation.DependencyInjectionExtensions** (Version 11.9.2)
  - Purpose: Input validation for commands and queries
- ✅ **Project Reference:** Domain layer

### Infrastructure Layer (`CleanArchCQRSMediator.Infrastructure`)
- ✅ **Project Reference:** Application layer

### API Layer (`CleanArchCQRSMediator.Api`)
- ✅ **Swashbuckle.AspNetCore** (Version 6.6.2)
  - Purpose: API documentation with Swagger
- ✅ **Project Reference:** Application layer
- ✅ **Project Reference:** Infrastructure layer

---

## 🏗️ Folder Structure Setup

### Domain Layer Folders
- ✅ `Entity/` - Domain entities (Book.cs created)
- ✅ `Repository/` - Repository interfaces (IBookRepository.cs created)

### Application Layer Folders (CQRS Structure)
- ✅ `Books/Commands/CreateBook/` - Create book command handlers
- ✅ `Books/Commands/DeleteBook/` - Delete book command handlers
- ✅ `Books/Commands/UpdateBook/` - Update book command handlers
- ✅ `Books/Queries/GetBooks/` - Get all books query handlers
- ✅ `Books/Queries/GetBooksById/` - Get book by ID query handlers
- ✅ `Books/Common/Behaviours/` - Cross-cutting concerns (validation, logging)
- ✅ `Books/Common/Exceptions/` - Custom exceptions
- ✅ `Books/Common/Mappings/` - AutoMapper profiles

### Infrastructure Layer Folders
- ✅ `Data/` - Database context and configurations
- ✅ `Repository/` - Repository implementations

### API Layer Folders
- ✅ `Controllers/` - API controllers

---

## 🔧 Configuration Services

### Application Layer Configuration
**File:** `CleanArchCQRSMediator.Application/ConfigurationServices.cs`
- ✅ AutoMapper registration with assembly scanning
- ✅ MediatR registration with assembly scanning
- ✅ Extension method: `AddApplicationServices()`

### Infrastructure Layer Configuration
**File:** `CleanArchCQRSMediator.Infrastructure/Repository/ConfigurationServices.cs`
- ✅ Extension method: `AddInfrastructureServices()` (ready for DB context registration)

---

### Add those services to programs.cs
**File:** `CleanArchCQRSMediator.Api/Program.cs`
 ✅ Add both AddApplicationServices and AddInfrastructureServices

### Add First Entity
**Folder:** `CleanArchCQRSMediator.Domain/Entity`
 ✅ Add Book.cs file

 ### Add Book Repository interface
**Folder:** `CleanArchCQRSMediator.Domain/Repository`
 ✅ Add IBookRepository.cs file -- it has all references that need to be implemented

 ### Add book view model
**Folder:** `CleanArchCQRSMediator.Application/Books/Queries/GetBooks`
 ✅ Add BookVm.cs file 


 ### Add get book query
**Folder:** `CleanArchCQRSMediator.Application/Books/Queries/GetBooks`
 ✅ Add GetBookQuery.cs file

  ### Add get book query handler
**Folder:** `CleanArchCQRSMediator.Application/Books/Queries/GetBooks`
 ✅ Add GetBookQueryHandler.cs file 

   ### configure automapper to map BookVm from Book
**Folder:** `CleanArchCQRSMediator.Application/Books/Queries/GetBooks`
**File:** `CleanArchCQRSMediator.Application/Books/Queries/GetBooks/BookViewModel.cs`
 ✅ Rename BookVm.cs file to BookViewModel.cs