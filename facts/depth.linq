<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	string[] lns = System.IO.File.ReadAllLines("C:\\sp\\picture.agr");

	int w = lns.Length;
	int h = lns[0].Length;

	bool[,] arr = new bool[w, h];
	
	for(int i = 0; i < w; i++)
	{
		for(int j = 0; j < h; j++)
		{
			if(lns[i][j] == 'x')
				arr[i, j] = true;
		}
	}
	
	//arr.Dump();
	
	string[,] rezArr = new string[w,h];
	
	for(int i = 0; i < w; i++)
	{
		for(int j = 0; j < h; j++)
		{
			if(!arr[i, j])
			{
				rezArr[i, j] = ".";
			}
			else
			{
				rezArr[i, j] = getDepth(arr, i, j).ToString();
			}
		}
	}
	
	rezArr.Dump();
}

int getDepth(bool[,] arr, int x, int y)
{
	int w = arr.GetLength(0);
	int h = arr.GetLength(1);
	
	int border = Math.Max(w, h);
	
	int depth = -1;
	
	for(int dist = 1; dist < border; dist++)
	{
		int xp = dist + x, yp = dist + y;
		int xm = -dist + x, ym = -dist + y;
		
		int stpCt = dist * 2 + 1;
				
		bool found = false;
		
		for(int stp = 0; stp < stpCt; stp++)
		{
			int spx = xp - stp, spy = yp - stp,
				smx = xm + stp, smy = ym + stp;
			
			if(spx < w && spx >= 0 && yp < h)
			{
				if(!arr[xp - stp, yp]) found = true;
			}
			
			if(spy < h && spy >= 0 && xp < w)
			{
				if(!arr[xp, yp - stp]) found = true;
			}
			
			if(smx < w && smx >= 0 && ym >= 0)
			{
				if(!arr[xm + stp, ym]) found = true;
			}
			
			if(smy < h && smy >= 0 && xm >= 0)
			{
				if(!arr[xm, ym + stp]) found = true;
			}
			
			if(found) break;
		}
		
		if(found) { depth = dist; break; }
	}
	
	return depth;
}