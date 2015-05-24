@echo off
Packages\xunit.runner.console.2.0.0\tools\xunit.console ^
	Anarchy.Facts\bin\Release\Anarchy.Facts.dll ^
	-parallel all ^
	-html Result.html ^
	-nologo -quiet
@echo on 