# Executa os testes e contrói a tabela de cobertura de código do Coverlet
# Author: Henrique Clausing
Function Coverage() {
	[cmdletbinding()]
Param (
    [String]$area
)
	Process {
		$version = "5.1.3"
		$location = Get-Location

		dotnet test ./Tests/EficazFramework.Tests/EficazFramework.Tests.csproj --no-build /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./Coverage/' /p:Exclude=[*]EficazFramework.Resources.Strings.*%2c[*]EficazFramework.Data.*2c[*]EficazFramework.Utilities.*
					
		$relativepath = 'Tests\EficazFramework.Tests\Coverage'
		$source = '-reports:./' + $relativepath.replace('\','/') + '/coverage.cobertura.xml'
		$target = '-targetdir:./' + $relativepath.replace('\','/') + '/'

		Remove-Item $location\$relativepath\*.html
		Remove-Item $location\$relativepath\*.js
		Remove-Item $location\$relativepath\*.css
		Remove-Item $location\$relativepath\*.svg

		dotnet $env:USERPROFILE\.nuget\packages\reportgenerator\$version\tools\net6.0\ReportGenerator.dll "$source" "$target" "-reporttypes:Html;HtmlChart" "-title:EficazFramework.SPED Code Coverage"
		Invoke-Item $location\$relativepath\index.html
		return
	}
}