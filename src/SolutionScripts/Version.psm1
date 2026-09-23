# Retorna um resumo de versão e release notes de todos os projetos do Pipeline.
# Author: Henrique Clausing
Function Get-Versions {
Param (
    [string]$ClearPrompt = 'True'
)
 Process {
    if ($ClearPrompt -eq 'True')
    {
        Clear
    }
    Get-ProjectReleaseStatus -Projectname "EficazFramework.SPED" -SubFolder "\Core"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.SPED.Abstractions" -SubFolder "\Core"
    Get-ProjectReleaseStatus -Projectname "EficazFramework.SPED.Schemas" -SubFolder "\Core"
   }
}


# Executa a verificação de versão entre pacote Nuget e Assembly de cada projeto
# do pipeline, e questiona individudalmente se deve sincronizar os projetos com
# com diferença de versão.
# Author: Henrique Clausing
Function Set-Versions {
 Process {
    Clear
    $new_version = Get-NextVersion
    Set-Version -Projectname "EficazFramework.SPED" -SubFolder "\Core"
    Set-Version -Projectname "EficazFramework.SPED.Abstractions" -SubFolder "\Core"
    Set-Version -Projectname "EficazFramework.SPED.Schemas" -SubFolder "\Core"

    [string]$commitMessage = 'RELEASE ' + [string]$new_version
    [string]$commitTag = [string]'v' + [string]$new_version

    git commit -a -m $commitMessage
    git tag -a $commitTag -m $commitMessage
    Get-Versions -ClearPrompt $False
   }
}


# Retorna um resumo com versão de pacote Nuget, versão de Assembly e Release Notes de um Projeto.
# Author: Henrique Clausing
Function Get-ProjectReleaseStatus {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location

    # NUSPEC FILE:
    [String]$nugetVersion = Get-ProjectNuspecVersion $Projectname $SubFolder

    # ASSEMBLY FILE
    [String]$assemblyVersion = Get-ProjectAssemblyVersion $Projectname $SubFolder
    
    
    Return [String](("{0,-33}" -f $Projectname) + "::  Package: " + $nugetVersion + "  ::  Assembly: "  + $assemblyVersion) #+ "`n" + "Release Notes:" + "`n" + $nugetReleaseNotes.TrimStart())
   }
}


# Retorna a versão do pacote Nuget.
# Author: Henrique Clausing
Function Get-ProjectNuspecVersion {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"

    # NUSPEC FILE:
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)
    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('Version')[0]
    [String]$nugetVersion = $xmlnode_version.InnerText
    
    Return [version]($xmlnode_version.InnerText)
   }
}


# Define a versão do pacote Nuget.
# Author: Henrique Clausing
Function Get-ProjectAssemblyVersion {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"

    # NUSPEC FILE:
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)
    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('AssemblyVersion')[0]
    [String]$nugetVersion = $xmlnode_version.InnerText
    
    Return [version]($xmlnode_version.InnerText)
   }
}


# Define a versão do Pacote e Assembly.
# Author: Henrique Clausing
Function Set-Version {
[cmdletbinding()]
Param (
    [String]$Projectname,
    [String]$SubFolder
)
 Process {
    [String]$location = Get-Location
    [String]$nuspecFilePath   = $location + $SubFolder + "\" + $Projectname + "\" + $Projectname + ".csproj"
    [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
    $xmldoc.Load($nuspecFilePath)

    [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('Version')[0]
    [version]$oldversion = $xmlnode_version.InnerText
    [version]$new_version = [version]::new($oldversion.Major, $oldversion.Minor, $oldversion.Build + 1)
    $xmlnode_version.InnerText = [string]$new_version

    [System.Xml.XmlNode]$xmlnode_assemblyVersion = $xmldoc.GetElementsByTagName('AssemblyVersion')[0]
    $xmlnode_assemblyVersion.InnerText = [string]$new_version + '.0'

    [System.Xml.XmlNode]$xmlnode_fileVersion = $xmldoc.GetElementsByTagName('FileVersion')[0]
    $xmlnode_fileVersion.InnerText = [string]$new_version + '.0'

    # FLUSH
    $xmldoc.Save($nuspecFilePath)
   }
}

Function Get-NextVersion {
    [cmdletbinding()]
    Param (
    )
    Process {
        [String]$location = Get-Location
        [String]$nuspecFilePath   = $location + "\Core\EficazFramework.SPED.Schemas\EficazFramework.SPED.Schemas.csproj"
        [System.Xml.XmlDocument]$xmldoc =  New-Object System.Xml.XmlDocument
        $xmldoc.Load($nuspecFilePath)
        [System.Xml.XmlNode]$xmlnode_version = $xmldoc.GetElementsByTagName('Version')[0]
        [version]$oldversion = $xmlnode_version.InnerText
        [version]$new_version = [version]::new($oldversion.Major, $oldversion.Minor, $oldversion.Build + 1)
        Return [string]$new_version
    }
}