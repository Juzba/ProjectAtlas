Skvěle — níže najdeš hotový, stručný a přehledný „skeleton tree“ (TODO) pro tvé repo. Můžeš ho zkopírovat do README nebo použít jako plán při generování složek souborů. V každé části dávám i krátkou poznámku co tam umístit.

Tip: pokud chceš, můžu tento strom vygenerovat jako scripty pro rychlé vytvoření adresářů a prázdných souborů (bash/PowerShell).

Root (hlavní)
/
├── .github/
│ ├── workflows/
│ │ └── ci.yml # GitHub Actions workflow (build/test/deploy)
│ └── ISSUE_TEMPLATE.md
├── docs/
│ └── architecture.md # stručný popis architektury projektu
├── scripts/
│ ├── migrate-db.sh # skript pro migrace
│ ├── seed-db.sh # seed data
│ └── build-css.sh # build SCSS (volitelně npm script wrapper)
├── src/
│ ├── BlazorLab.Client/ # Blazor WebAssembly (frontend)
│ │ ├── wwwroot/
│ │ │ ├── css/ # compiled CSS (výstup)
│ │ │ ├── js/
│ │ │ ├── images/
│ │ │ └── index.html
│ │ ├── scss/ # zdrojové SCSS soubory
│ │ │ ├── base/
│ │ │ │ ├── _variables.scss
│ │ │ │ ├── _mixins.scss
│ │ │ │ └── _reset.scss
│ │ │ ├── components/
│ │ │ │ └── _button.scss
│ │ │ ├── layouts/
│ │ │ │ └── _header.scss
│ │ │ ├── pages/
│ │ │ │ └── _sudoku.scss
│ │ │ ├── vendors/
│ │ │ └── main.scss # import všech partials -> build target
│ │ ├── Pages/ # Razor pages (feature oriented)
│ │ │ └── Index.razor
│ │ ├── Shared/ # shared layouts, nav, shell
│ │ │ └── MainLayout.razor
│ │ ├── Components/ # komponenty organizované podle features
│ │ │ └── Sudoku/
│ │ │ ├── SudokuBoard.razor
│ │ │ ├── SudokuBoard.razor.cs
│ │ │ └── sudoku.scss # volitelně (importovat do main.scss nebo compile samostatně)
│ │ ├── Services/ # HttpClient wrappers, state management
│ │ │ └── ProjectService.cs
│ │ ├── Models/ # klientské modely (pokud ne vše v Shared)
│ │ └── Program.cs
│ │
│ ├── BlazorLab.Server/ # ASP.NET Core Web API (backend)
│ │ ├── Controllers/
│ │ │ ├── ProjectsController.cs
│ │ │ └── GamesController.cs
│ │ ├── Middlewares/
│ │ │ └── ErrorHandlingMiddleware.cs
│ │ ├── Filters/
│ │ ├── Scripts/ # deployment/seed scripts pro server
│ │ ├── appsettings.json
│ │ └── Program.cs
│ │
│ ├── BlazorLab.Shared/ # sdílené DTOs / kontrakty
│ │ ├── DTOs/
│ │ │ ├── ProjectDto.cs
│ │ │ └── SudokuBoardDto.cs
│ │ ├── Requests/
│ │ │ └── SolveRequest.cs
│ │ ├── Responses/
│ │ ├── Enums/
│ │ └── Mappings/ # AutoMapper profily (volitelně)
│ │
│ ├── BlazorLab.Application/ # business logic (use cases)
│ │ ├── UseCases/ # feature folders (doporučeno)
│ │ │ └── Sudoku/
│ │ │ ├── ISudokuService.cs
│ │ │ ├── SudokuService.cs
│ │ │ └── SolveSudokuCommand.cs
│ │ ├── Services/ # shared app services
│ │ ├── Interfaces/ # repository/service interfaces
│ │ ├── Validators/ # FluentValidation
│ │ └── Exceptions/
│ │
│ ├── BlazorLab.Domain/ # core entities, business rules
│ │ ├── Entities/
│ │ │ ├── Project.cs
│ │ │ ├── Game.cs
│ │ │ └── SudokuCell.cs
│ │ ├── ValueObjects/
│ │ ├── Aggregates/
│ │ └── DomainEvents/
│ │
│ └── BlazorLab.Infrastructure/ # persistence, external services impl.
│ ├── Persistence/
│ │ ├── ApplicationDbContext.cs
│ │ └── Configurations/ # EF Core configurations
│ ├── Migrations/ # EF Core migrations (volitelně)
│ ├── Repositories/
│ │ └── ProjectRepository.cs
│ ├── Services/
│ │ └── EmailService.cs
│ └── Settings/ # options classes for config
│
├── tests/
│ ├── BlazorLab.UnitTests/
│ │ ├── Application/
│ │ └── Domain/
│ ├── BlazorLab.IntegrationTests/
│ │ └── ServerIntegrationTests/
│ └── TestHelpers/
│ └── Fixtures.cs
│
├── BlazorLab.sln
├── README.md
└── package.json # pro scss build (sass), případně v src/BlazorLab.Client

Krátké vysvětlení a doporučení (TODO poznámky)

Umístění projektů: použij src/ pro zdrojové projekty a tests/ pro testy — profesionální standard.
SCSS build: přidej do package.json skript:
"build:css": "sass src/BlazorLab.Client/scss/main.scss src/BlazorLab.Client/wwwroot/css/app.css --no-source-map --style=compressed"
Migrations: ulož DbContext a migrations v BlazorLab.Infrastructure/Persistence. Příklady příkazů:
dotnet ef migrations add Initial -s src/BlazorLab.Server -p src/BlazorLab.Infrastructure
dotnet ef database update -s src/BlazorLab.Server -p src/BlazorLab.Infrastructure
CI: v .github/workflows/ ci.yml nastav kroky:
build scss (npm install + npm run build:css),
dotnet restore / build / test,
dotnet publish pro Server a Client (pokud potřeba).
Feature vs layers:
Backend drž vrstvy (Domain / Application / Infrastructure),
V Application a Client organizuj vnitřek podle feature (Sudoku/, Games/, Projects/) — to zrychlí vývoj a navigaci.
README: přidej start instrukce:
jak buildovat scss,
jak spustit migrace,
jak lokálně spustit (Server jako startup project, Client jako static files pokud Blazor WASM hosted).