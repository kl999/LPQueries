<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

[DllImport("user32.dll")] 
internal static extern short GetKeyState(int keyCode);

[DllImport("user32.dll")]
static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

void Main()
{
	int num = 0x90,
		caps = 0x14,
		scroll = 0x91;
	
	if(GetKeyState(scroll) != GetKeyState(num))
	for(;;)
	{
		PressKeyboardButton(num);
		PressKeyboardButton(scroll);
		
		Task.Delay(500).Wait();
	}
}

private void PressKeyboardButton(int keyCode)
{
    const int KEYEVENTF_EXTENDEDKEY = 0x1;
    const int KEYEVENTF_KEYUP = 0x2;
 
    keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
    keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
}