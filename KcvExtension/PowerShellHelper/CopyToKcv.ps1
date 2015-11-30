#
# Script.ps1
#

$file_path ="D:\My Documents\GitHub\KcvExtension\KcvExtension(Release)";
$copy_path ="E:\Program Files (x86)\KanColleViewer ver.4.1\Plugins";
function copy-to($path, $filename) {
	Copy-Item "$file_path\$path\$filename" "$copy_path\$filename"
}
function copy-to-kcv($name){
	copy-to $name "AMing.KcvExtension.$name.dll"
}

copy-to-kcv "Core" 
copy-to-kcv "Debug"
copy-to-kcv "Settings"
copy-to-kcv "Logger"
copy-to-kcv "Keys"