@echo off
REM Run a specific question by number
REM Usage: run-question.cmd 1
REM        run-question.cmd 15

if "%1"=="" (
    echo Usage: run-question.cmd [question_number]
    echo Example: run-question.cmd 1
    echo Example: run-question.cmd 15
    exit /b 1
)

set QUESTION_NUM=%1
set STARTUP_OBJ=m1Assessment_Practise.Questions.Question%QUESTION_NUM%.Problem

echo Running Question %QUESTION_NUM%...
echo.

dotnet run --project m1Assessment_Practise.csproj -p:StartupObject=%STARTUP_OBJ%
