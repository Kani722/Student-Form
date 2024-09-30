using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Homework8_Ex0_StudentManagement
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ClassStanding { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Student> students = new List<Student>();
        private string dataFilePath = "students.xml";

        public MainWindow()
        {
            InitializeComponent();
            LoadStudents();
            UpdateStudentsUI();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                RegisterStudent();
                SaveStudents();
                LoadStudents();
                ClearFields();
                UpdateStudentsUI();
            }
        }

        private bool ValidateForm()
        {
            // Validate other fields as needed
            if (string.IsNullOrEmpty(FirstNameTextBox.Text) || string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                MessageBox.Show("Please enter both first name and last name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return ValidateAddress() && ValidatePostCode();
        }

        private bool ValidateAddress()
        {
            // Implement address validation logic
            // Return true if valid, false otherwise
            return true;
        }

        private bool ValidatePostCode()
        {
            // Implement post code validation logic
            // Return true if valid, false otherwise
            if (!System.Text.RegularExpressions.Regex.IsMatch(PostCodeTextBox.Text, @"^\d{5}$"))
            {
                MessageBox.Show("Please enter a valid 5-digit postal code.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void RegisterStudent()
        {
            Student newStudent = new Student
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                DateOfBirth = DateOfBirthDatePicker.SelectedDate ?? DateTime.Now,
                ClassStanding = ((ComboBoxItem)ClassStandingComboBox.SelectedItem)?.Content.ToString(),
                Address = AddressTextBox.Text,
                City = ((ComboBoxItem)CityComboBox.SelectedItem)?.Content.ToString(),
                PostCode = PostCodeTextBox.Text
            };

            students.Add(newStudent);
        }

        private void SaveStudents()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                using (StreamWriter writer = new StreamWriter(dataFilePath))
                {
                    serializer.Serialize(writer, students);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
                    using (StreamReader reader = new StreamReader(dataFilePath))
                    {
                        students = (List<Student>)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStudentsUI()
        {
            StudentsStackPanel.Children.Clear();
            foreach (var student in students)
            {
                StudentsStackPanel.Children.Add(CreateStudentCard(student));
            }
        }

        private UIElement CreateStudentCard(Student student)
        {
            // Implement the logic to create a UI element representing a student card
            // You can use TextBlock, StackPanel, or any other suitable controls
            // Customize based on your UI design preferences
            return new TextBlock
            {
                Text = $"{student.FirstName} {student.LastName}",
                Margin = new Thickness(0, 0, 0, 4),
                FontSize = 14
            };
        }

        private void ClearFields()
        {
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            DateOfBirthDatePicker.SelectedDate = null;
            ClassStandingComboBox.SelectedIndex = 0;
            AddressTextBox.Clear();
            CityComboBox.SelectedIndex = 0;
            PostCodeTextBox.Clear();
        }

        private void ImportStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic to import students from a file
            // Update the students list and UI accordingly
        }

        private void ExportStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement the logic to export students to a file
        }
    }
}
