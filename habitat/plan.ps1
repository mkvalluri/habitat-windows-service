$pkg_name="testioservice"
$pkg_origin="samples"
$pkg_version="1.0.0"
$pkg_maintainer="Murali Valluri <mvalluri.pub@gmail.com>"
$pkg_license=@("Apache-2.0")
$pkg_bin_dirs=@("bin")

function invoke-download { }
function invoke-verify { }

function Invoke-Build {
  Copy-Item $PLAN_CONTEXT/../src/* $HAB_CACHE_SRC_PATH/$pkg_dirname -recurse -force -Exclude ".vs"
  ."$env:SystemRoot\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" $HAB_CACHE_SRC_PATH/$pkg_dirname/Source.sln /t:Build /p:Configuration=Release
  if($LASTEXITCODE -ne 0) {
      Write-Error "dotnet build failed!"
  }
}

function Invoke-Install {
  Copy-Item $HAB_CACHE_SRC_PATH/$pkg_dirname/**/bin/release/* $pkg_prefix/bin
}