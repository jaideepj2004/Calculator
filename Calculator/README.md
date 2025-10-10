# JawDropper Calculator

A modern, professional-grade calculator desktop application built with WPF and .NET 8.0.

## Features

- **Modern Dark Theme**: Professional dark interface with rounded corners and smooth hover effects
- **Complete Calculator Functions**: Addition, subtraction, multiplication, division, and modulo operations
- **Decimal Support**: Full support for decimal numbers and operations
- **Error Handling**: Graceful handling of division by zero and invalid operations
- **Chain Calculations**: Supports sequential operations (e.g., 5 + 3 + 2 = 10)
- **Keyboard-Friendly**: Large, responsive buttons with visual feedback
- **Memory Efficient**: Lightweight application with minimal resource usage

## Operations Supported

- **Basic Arithmetic**: +, -, ×, ÷
- **Modulo**: % (remainder operation)
- **Decimal Numbers**: Full decimal point support
- **Negative Numbers**: ± button for sign changes
- **Clear Functions**: C (clear all), ? (backspace)

## Installation

### Option 1: Build from Source
1. Ensure you have .NET 8.0 SDK installed
2. Clone or download this repository
3. Open a command prompt in the project directory
4. Run: `dotnet build`
5. Run: `dotnet run`

### Option 2: Create Standalone Executable
To create a self-contained executable that runs without .NET installation:

```bash
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true
```

The executable will be created at: `bin\Release\net8.0-windows\win-x64\publish\Calculator.exe`

## Technical Details

- **Framework**: WPF (Windows Presentation Foundation)
- **Target Framework**: .NET 8.0
- **Platform**: Windows 10/11 (x64)
- **UI Framework**: Native WPF (not WinUI 3)
- **Deployment**: Single-file executable option available

## Architecture

The calculator follows MVVM principles with clean separation of concerns:

- **MainWindow.xaml**: UI definition with modern styling
- **MainWindow.xaml.cs**: Calculator logic and event handling
- **App.xaml**: Application configuration
- **App.xaml.cs**: Application entry point

## Usage

1. **Number Entry**: Click number buttons (0-9) to enter numbers
2. **Operations**: Click operator buttons (+, -, ×, ÷, %) to perform calculations
3. **Equals**: Click = to complete calculation
4. **Clear**: Click C to reset calculator
5. **Delete**: Click ? to remove last digit
6. **Decimal**: Click . to add decimal point (only one allowed per number)
7. **Negate**: Click ± to toggle between positive and negative

## Example Calculations

- Basic: `5 + 3 = 8`
- Decimal: `3.14 × 2 = 6.28`
- Chain: `10 - 3 + 5 = 12`
- Modulo: `17 % 5 = 2`
- Division: `20 ÷ 4 = 5`

## Error Handling

- Division by zero displays "Error"
- Invalid operations display "Error"
- Press C to clear error state and continue

## System Requirements

- Windows 10 version 1809 or later
- Windows 11 (all versions)
- .NET 8.0 Runtime (included in self-contained build)
- ~50 MB disk space for self-contained executable

## License

This project is provided as-is for educational and personal use.