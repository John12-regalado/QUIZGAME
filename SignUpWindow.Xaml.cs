using System.Windows;

namespace QuizGame1WPF
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameInput.Text.Trim();
            string password = PasswordInput.Password;
            string confirmPassword = ConfirmPasswordInput.Password;

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // For now, use raw password as hash (you may replace this with a real hashing function)
            string passwordHash = password;

            // Try to register the user
            bool isRegistered = DatabaseHelper.RegisterUser(username, passwordHash);

            if (isRegistered)
            {
                MessageBox.Show("Account created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Close the sign-up window
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
