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
static extern bool ClipCursor(ref RECT lpRect);

[DllImport("user32.dll")]
///<summary>
///ZZZZ
///</summary>
static extern bool GetClipCursor(ref RECT lpRect);

void Main()
{
	RECT old = new RECT( 1, 1, 1, 1 );
	GetClipCursor(ref old);
	
	RECT rect =new RECT( 100, 100, 200, 200);
	ClipCursor(ref rect);
	
	old.Dump();
	
	Thread.Sleep(10000);
	
	ClipCursor(ref old);
}

public struct RECT
{
    #region Variables.
    /// <summary>
    /// Left position of the rectangle.
    /// </summary>
    public int Left;
    /// <summary>
    /// Top position of the rectangle.
    /// </summary>
    public int Top;
    /// <summary>
    /// Right position of the rectangle.
    /// </summary>
    public int Right;
    /// <summary>
    /// Bottom position of the rectangle.
    /// </summary>
    public int Bottom;
    #endregion

    #region Operators.
    /// <summary>
    /// Operator to convert a RECT to Drawing.Rectangle.
    /// </summary>
    /// <param name="rect">Rectangle to convert.</param>
    /// <returns>A Drawing.Rectangle</returns>
    public static implicit operator Rectangle(RECT rect)
    {
        return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
    }

    /// <summary>
    /// Operator to convert Drawing.Rectangle to a RECT.
    /// </summary>
    /// <param name="rect">Rectangle to convert.</param>
    /// <returns>RECT rectangle.</returns>
    public static implicit operator RECT(Rectangle rect)
    {
        return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
    }
    #endregion

    #region Constructor.
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="left">Horizontal position.</param>
    /// <param name="top">Vertical position.</param>
    /// <param name="right">Right most side.</param>
    /// <param name="bottom">Bottom most side.</param>
    public RECT(int left, int top, int right, int bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }
    #endregion
}