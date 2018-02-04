import shutil
import os
import sys
import subprocess
import platform

debugMode = ( sys.argv[1] == "Debug" ) or ( sys.argv[1] == "Debug_DirectReadMode")
targetPath = sys.argv[2] + "/"
targetName = sys.argv[3]
currentPath = os.path.split(os.path.realpath(__file__))[0] + "/"
isWin = False
if(platform.system() =="Windows"):
    isWin = True


resPath = currentPath + "/../../Project/Assets/GameFramework/Libraries/"

def mkdirs(path):
    path=path.strip()
    path=path.rstrip("\\")

    isExists=os.path.exists(path)

    if not isExists:
        os.makedirs(path)
        return True
    else:
        return False
mkdirs(resPath)

if debugMode:
    if isWin:
        p = subprocess.Popen([currentPath + "/pdb2mdb", targetName + ".dll"], shell = True, cwd = targetPath)
        p.wait()

    shutil.copy(targetPath + targetName + ".dll.mdb", resPath + targetName + ".dll.mdb")
else:
	 if os.path.exists(resPath + targetName + ".dll.mdb"):
	     os.remove(resPath + targetName + ".dll.mdb")

	 
shutil.copy(targetPath + targetName + ".dll", resPath + targetName + ".dll")
