<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

int ct = 0;

void Main()
{
	var btn = new System.Windows.Forms.Button(){ Text = "Hi" };
	
	//btn.Dump();
	
	btn.Click += button1_Click;
	btn.Dump();
	
	//PanelManager.DisplayControl(btn, "button1");
	
	/*PanelManager.StackWpfElement (
		new System.Windows.Controls.Button()
		{
			Content = "Click me!"
		},
		"WPF Control Gallery");*/
}

private void button1_Click(object sender, EventArgs e)
{
	MessageBox.Show("Hello " + ++ct);
}