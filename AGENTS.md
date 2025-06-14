# Continuous Development Guidelines

This repository contains a minimal Unity project for creating a 3D FPS game. The following conventions and checks should be followed when making changes.

## Code Style
- Use four spaces for indentation.
- Public members in C# scripts should use PascalCase. Private fields should use camelCase.

## Programmatic Checks
- Run `dotnet format` before committing if the .NET SDK is installed. This helps maintain consistent formatting.

## Unity
- Do not commit the `Library/` folder or other generated files. The provided `.gitignore` already excludes them.
- Keep `ProjectSettings/ProjectVersion.txt` in sync with your local Unity version.
- Place assets under the `Assets/` directory. Organize scripts under `Assets/Scripts`.

## Git
- Make small, descriptive commits.
- Check `git status` to review changes before committing.

