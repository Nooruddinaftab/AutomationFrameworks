@ECHO OFF
ECHO  Automation Framework Executed Started.

set testcategory=Test Within LoginPageTestCase Class-Login
set dllpath=F:\AutomationFrameworks\AutomationFramework\AutomationFramework\bin\Debug\AutomationFramework.dll
set trxerpath=F:\AutomationFrameworks\AutomationFramework\AutomationFramework\bin\Debug\
set testsummaryreportPath=F:\AutomationFrameworks\AutomationFramework\AutomationFramework\TestSummaryReport\

FOR /f %%a IN ('WMIC OS GET LocalDateTime ^| FIND "."') DO SET DTS=%%a
SET filename=%testcategory%_%DTS:~0,4%%DTS:~4,2%%DTS:~6,2%%DTS:~8,2%%DTS:~10,2%%DTS:~12,2%
echo %filename%

call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
cd %testsummaryreportPath%
md %filename%


VSTest.Console.exe  %dllpath% /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=%testsummaryreportPath%\%filename%\%filename%.trx"

cd %trxerpath%
TrxToHTML.exe %testsummaryreportPath%%filename%\

PAUSE