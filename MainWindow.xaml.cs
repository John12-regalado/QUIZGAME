using System.Windows;
using System.Windows.Controls;

namespace QuizGame1WPF
{
    public partial class MainWindow : Window
    {
        private int currentQuestionIndex = 0;
        private int score = 0;

        // Sample questions, choices, and answers
        private readonly string[] questions = new string[]
        {
            "What is the capital of the Philippines?",
            "Which planet is known as the Red Planet?",
            "What is the largest ocean on Earth?"
        };

        private readonly string[][] choices = new string[][]
        {
            new string[] { "Manila", "Cebu", "Davao", "Baguio" },
            new string[] { "Mars", "Venus", "Jupiter", "Saturn" },
            new string[] { "Atlantic", "Pacific", "Indian", "Arctic" }
        };

        private readonly int[] correctAnswers = new int[] { 0, 0, 1 }; // Manila, Mars, Pacific

        public MainWindow()
        {
            InitializeComponent();
            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex >= questions.Length)
            {
                MessageBox.Show($"Quiz Completed!\nYour Score: {score} out of {questions.Length}", "Result");
                this.Close(); // Or go back to login window
                return;
            }

            // Set question and choices
            QuestionText.Text = questions[currentQuestionIndex];
            Option1.Content = choices[currentQuestionIndex][0];
            Option2.Content = choices[currentQuestionIndex][1];
            Option3.Content = choices[currentQuestionIndex][2];
            Option4.Content = choices[currentQuestionIndex][3];

            // Clear previous selection
            Option1.IsChecked = false;
            Option2.IsChecked = false;
            Option3.IsChecked = false;
            Option4.IsChecked = false;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int selected = GetSelectedOption();

            if (selected == -1)
            {
                MessageBox.Show("Please select an answer.", "Warning");
                return;
            }

            if (selected == correctAnswers[currentQuestionIndex])
            {
                score++;
            }

            currentQuestionIndex++;
            LoadQuestion();
        }

        private int GetSelectedOption()
        {
            if (Option1.IsChecked == true) return 0;
            if (Option2.IsChecked == true) return 1;
            if (Option3.IsChecked == true) return 2;
            if (Option4.IsChecked == true) return 3;
            return -1;
        }
    }
}
