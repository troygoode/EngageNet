require 'fileutils'

def copy_files(from, to, filename, extensions)
	extensions.each do |ext|
		FileUtils.cp "#{from}#{filename}.#{ext}", "#{to}#{filename}.#{ext}"
	end
end

task :prepare_package_core do
  output_directory_core = './packaging/EngageNet/lib/40/'
  FileUtils.mkdir_p output_directory_core

  copy_files './src/EngageNet/bin/Release/', output_directory_core, 'EngageNet', ['dll', 'pdb', 'xml']
end

task :prepare_package_mvc do
  output_directory_mvc = './packaging/EngageNet-Mvc/lib/40/'
  FileUtils.mkdir_p output_directory_mvc

  copy_files './src/EngageNet.Mvc/bin/Release/', output_directory_mvc, 'EngageNet.Mvc', ['dll', 'pdb', 'xml']
end

exec :package_core => :prepare_package_core do |cmd|
  cmd.log_level = :verbose
  cmd.path_to_command = 'packaging/NuPack-CTP2.exe'
  cmd.parameters [
  	'pack',
    'packaging\\EngageNet\\EngageNet.nuspec',
    '-o packaging\\EngageNet'
  ]
end

exec :package_mvc => :prepare_package_mvc do |cmd|
  cmd.path_to_command = 'packaging/NuPack-CTP2.exe'
  cmd.parameters [
  	'pack',
    'packaging\\EngageNet-Mvc\\EngageNet-Mvc.nuspec',
    '-o packaging\\EngageNet-Mvc'
  ]
end

task :package => [:package_core, :package_mvc] do
end

task :clean_packages do
	FileUtils.rm_r './packaging/EngageNet/lib/'
	FileUtils.rm Dir.glob './packaging/EngageNet/*.nupkg'
	FileUtils.rm_r './packaging/EngageNet-Mvc/lib/'
	FileUtils.rm Dir.glob './packaging/EngageNet-Mvc/*.nupkg'
end