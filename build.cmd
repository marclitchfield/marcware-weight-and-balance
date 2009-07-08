copy /y MarcwareWB_PPC.inf obj\debug
call obj\debug\buildcab.bat

copy /y ezsetup.exe cab\debug
copy /y install.ini cab\debug
copy /y readme.txt cab\debug
copy /y eula.txt cab\debug
copy /y icon.ico cab\debug

cd cab\debug
ezsetup -l english -i install.ini -r readme.txt -e eula.txt -o MarcwareWB.exe
pause
