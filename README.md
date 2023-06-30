# AspNetCore-CleanArchitecture
The project follows a CLEAN ARCHITECTURE.

Hierarchy:
- src
	- API
		- API(WebAPI Project)
	- Core
		- Domain(Class Library)
		- Application(Class Library)
	- Infra
		- Persistence(Class Library)
		- Infrastructure(Class Library)
		- Identity(Class Library)
	- UI
		- BlazorUI(BlazorWebAssembly)
- test
	- Unit(xUnit)
	- Integration(xUnit)


The project uses the following technologies:

- .NET Core 6
- CQRS
- AutoMapper
- Blazor
- .NET API
- EF Core
- xUnit
- Moq

Packages used:
- AutoMapper
- MediatR
- FluentValidation
- Moq
- Shouldly
- Identity related packages
	- Microsoft.AspNetCore.Identity/Microsoft.AspNetCore.Identity.UI
	- Microsoft.AspNetCore.Identity.EntityFrameworkCore
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools
	- Microsoft.Extensions.Options.ConfigurationExtensions - Options pattern
	- Microsoft.AspNetCore.Authentication.JwtBearer - Required for JwtBearer related code to work.
- Serilog
