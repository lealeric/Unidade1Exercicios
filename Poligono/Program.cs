using System;

public class Poligono
{
    private List<Vertice> vertices;
    public Poligono()
    {
        this.vertices = new List<Vertice>();

        Console.WriteLine("Insira as coordenadas do vértice: ");
        vertices.Add(new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine())));

        Console.WriteLine("Deseja inserir outro vértice: (S/N)");
        String resposta = Console.ReadLine();

        if (String.Equals(resposta, "S", StringComparison.OrdinalIgnoreCase))
        {
            this.addVertice();
        }

        else
        {
            try
            {
                valida(vertices);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    static void valida(List<Vertice> v)
    {
        if (v.Count < 3)
        {
            throw new Exception("Número de vértices insuficientes.");
        }
    }

    public int retornaVertices()
    {
        return vertices.Count;
    }

    public void addVertice()
    {
        Console.WriteLine("Insira as coordenadas do vértice: ");
        vertices.Add(new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine())));

        Console.WriteLine("Deseja inserir outro vértice: (S/N)");
        String resposta = Console.ReadLine();

        if (String.Equals(resposta, "S", StringComparison.OrdinalIgnoreCase)){
            this.addVertice();
        }
    }

    public bool removeVertice()
    {
        double x, y;
        Vertice v;

        Console.WriteLine("Insira as coordenadas do vértice: ");
        x = Convert.ToDouble(Console.ReadLine());
        y = Convert.ToDouble(Console.ReadLine());
        v = new Vertice(x, y);

        for (int i = 0; i < vertices.Count; i++)
        {
            if vertices[i]
        }
        return false;
    }
}