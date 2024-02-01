SonarScanner.MSBuild.exe begin /k:"Mediatekdocuments" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="sqp_e338d63bc6a27d212d8e54d9e101908578c2387a"
MsBuild.exe /t:Rebuild
SonarScanner.MSBuild.exe end /d:sonar.token="sqp_e338d63bc6a27d212d8e54d9e101908578c2387a"