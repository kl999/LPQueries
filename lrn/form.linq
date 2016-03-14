<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
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

void Main()
{
	var form = new form1();
	form.Show();
}

class form1 : Form
{
	private System.ComponentModel.IContainer components = null;
	
	private System.Windows.Forms.Label label1;

	public form1()
	{
		this.label1 = new System.Windows.Forms.Label();
		
		this.SuspendLayout();
		
		
		//form1
		
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(284, 262);
		this.Controls.Add(this.label1);
		this.Name = "form";
		this.Text = "Hello!";
		this.Load += new System.EventHandler(this.form1_Load);
		//((System.ComponentModel.ISupportInitialize)
		//(this.dataGridView1)).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();
		
		
		//label1
		
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(0, 13);
		this.label1.TabIndex = 0;
	}
	
	private void form1_Load(object sender, EventArgs e)
	{
		label1.Text = "This is form";
	}
	
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}
}