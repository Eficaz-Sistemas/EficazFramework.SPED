# Executa os testes e contrói a tabela de cobertura de código do Coverlet
# Author: Henrique Clausing
Function Coverage() {
	Process {
		$candidates = @(
			(Join-Path $PSScriptRoot "..\Tests\EficazFramework.Tests\EficazFramework.Tests.csproj"),
			"./src/Tests/EficazFramework.Tests/EficazFramework.Tests.csproj",
			"./Tests/EficazFramework.Tests/EficazFramework.Tests.csproj",
			"../Tests/EficazFramework.Tests/EficazFramework.Tests.csproj"
		)
		$projectPath = $null
		foreach ($c in $candidates) {
			if ($c -and (Test-Path $c)) {
				$projectPath = (Resolve-Path $c).ProviderPath
				break
			}
		}

		if (-not $projectPath) {
			Write-Error "Não foi possível localizar EficazFramework.Tests.csproj."
			return
		}

		$coverageDir = Join-Path (Split-Path -Parent $projectPath) "Coverage"

		dotnet test "$projectPath" --filter FullyQualifiedName~EficazFramework.SPED /p:CollectCoverage=true /p:Include="[EficazFramework.SPED*]*" /p:CoverletOutputFormat=cobertura /p:CoverletOutput="$coverageDir/" /p:Exclude="[EficazFramework.Data]*%2c[EficazFramework.Utilities]*%2c[*]EficazFramework.Resources.Strings.*"
					
		$source = "-reports:$coverageDir/coverage.cobertura.xml"
		$target = "-targetdir:$coverageDir/"

		Remove-Item "$coverageDir\*.html" -ErrorAction SilentlyContinue
		Remove-Item "$coverageDir\*.js" -ErrorAction SilentlyContinue
		Remove-Item "$coverageDir\*.css" -ErrorAction SilentlyContinue
		Remove-Item "$coverageDir\*.svg" -ErrorAction SilentlyContinue

		reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart" "-title:EficazFramework.SPED Code Coverage" "-assemblyfilters:-EficazFramework.Data;-EficazFramework.Utilities"
		Invoke-Item "$coverageDir\index.html"
		return
	}
}
