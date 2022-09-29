# Executa os testes e contrói a tabela de cobertura de código do Coverlet
# Author: Henrique Clausing
Function Coverage() {
	[cmdletbinding()]
Param (
    [String]$area
)
	Process {
		$location = Get-Location

		dotnet test ./Tests/EficazFramework.Tests/EficazFramework.Tests.csproj --filter FullyQualifiedName~EficazFramework.SPED  /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./Coverage/' /p:Exclude="[EficazFramework.Data]*%2c[EficazFramework.Utilities]*%2c[*]EficazFramework.Resources.Strings.*"
					
		$relativepath = 'Tests\EficazFramework.Tests\Coverage'
		$source = '-reports:./' + $relativepath.replace('\','/') + '/coverage.cobertura.xml'
		$target = '-targetdir:./' + $relativepath.replace('\','/') + '/'

		Remove-Item $location\$relativepath\*.html
		Remove-Item $location\$relativepath\*.js
		Remove-Item $location\$relativepath\*.css
		Remove-Item $location\$relativepath\*.svg

		reportgenerator "$source" "$target" "-reporttypes:Html;HtmlChart" "-title:EficazFramework.SPED Code Coverage" "-assemblyfilters:-EficazFramework.Data;-EficazFramework.Utilities"
		Invoke-Item $location\$relativepath\index.html
		return
	}
}