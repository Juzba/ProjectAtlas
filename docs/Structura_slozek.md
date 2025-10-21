bash
/ (repo root)
??? .github/                # GitHub Actions, issue templates
??? docs/                   # dokumentace, design notes
??? scripts/                # build/deploy helper skripty
??? src/                    # v�echny zdrojov� projekty
?   ??? BlazorLab.Client/
?   ??? BlazorLab.Server/
?   ??? BlazorLab.Shared/
?   ??? BlazorLab.Application/
?   ??? BlazorLab.Domain/
?   ??? BlazorLab.Infrastructure/
??? tests/                  # test projekty
?   ??? BlazorLab.UnitTests/
?   ??? BlazorLab.IntegrationTests/
??? samples/ (voliteln�)    # demo data, seeds, uk�zky
??? docker/ (voliteln�)     # Docker compose / images
??? README.md
??? BlazorLab.sln
??? package.json            # pokud pou��v� npm pro scss build
