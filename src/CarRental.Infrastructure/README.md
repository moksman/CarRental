

## Infrastructure Project

In Clean Architecture, Infrastructure concerns are kept separate from the core business rules (or domain model in DDD).

The only project that should have code concerned with EF, Files, Email, Web Services, Azure/AWS/GCP, etc is Infrastructure.

Infrastructure should depend on Core (and, optionally, Use Cases in Application) where abstractions (interfaces) exist.

Infrastructure classes implement interfaces found in the Core (Use Cases) project(s).

These implementations are wired up at startup using DI. In this case using Autofac and the Module classes defined in each project.


Comments:
Use IBaseRepository to decuple Application layer from Infrastructure layer which depends on Entity Framework Core. 
```
Tried creating IAppDbContext but it would require dependency on Entity Framework Core in Application layer.
```
```









Need help? Check out the sample here:
https://github.com/ardalis/CleanArchitecture/sample

Still need help?
Contact us at https://nimblepros.com
