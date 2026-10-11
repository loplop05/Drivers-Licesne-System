using System;
using System.Windows.Forms;

namespace DVLD.GlobalClasses
{
    public  class ValidationHelper
    {
        /// <summary>
        /// Validates that a TextBox control has a non-empty, non-whitespace value.
        /// Shows an error message if validation fails.
        /// </summary>
        /// <param name="textBox">The TextBox to validate</param>
        /// <param name="fieldName">The display name of the field (for error messages)</param>
        /// <returns>True if validation passes, false otherwise</returns>
        public static bool ValidateRequiredField(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"Please enter {fieldName}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a ComboBox control has a selected item.
        /// Shows an error message if validation fails.
        /// </summary>
        /// <param name="comboBox">The ComboBox to validate</param>
        /// <param name="fieldName">The display name of the field (for error messages)</param>
        /// <returns>True if validation passes, false otherwise</returns>
        public static bool ValidateRequiredField(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedValue == null)
            {
                MessageBox.Show($"Please select a {fieldName}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a TextBox contains a valid decimal number.
        /// Shows an error message if validation fails.
        /// </summary>
        /// <param name="textBox">The TextBox to validate</param>
        /// <param name="fieldName">The display name of the field (for error messages)</param>
        /// <param name="result">The parsed decimal value if successful</param>
        /// <returns>True if validation passes, false otherwise</returns>
        public static bool ValidateDecimalInput(TextBox textBox, string fieldName, out decimal result)
        {
            result = 0;
            string trimmedText = textBox.Text.Trim();

            if (!decimal.TryParse(trimmedText, out result))
            {
                MessageBox.Show($"Please enter a valid {fieldName}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a TextBox contains a valid integer number.
        /// Shows an error message if validation fails.
        /// </summary>
        /// <param name="textBox">The TextBox to validate</param>
        /// <param name="fieldName">The display name of the field (for error messages)</param>
        /// <param name="result">The parsed integer value if successful</param>
        /// <returns>True if validation passes, false otherwise</returns>
        public static bool ValidateIntegerInput(TextBox textBox, string fieldName, out int result)
        {
            result = 0;
            string trimmedText = textBox.Text.Trim();

            if (!int.TryParse(trimmedText, out result))
            {
                MessageBox.Show($"Please enter a valid {fieldName}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that a TextBox contains a valid email address.
        /// Shows an error message if validation fails.
        /// </summary>
        /// <param name="textBox">The TextBox to validate</param>
        /// <param name="fieldName">The display name of the field (for error messages)</param>
        /// <returns>True if validation passes, false otherwise</returns>
        public static bool ValidateEmail(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Let the required field validation handle empty case
                return true;
            }

            string email = textBox.Text.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show($"Please enter a valid {fieldName}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.SelectAll();
                return false;
            }

            return true;
        }
    }
}
