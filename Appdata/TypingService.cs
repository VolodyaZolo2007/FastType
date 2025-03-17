using System.Windows.Controls;

namespace FastType.Appdata
{
    public class TypingService
    {
        //Создаем поля для хранения и использования элементов управления в рамках класса
        private Grid _keyboardGrid;
        private TextBox _typingTextBox;
        private TextBlock _typingTextBlock;

        //Создаем конструктор класса для ПРИЕМА элементов управления из интефейса(TypingTutorPage.xaml)
        public TypingService(Grid keyboardGrid, TextBox typingTextBox, TextBlock typingTextBlock)
        {
            _keyboardGrid = keyboardGrid;
            _typingTextBox = typingTextBox;
            _typingTextBlock = typingTextBlock;


            _typingTextBox.PreviewKeyDown += _typingTextBox_PreviewKeyDown;
            _typingTextBox.PreviewKeyUp += _typingTextBox_PreviewKeyUp;
        }

        private void _typingTextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void _typingTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            _typingTextBox.Clear();
            _typingTextBox.Text = e.Key.ToString();
        }
    }
}
