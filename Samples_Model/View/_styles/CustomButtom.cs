using System.ComponentModel;
using System.Windows.Forms;

namespace MyModelSample.View._styles
{
    public partial class CustomButtom : Button
    {
        public CustomButtom()
        {
            InitializeComponent();
        }

        public CustomButtom(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}