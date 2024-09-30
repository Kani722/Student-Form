# Student Management System

This repository demonstrates a **Student Management System** built in C# using WPF (Windows Presentation Foundation). The system allows for the creation, validation, and management of student data, saving and loading this information from an XML file. 

## Overview

The main class `MainWindow` demonstrates the functionality of managing student information. The application allows users to add, validate, save, and display student details, which are serialized to an XML file for persistent storage. It includes basic form validation, particularly for names and postal codes, ensuring data integrity.

## Classes

### `Student`
A class representing a student with the following properties:
- `FirstName`: The student's first name.
- `LastName`: The student's last name.
- `DateOfBirth`: The student's date of birth.
- `ClassStanding`: The student's academic class standing (e.g., freshman, sophomore).
- `Address`: The student's home address.
- `City`: The student's city of residence.
- `PostCode`: The student's postal code.

### `MainWindow`
This is the main class that handles the application's user interface and logic. Key functionalities include:
- **AddStudentButton_Click**: Handles adding a new student to the list.
- **ValidateForm**: Ensures that required fields are filled in and valid, including name and postal code.
- **SaveStudents**: Serializes the student list and saves it to an XML file.
- **LoadStudents**: Loads the student list from an XML file during application startup.
- **UpdateStudentsUI**: Dynamically updates the UI to display the list of students.
- **ClearFields**: Clears all input fields after adding a student.
  
## Key Methods
- **ValidateForm**: Validates that the student form is correctly filled out. Specifically checks for non-empty first and last names, and ensures the postal code is a valid 5-digit number.
  
- **RegisterStudent**: Adds a new student to the internal list based on the form data.

- **SaveStudents**: Serializes the current list of students to an XML file for persistent storage.

- **LoadStudents**: Reads from the XML file and populates the student list with the saved data.

- **UpdateStudentsUI**: Updates the user interface with the list of students in the system.

- **ClearFields**: Resets the form fields to default values after a student is added or data is loaded.

## Main Functionality
The main window class (`MainWindow`) contains the primary logic for managing student data, including:
1. Creating a new student record and validating form inputs.
2. Saving the list of students to an XML file.
3. Loading students from the XML file upon application start.
4. Displaying the list of students in the user interface.

## Features

- **Student Data Management**: Add, display, and manage student information.
- **Form Validation**: Validates names and postal codes to ensure accurate data entry.
- **Persistent Storage**: Stores student data in an XML file and loads it upon application startup.
- **Dynamic UI Updates**: Automatically updates the user interface with the list of students after any changes.
  
## Example Usage
1. **Add a Student**: Fill out the student form with the required information, including name, date of birth, class standing, and address. Click "Add Student" to add the student to the list.
2. **Save Data**: The system automatically saves the list of students to the `students.xml` file.
3. **Load Data**: Upon startup, the system automatically loads student data from `students.xml` and displays it.

## Technologies Used
- **C#**
- **WPF (Windows Presentation Foundation)**
- **XML Serialization**: Used for saving and loading student data.

## Main Class: `MainWindow`
The `MainWindow` class contains the core logic for managing students and interacting with the user interface. It demonstrates the following:
- Creating a new student and validating form inputs.
- Saving student data to an XML file.
- Loading student data from an XML file.
- Displaying student data in the UI.


