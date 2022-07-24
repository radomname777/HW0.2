namespace ChainOfResponsibility
{


    public partial class Form1 : Form
    {
        public static void AddString(string Text)
        {
            MessageBox.Show(Text);
            Nihad.Text = Text;
        }
        abstract class CompilerCOR
        {
            protected CompilerCOR? Next { get; set; }

            public virtual CompilerCOR SetNext(CompilerCOR next)
            {
                Next = next;
                return this;
            }
            public abstract void Handle();
        }

        class SyntaxAnalyzer : CompilerCOR
        {
            public override void Handle()
            {
               // AddString("asdA");
                Next?.Handle();
            }
        }

        class LexicalAnalyzer : CompilerCOR
        {
            
            public override void Handle()
            {
               // A//ddString("Abc");
                Next?.Handle();
            }
        }

        class Linker : CompilerCOR
        {
            public override void Handle()
            {
                //AddString("Nihad");
                Nihad.Text = "A";
                Next?.Handle();
            }
        }



        public Form1()
        {

            CompilerCOR compiler = new SyntaxAnalyzer()
                .SetNext(new LexicalAnalyzer()
                 .SetNext(new Linker()));

            compiler.Handle();
            InitializeComponent();
        }
    }
}