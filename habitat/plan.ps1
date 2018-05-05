$pkg_name="testioservice"
$pkg_origin="samples"
$pkg_version="1.0.0"
$pkg_maintainer="Murali Valluri <mvalluri.pub@gmail.com>"
$pkg_license=@("Apache-2.0")

function Invoke-Build {
  Copy-Item $PLAN_CONTEXT/../src/* $HAB_CACHE_SRC_PATH/$pkg_dirname -recurse -force -Exclude ".vs"
  ."$env:SystemRoot\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe" $HAB_CACHE_SRC_PATH/$pkg_dirname/${pkg_name}.csproj /t:Build /p:Configuration=Release
  if($LASTEXITCODE -ne 0) {
      Write-Error "dotnet build failed!"
  }
}

function Invoke-Install {
  Copy-Item $HAB_CACHE_SRC_PATH/$pkg_dirname/bin/release/* $pkg_prefix/bin
}

# $pkg_source="http://some_source_url/releases/${pkg_name}-${pkg_version}.zip"
# $pkg_filename="$pkg_name-$pkg_version.zip"
# $pkg_shasum="TODO"
# $pkg_deps=@()
# $pkg_build_deps=@()
# $pkg_lib_dirs=@("lib")
# $pkg_include_dirs=@("include")
# $pkg_bin_dirs=@("bin")
# $pkg_svc_run="MyBinary.exe"
# $pkg_exports=@{
#   host="srv.address"
#   port="srv.port"
#   ssl-port="srv.ssl.port"
# }
# $pkg_exposes=@("port", "ssl-port")
# $pkg_binds=@{
#   database="port host"
# }
# $pkg_binds_optional=@{
#   storage="port host"
# }
# $pkg_description="Some description."
# $pkg_upstream_url="http://example.com/project-name"
