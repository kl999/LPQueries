<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var brain = new NeuralNetwork();
	
	var l1 = new NeuralNetwork.Layer();
	
	l1.neurons.Add(new NeuralNetwork.Neuron(i => i));
	
	l1.neurons.Add(new NeuralNetwork.Neuron(i => i));
	
	brain.addLayer(l1);
	
	var l2 = new NeuralNetwork.Layer();
	
	l2.neurons.Add(new NeuralNetwork.Neuron(i => i > 0.9 ? 1.0 : 0.0));
	
	l2.weights = new double[,] { {0.5, 0.5} };
	
	//l2.weights.Dump();
	
	brain.addLayer(l2);
	
	string str = Console.ReadLine();
	
	brain.work(str.Select(i => i == '1' ? 1.0 : 0.0).ToArray()).Dump();
}

class NeuralNetwork
{
	private List<Layer> layers = new List<Layer>();
	
	public NeuralNetwork()
	{
		
	}
	
	public void addLayer(Layer layer)
	{
		layers.Add(layer);
	}
	
	public double[] work(double[] inArr)
	{
		if(inArr.Length != layers.First().neurons.Count)
		{
			throw new Exception("Bad input length");
		}
		
		double[] neuroLayerOutput = inArr;
		
		for(int i = 1; i < layers.Count; i++)
		{
			neuroLayerOutput = layers[i].getOutput(neuroLayerOutput);
		}
		
		return neuroLayerOutput;
	}
	
	public class Layer
	{
		public List<Neuron> neurons = new List<Neuron>();
		
		public double[,] weights = null;
		
		public double[] getOutput(double[] prevLOutput)
		{
			double[] output = new double[neurons.Count];
			
			int prevct = prevLOutput.Length;
			
			for(int i = 0; i < neurons.Count; i++)
			{
				double sum = 0;
				
				for(int j = 0; j < prevct; j++)
				{
					sum += prevLOutput[j] * weights[i, j];
				}
				
				output[i] = neurons[i].work(sum);
			}
			
			return output;
		}
	}
	
	public class Neuron
	{
		public Func<double, double> f = null;
		
		public Neuron(Func<double, double> _f)
		{
			f = _f;
		}
		
		public double work(double inp)
		{
			return f(inp);
		}
	}
}