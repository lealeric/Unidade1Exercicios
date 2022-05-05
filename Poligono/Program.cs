using System;

public class Poligono
{
    private List<Vertice> vertices;
    public Poligono(List<Vertice> v)
    {
        this.vertices = v;

        try
        {
            validaEntrada(vertices);
        }
        catch (Exception e)
        {            
            Console.WriteLine(e);
        }
    }

    static void validaEntrada(List<Vertice> v)
    {
        if (v.Count < 3)
        {
            throw new Exception("Número de vértices insuficientes.");
        }
    }

    static void validaRemocao(List<Vertice> v)
    {
        if (v.Count == 3)
        {
            throw new Exception("Número de vértices vai ser menor que o mínimo esperado.");
        }
    }

    public int retornaVertices()
    {
        return vertices.Count;
    }

    public void addVertice()
    {
        Console.WriteLine("Insira as coordenadas do vértice para adicionar: ");
        vertices.Add(new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine())));
        Console.WriteLine("Vértice adicionado.");

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

        Console.WriteLine("Insira as coordenadas do vértice para remover: ");
        x = Convert.ToDouble(Console.ReadLine());
        y = Convert.ToDouble(Console.ReadLine());
        v = new Vertice(x, y);

        
            for (int i = 0; i < vertices.Count; i++)
            {  
                   
                    if (vertices[i].getX() == x && vertices[i].getY() == y)
                    {
                        try
                        {
                            validaRemocao(vertices);
                            vertices.RemoveAt(i);
                            Console.WriteLine("Vértice removido.");
                            return true;
                        }                        
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
            }
        Console.WriteLine("Vértice não existe.");
        return false;
    }

    public double perimetro()
    {
        double peri = 0.0;

        for (int i = 0; i < vertices.Count - 1; i++)
        {
            peri += this.vertices[i].distancia(vertices[i + 1]);
        }

        peri += this.vertices[vertices.Count - 1].distancia(vertices[0]);

        return peri;
    }

    public static void Main(String[] args)
    {
        List<Vertice> vertices = new List<Vertice>();

        String resposta;

        

        do
        {
            Console.WriteLine("Insira as coordenadas do vértice: ");
            vertices.Add(new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine())));

            Console.WriteLine("Deseja inserir outro vértice: (S/N)");
            resposta = Console.ReadLine();
            
        } while (String.Equals(resposta, "S", StringComparison.OrdinalIgnoreCase));
        

        Poligono poligono = new Poligono(vertices);

        if (poligono.retornaVertices() > 2)
        {
            poligono.removeVertice();
            
            poligono.addVertice();

            poligono.removeVertice();

            Console.WriteLine(String.Format("O polígono possui {0} vértices.", poligono.retornaVertices()));

            Console.WriteLine(String.Format("O polígono possui um perímtro de {0}.", poligono.perimetro()));
        }
        

    }
}