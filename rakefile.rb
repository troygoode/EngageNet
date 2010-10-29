require 'albacore'
require './packaging/packaging'

task :default => [:build]

msbuild :build do |msb|
  msb.path_to_command =  File.join(ENV['windir'], 'Microsoft.NET', 'Framework',  'v4.0.30319', 'MSBuild.exe')
  msb.properties :configuration => :Debug
  msb.targets :Clean, :Rebuild
  msb.solution = "src/EngageNet.sln"
end

nunit :test => :build do |nunit|
  nunit.path_to_command = "src/packages/NUnit.2.5.7.10213/Tools/nunit-console.exe"
  nunit.assemblies "src/EngageNet.Tests/bin/Debug/EngageNet.Tests.dll"
end

msbuild :release => :test do |msb|
  msb.path_to_command =  File.join(ENV['windir'], 'Microsoft.NET', 'Framework',  'v4.0.30319', 'MSBuild.exe')
  msb.properties :configuration => :Release
  msb.targets :Clean, :Rebuild
  msb.solution = "src/EngageNet.sln"
end
