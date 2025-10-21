bash
/ (repo root)
??? .github/                # GitHub Actions, issue templates
??? docs/                   # dokumentace, design notes
??? scripts/                # build/deploy helper skripty
??? src/                    # všechny zdrojové projekty
?   ??? BlazorLab.Client/
?   ??? BlazorLab.Server/
?   ??? BlazorLab.Shared/
?   ??? BlazorLab.Application/
?   ??? BlazorLab.Domain/
?   ??? BlazorLab.Infrastructure/
??? tests/                  # test projekty
?   ??? BlazorLab.UnitTests/
?   ??? BlazorLab.IntegrationTests/
??? samples/ (volitelné)    # demo data, seeds, ukázky
??? docker/ (volitelné)     # Docker compose / images
??? README.md
??? BlazorLab.sln
??? package.json            # pokud používáš npm pro scss build
