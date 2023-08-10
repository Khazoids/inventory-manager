using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace InventoryManager.Components
{
    public partial class TextSubmissionModalComponent:UserControl, INotifyPropertyChanged
    {
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(TextSubmissionModalComponent), new PropertyMetadata(false));



        public ICommand SubmitCommand
        {
            get { return (ICommand)GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SubmitCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubmitCommandProperty =
            DependencyProperty.Register("SubmitCommand", typeof(ICommand), typeof(TextSubmissionModalComponent), new PropertyMetadata(null));



        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(TextSubmissionModalComponent), new PropertyMetadata(null));




        public string Prompt
        {
            get { return (string)GetValue(PromptProperty); }
            set { SetValue(PromptProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Prompt.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PromptProperty =
            DependencyProperty.Register("Prompt", typeof(string), typeof(TextSubmissionModalComponent), new PropertyMetadata(String.Empty));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value);
                OnPropertyChanged(nameof(Text));
            }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text", 
                typeof(string), 
                typeof(TextSubmissionModalComponent),
                new PropertyMetadata(OnTextChangedCallBack));

        private static void OnTextChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextSubmissionModalComponent component = sender as TextSubmissionModalComponent;
            if(component != null)
            {
                component.OnTextChanged();
            }
        }

        private void OnTextChanged()
        {
            OnPropertyChanged("Text");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TextSubmissionModalComponent()
        {
            InitializeComponent();
        }
    }
}
