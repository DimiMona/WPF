using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CustomTextBoxControl.View.UserControls
{
	public partial class ClearableTextBox : UserControl
	{
		string placeholder;//переменная где храним подсказки(Имя, Фамилия и т.д.)

		//Свойство, которое позволяет задавать подсказку из XAML (Имя, Фамилия и т.д.)
		public string Placeholder
		{
			get => placeholder;
			set => placeholder = tbPlaceholder.Text = value;
		}

		public ClearableTextBox()
		{
			InitializeComponent();			
			
			this.PreviewKeyDown += ClearableTextBox_PreviewKeyDown;
			txtInput.PreviewKeyDown += TxtInput_PreviewKeyDown;
		}

		//Метод который отвечает за нажатие клавиши с проверкой
		private void HandleKeyPress(KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				txtInput.Text = "";//если пользователь нажимает ESC очищается строка
				e.Handled = true;//Говорит системе: "Я уже обработал эту клавишу, не нужно делать с ней ничего больше".

			}
			else if (e.Key == Key.Enter)
			{
				e.Handled = true;
				//Найди элемент, на котором сейчас курсор
				UIElement nextElement = (UIElement)Keyboard.FocusedElement;
				//Перемести курсор на следующее поле ввода
				nextElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

			}
		}

		
		private void ClearableTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			HandleKeyPress(e);
		}

		
		private void TxtInput_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			HandleKeyPress(e);
		}

		private void btnClear_Click(object sender, RoutedEventArgs e)
		{
			txtInput.Text = "";
			txtInput.Focus();  
		}

		private void txtInput_TextChanged(object sender, TextChangedEventArgs e) =>
			tbPlaceholder.Visibility = txtInput.Text == "" ? Visibility.Visible : Visibility.Hidden;
	}
}
