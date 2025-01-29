<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var ann = new ANN([2,2]);
	
	ann.ForwardPass([5,3]);
	
	ann.Dump();
}

public class ANN
{
    public List<Layer> Layers = new();
	
	public ANN(List<int> neuronsInLayers)
	{
		if(neuronsInLayers.Count < 2)
			throw new ApplicationException("Must be at least 2 layers!");
		
		Layer prev = null;
		
		foreach(var neuronsInLayer in neuronsInLayers)
		{
			var cur = new Layer(neuronsInLayer);
			
			if (prev is not null)
			foreach(var curNeuron in cur.Neurons)
			foreach(var prevNeuron in prev.Neurons)
			{
				var initialWeight = Random.Shared.NextDouble() * Math.Sqrt(2.0 / prev.Neurons.Count);//(Random.Shared.Next(100) + 1) / 100000.0;
				curNeuron.Connections.Add(new(prevNeuron, initialWeight));
			}
			
			prev = cur;
			Layers.Add(cur);
		}
	}
    
    public double[] ForwardPass(double[] input)
    {
        var inputNeurons = Layers.First().Neurons;
		
		if(input.Length != inputNeurons.Count)
			throw new ApplicationException("input.Length != inputLayer.Neurons.Count");
		
		for(int i = 0; i < input.Length; i++)
			inputNeurons[i].Value = input[i];
		
		foreach(var layer in Layers.Skip(1))
		foreach(var neuron in layer.Neurons)
			neuron.Activate();
		
		return Layers.Last().Neurons.Select(i => i.Value).ToArray();
    }
	
	public void BackwardPass(double[] expectedResult)
	{
		
	}
}

public class Layer
{
    public List<Neuron> Neurons = new();
	
	public Layer(int neuronCount)
	{
		for(int i = 0; i < neuronCount; i++)
		{
			var initialBias = (Random.Shared.Next(100) + 1) / 100000.0;
			Neurons.Add(new(initialBias));
		}
	}
}

public class Neuron
{
	public double Value;
	
	public double Bias;
	
	public List<Connection> Connections = new();
	
	public Neuron(double initialBias)
	{
		Bias = initialBias;
	}
	
	public void Activate()
	{
		var weights = Connections.Sum(i => i.Neuron.Value * i.Weight);
		Value = Activation(weights + Bias);
	}
	
	private double Activation(double value) =>
		//Math.Sin(value);
		Math.Max(0, value);
}

public class Connection
{
	public Neuron Neuron;
	public double Weight;
	
	public Connection(Neuron neuron, double weight)
	{
		Neuron = neuron;
		Weight = weight;
	}
}
