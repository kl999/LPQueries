<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
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

void Main()
{
    ANN ann = new ANN();
    ann.layers = new byte[3]
    .Select((_, ind) =>
    {
        var l = new Layer();
        
        for(int i = 0; i < 3; i++)
        {
            var n = new Neuron();
            n.name = $"l:{ind};#{i}";
            
            n.activationFunc = inp => inp >= 0.5 ? 1 : 0;
            
            l.neurons.Add(n);
        }
        
        return l;
    })
    .ToArray();
    
    for(int i = 0; i < ann.layers.Length - 1; i++)
    {
        foreach(var inpn in ann.layers[i].neurons)
        {
            foreach(var outn in ann.layers[i+1].neurons)
            {
                var w = new Weight();
                
                w.input = inpn;
                w.output = outn;
                w.mod = 0.9;
                w.name = inpn.name + " -> " + outn.name;
                
                inpn.outputs.Add(w);
                outn.inputs.Add(w);
            }
        }
    }
    
    ann.Dump("pre");
    
    ann.work(new double[]{ 1, 0.5, 0.8 }).Dump("rez");
}

public class ANN
{
    public Layer[] layers;
    
    public double[] work(double[] input)
    {
        if(layers[0].neurons.Count != input.Length)
            throw new Exception("layers[0].neurons.Count != input.Length");
        
        for(int i = 0; i < layers[0].neurons.Count; i++)
            layers[0].neurons[i].active = input[i];
        
        for(int i = 1; i < layers.Length; i++)
        {
            foreach(var neuron in layers[i].neurons)
            {
                var sum = 0.0;
                
                foreach(var weight in neuron.inputs)
                {
                    sum += weight.input.active * weight.mod;
                }
                
                neuron.active = neuron.activationFunc(sum);
            }
        }
        
        return layers[layers.Length - 1].neurons.Select(i => i.active).ToArray();
    }
}

public class Layer
{
    public List<Neuron> neurons = new List<Neuron>();
}

public class Neuron
{
    public string name;
    
    public double active;
    public List<Weight> inputs = new List<Weight>();
    public List<Weight> outputs = new List<Weight>();
    
    public Func<double, double> activationFunc = null;
}

public class Weight
{
    public string name;
    
    public Neuron input;
    public Neuron output;
    public double mod;
}