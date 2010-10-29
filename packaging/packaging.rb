require 'fileutils'

def copy_files(from, to, filename, extensions)
	extensions.each do |ext|
		FileUtils.cp "#{from}#{filename}.#{ext}", "#{to}#{filename}.#{ext}"
	end
end

task :prepare_package_core => :release do
  output_directory_core = './packaging/EngageNet/lib/40/'
  FileUtils.mkdir_p output_directory_core

  copy_files './src/EngageNet/bin/Release/', output_directory_core, 'EngageNet', ['dll', 'pdb', 'xml']
end

task :prepare_package_mvc => :release do
  output_directory_mvc_lib = './packaging/EngageNet.Mvc/lib/40/'
  output_directory_mvc_content_controllers = './packaging/EngageNet.Mvc/content/Controllers/'
  output_directory_mvc_content_views = './packaging/EngageNet.Mvc/content/Views/Engage/'
  FileUtils.mkdir_p output_directory_mvc_lib
  FileUtils.mkdir_p output_directory_mvc_content_controllers
  FileUtils.mkdir_p output_directory_mvc_content_views

  copy_files './src/EngageNet.Mvc/bin/Release/', output_directory_mvc_lib, 'EngageNet.Mvc', ['dll', 'pdb', 'xml']
  FileUtils.cp './src/EngageNet.SampleWebsiteMvc2/Controllers/EngageController.cs',
               output_directory_mvc_content_controllers + 'EngageController.cs.pp'
  copy_files './src/EngageNet.SampleWebsiteMvc2/Views/Engage/', output_directory_mvc_content_views, 'LogOn', ['aspx']
  copy_files './src/EngageNet.SampleWebsiteMvc2/Views/Engage/', output_directory_mvc_content_views, 'LogOnCancelled', ['aspx']
  copy_files './src/EngageNet.SampleWebsiteMvc2/Views/Engage/', output_directory_mvc_content_views, 'LogOnSuccess', ['aspx']
  
  text = File.read output_directory_mvc_content_controllers + 'EngageController.cs.pp'
  File.open output_directory_mvc_content_controllers + 'EngageController.cs.pp', 'w' do |file|
  	file.puts text.gsub /EngageNet\.SampleWebsiteMvc2/, '$rootnamespace$'
  end
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
    'packaging\\EngageNet.Mvc\\EngageNet.Mvc.nuspec',
    '-o packaging\\EngageNet.Mvc'
  ]
end

task :package => [:package_core, :package_mvc] do
end

task :clean_packages do
	FileUtils.rm_r './packaging/EngageNet/lib/' unless not File.directory? './packaging/EngageNet/lib/'
	FileUtils.rm Dir.glob './packaging/EngageNet/*.nupkg'

	FileUtils.rm_r './packaging/EngageNet.Mvc/lib/' unless not File.directory? './packaging/EngageNet.Mvc/lib/'
	FileUtils.rm_r './packaging/EngageNet.Mvc/content/' unless not File.directory? './packaging/EngageNet.Mvc/content/'
	FileUtils.rm Dir.glob './packaging/EngageNet.Mvc/*.nupkg'
end