@echo off

call MC7D2D BloodMoonVanish.dll /reference:"%PATH_7D2D_MANAGED%\Assembly-CSharp.dll" *.cs && ^
echo Successfully compiled BloodMoonVanish.dll

pause