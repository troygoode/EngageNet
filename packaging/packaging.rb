require 'fileutils'

def copy_files(from, to, filename, extensions)
	extensions.each do |ext|
		FileUtils.cp "#{from}#{filename}.#{ext}", "#{to}#{filename}.#{ext}"
	end
end

task :prepare_package do
  output_directory_lib = './packaging/EngageNet/lib/40/'
  FileUtils.mkdir_p output_directory_lib

  copy_files './src/EngageNet/bin/Release/', output_directory_lib, 'EngageNet', ['dll', 'pdb', 'xml']
  copy_files './src/EngageNet.Mvc/bin/Release/', output_directory_lib, 'EngageNet.Mvc', ['dll', 'pdb', 'xml']
end

exec :package => :prepare_package do |cmd|
  cmd.path_to_command = 'packaging/NuPack.exe'
  cmd.parameters [
    'packaging\\EngageNet\\EngageNet.nuspec',
    'packaging\\EngageNet'
  ]
end