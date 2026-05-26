# avx-ui

Avalonia-based desktop UI for the avx project.

This repository contains a lightweight Avalonia UI that interacts with the conversion services in this solution.

Prerequisites
- .NET 10 SDK (or later)
- `dotnet` CLI or Visual Studio supporting .NET 10

Build and run
- Restore and build the solution:

```powershell
dotnet restore
dotnet build -c Debug
```

- Run the UI from the repository root:

```powershell
dotnet run --project avx-ui.csproj -c Debug
```

Project layout
- `avx-ui.slnx` — solution file
- `avx-ui.csproj` — main UI project
- `Views/`, `ViewModels/`, `Services/` — UI source folders

Contributing
- Feel free to open issues or PRs. Add implementation notes and tests where appropriate.

License
- Add a license file to this repository if you intend to publish.
