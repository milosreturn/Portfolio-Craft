# Portfolio-Craft

Portfolio-Craft is an ASP.NET Core MVC web application that lets students create and publish personal portfolio websites without writing any code. Pick a template, fill in a guided form, preview the result, and deploy live to Netlify in a single click.

## Core User Flow

1. Register / log in (ASP.NET Identity)
2. Browse the template gallery and pick a theme
3. Fill in the portfolio form — personal info, social links, projects, qualifications
4. Preview the generated site in an embedded iframe
5. Deploy with one click — PortfolioCraft handles the Netlify API calls
6. Receive a live URL (`studentname.netlify.app`)
7. Edit and redeploy any time — same site, no new URL

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC 9.0 |
| ORM | EF Core (Npgsql provider) |
| Database | PostgreSQL ([Neon](https://neon.tech)) |
| Auth | ASP.NET Core Identity |
| Frontend | Bootstrap 5 |
| Hosting (deployed sites) | Netlify (via REST API, ZIP deploy) |

## Prerequisites

Before cloning, make sure you have:

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- A [Neon](https://neon.tech) account (free tier works) for the PostgreSQL database
- A [Netlify](https://www.netlify.com) account + personal access token
- Visual Studio / VS Code / Rider, or any editor of your choice

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/PortfolioCraft.git
cd PortfolioCraft
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure secrets

Create (or edit) `appsettings.Development.json` in the project root — **this file is gitignored and will not be committed**, so each collaborator sets up their own:

```json
{
  "ConnectionStrings": {
    "NeonDb": "Host=ep-xxxx.neon.tech;Database=portfoliocraft;Username=YOUR_USER;Password=YOUR_PASSWORD;SSL Mode=Require"
  },
  "Netlify": {
    "AccessToken": "YOUR_PERSONAL_ACCESS_TOKEN",
    "BaseUrl": "https://api.netlify.com/api/v1"
  }
}
```

> Never commit real credentials. Use `dotnet user-secrets` for local development if you'd prefer not to keep them in a JSON file at all.

### 4. Apply database migrations

```bash
dotnet ef database update
```

This creates all tables on your Neon database, including the seeded starter templates.

### 5. Run the project

```bash
dotnet run
```

The app will be available at `https://localhost:5001` (or whichever port the console output shows).

## Project Structure

```
PortfolioCraft/
├── Models/            # EF Core entities (Student, Portfolio, Template, Project, etc.)
├── ViewModels/         # Form & display view models
├── Data/               # AppDbContext, migrations, seed data
├── Repositories/       # Repository pattern + unit-of-work wrapper
├── Services/           # TemplateService, GeneratorService, NetlifyService, AuthService
├── Controllers/        # Home, Account, Template, Portfolio, Deploy
├── Views/              # Razor views (Bootstrap 5)
└── wwwroot/
    ├── css/ js/
    └── templates/      # HTML/CSS per portfolio theme (minimal, bold, academic)
```

## Database Schema (high level)

Seven core entities: `Student`, `Template`, `Portfolio`, `Project`, `Qualification`, `SocialLinks`, `Deployment`. Two `jsonb` columns — `Portfolio.CustomFieldsJson` and `Template.FeatureSchema` — allow template-specific custom fields without further migrations.

Full schema and field-level detail are in the architecture reference doc (not committed to the repo — kept separately).

## Build Roadmap

Development follows a strict sequential milestone order:

- [x] **M1** — Foundation (project setup, DB, models)
- [ ] **M2** — Auth (ASP.NET Identity)
- [ ] **M3** — Template Gallery
- [ ] **M4** — Portfolio Form
- [ ] **M5** — Preview
- [ ] **M6** — Deploy (Netlify integration)

Institutional licensing and the template marketplace are planned as later milestones (M7–M8), and AI-assisted features (bio writing, CV/LinkedIn skill extraction, AI portfolio review) are deferred until after M6.

## Contributing

This is a small, two-person project — no formal PR process yet. If you're a collaborator:

```bash
git pull
# make your changes
git add .
git commit -m "Describe your change"
git push
```

Coordinate on which milestone you're working on to avoid overlapping changes.

## License

Not yet decided — TBD before public release.
