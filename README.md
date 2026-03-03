# JawDropper Calculator

A modern, professional **Windows desktop calculator** built with **C# and WPF (.NET)**. The application provides a clean, intuitive UI for performing arithmetic operations with full keyboard-like interaction.

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Usage](#usage)

---

## Overview

JawDropper Calculator is a WPF (Windows Presentation Foundation) desktop application that mimics the look and feel of a modern calculator. It was built to explore XAML-based UI design and event-driven programming in C#.

---

## Features

- **Basic arithmetic** — Addition `+`, Subtraction `-`, Multiplication `×`, Division `÷`
- **Modulo** — `%` operator
- **Decimal support** — Add a decimal point with `.`
- **Negate** — Toggle sign with `±`
- **Clear** — Reset entire input with `C`
- **Backspace** — Delete last digit with the delete button
- **Chained operations** — Automatically evaluates pending operations when a new operator is pressed
- **Division by zero protection** — Displays `Error` instead of crashing
- **Clean WPF XAML UI** with MVVM-friendly code-behind

---

## Tech Stack

| Component | Technology |
|---|---|
| Language | C# |
| UI Framework | WPF (Windows Presentation Foundation) |
| Platform | .NET (Windows) |
| IDE | Visual Studio |

---

## Project Structure

```
Calculator/
├── Calculator.sln                  # Visual Studio solution file
├── Calculator/                     # Main WPF project
│   ├── App.xaml / App.xaml.cs      # Application entry point
│   ├── MainWindow.xaml             # XAML layout — buttons, display
│   ├── MainWindow.xaml.cs          # C# logic — calculator state machine
│   ├── Calculator.csproj           # Project file
│   └── README.md                   # Project-level README
├── JawDropperCalc/                 # Alternate / packaged version
└── Calculator (Package)/           # Packaged distribution
```

---

## Getting Started

### Prerequisites

- Windows OS
- Visual Studio 2019+ (or Visual Studio 2022)
- .NET Desktop Runtime

### Build & Run

1. Open `Calculator.sln` in Visual Studio.
2. Build the solution (`Ctrl+Shift+B`).
3. Run with `F5` or click the **Start** button.

---

## Usage

| Button | Action |
|---|---|
| `0`–`9` | Input digit |
| `+`, `-`, `×`, `÷` | Set arithmetic operator |
| `%` | Modulo |
| `.` | Add decimal point |
| `±` | Negate current number |
| `=` | Evaluate and display result |
| `C` | Clear all input |
| `⌫` (Delete) | Remove last digit |

### Calculator Logic (State Machine)

- The calculator stores `operand1`, `currentOperator`, and `currentInput`.
- When a second operator is pressed and a previous calculation is pending, it auto-calculates first.
- `isNewInput` flag ensures digit input replaces the display after an operator is pressed.
