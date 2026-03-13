@echo off
REM Git Repository Cleanup Script for Windows
REM This script removes files that should be ignored from Git tracking

echo ==========================================
echo Git Repository Cleanup Script
echo ==========================================
echo.

REM Check if we're in a git repository
if not exist .git (
    echo Error: Not a git repository!
    echo Please run this script from the root of your git repository.
    pause
    exit /b 1
)

echo Current repository status:
git status --short
echo.

set /p confirm="This will remove cached files from Git. Continue? (y/n): "
if /i not "%confirm%"=="y" (
    echo Cleanup cancelled.
    pause
    exit /b 0
)

echo.
echo Step 1: Removing all files from Git cache...
git rm -r --cached .

echo.
echo Step 2: Re-adding files (respecting .gitignore)...
git add .

echo.
echo Files that will be removed from repository:
git status --short | findstr /B "D"

echo.
echo New files that will be tracked:
git status --short | findstr /B "A"

echo.
set /p commit="Ready to commit these changes? (y/n): "
if /i "%commit%"=="y" (
    echo.
    echo Committing changes...
    git commit -m "Apply .gitignore and remove ignored files from repository"
    
    echo.
    echo Cleanup complete!
    echo.
    echo To push changes to remote, run:
    echo    git push origin main
    echo.
    echo    (Replace 'main' with your branch name if different)
) else (
    echo.
    echo Commit cancelled. Changes are staged but not committed.
    echo    Run 'git reset' to undo staging.
)

echo.
echo ==========================================
echo Cleanup script finished!
echo ==========================================
pause
