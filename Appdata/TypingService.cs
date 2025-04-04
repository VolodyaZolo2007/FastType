﻿using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FastType.Appdata
{
    public class TypingService
    {
        //Создаем поля для ХРАНИЕНИ и ИСПОЛЬЗОВАНИЕ прерменных для внутренней логики класса
        private Stopwatch _stopWatch;

        private int _numberOfCharacters;
        private int _ellapsedTimeInMinutes;

        //Создаем поля для хранения и использования элементов управления в рамках класса
        private Grid _keyboardGrid;
        private TextBox _typingTextBox;
        private TextBlock _typingTextBlock;
        //Создаем свойство для ПОЛУЧЕНИЯ и ПРИСВАИВАНИЯ расчетов
        public int TypeSpeed { get; private set; }

        //Создаем конструктор класса для ПРИЕМА элементов управления из интефейса(TypingTutorPage.xaml)
        public TypingService(Grid keyboardGrid, TextBox typingTextBox, TextBlock typingTextBlock)
        {
            _keyboardGrid = keyboardGrid;
            _typingTextBox = typingTextBox;
            _typingTextBlock = typingTextBlock;


            _typingTextBox.PreviewKeyDown += _typingTextBox_PreviewKeyDown;
            _typingTextBox.PreviewKeyUp += _typingTextBox_PreviewKeyUp;
            _typingTextBox.TextChanged += _typingTextBox_TextChanged;
        }

        private void _typingTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_typingTextBox.Text.Length >= 1 && !_stopWatch.IsRunning)
            {

            }
        }

        private void _typingTextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);


            button.BorderThickness = new Thickness(0.0);

        }

        private void _typingTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var button = FindButtonByKey(e.Key);
            if (button != null)
            {
                button.BorderThickness = new Thickness(2.0, 2.0, 2.0, 4.0);
            }
        }

        private Button FindButtonByKey(Key key)
        {
            foreach (var stackPanel in _keyboardGrid.Children.OfType<StackPanel>())
            {
                foreach (var button in stackPanel.Children.OfType<Button>())
                {
                    if (button.Tag.ToString() == key.ToString())
                    {
                        return button;
                    }
                }
            }
            return null;
        }
    }
}
