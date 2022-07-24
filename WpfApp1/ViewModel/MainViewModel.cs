using System;
using System.Windows.Threading;
using WpfApp1.ViewModel.ViewModel;

namespace WpfApp1.ViewModel;

public class MainViewModel : ViewModelBase
{

    public static MainWindow? MVM { get; set; }
    abstract class Responsibility
    {
        protected Responsibility? Next { get; set; }

        public virtual Responsibility SetNext(Responsibility next)
        {
            Next = next;
            return this;
        }
        public abstract void Handle();
    }

    class TXT : Responsibility
    {
        public override void Handle()
        {
            MVM.TB.Text = "Hello ";
            Next?.Handle();
        }
    }

    class TXT1 : Responsibility
    {
        public override void Handle()
        {
            MVM.TB.Text += "World ";
            Next?.Handle();
        }
    }

    class TXT2 : Responsibility
    {
        public override void Handle()
        {
            MVM.TB.Text += "! ";
            Next?.Handle();
        }
    }



    public MainViewModel(MainWindow obj)
    {
        MVM = obj;
        Responsibility compiler = new TXT()
            .SetNext(new TXT1()
            .SetNext(new TXT2()));
        compiler.Handle();
    }


}
