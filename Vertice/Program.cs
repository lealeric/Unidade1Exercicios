using System;
public class Vertice
{
    protected double x, y;

    public Vertice(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double distancia(Vertice v)
    {
        double distancia, distX, distY;

        distX = this.x - v.x;
        distY = this.y - v.y;

        distancia = Math.Sqrt(distX * distX + distY * distY);

        return distancia;
    }

    public void move(double xNovo, double yNovo)
    {
        this.x = xNovo;
        this.y = yNovo;        
    }

    public Boolean eIgual(Vertice v)
    {
        if (this.x != v.x)
        {
            Console.WriteLine("Não são iguais.");
            return false;
        }

        if (this.y != v.y)
        {
            Console.WriteLine("Não são iguais.");
            return false;
        }
                
        Console.WriteLine("São iguais.");
        return true;
        
    }
    public double getX()
    {
        return this.x;
    }

    public double getY()
    {
        return this.y;
    }

    public static void Main(string[] args)
    {
        Vertice vertice1 = new Vertice(0.0, 0.0);
        Vertice vertice2 = new Vertice(3.0, 4.0);

        Console.WriteLine("A distância entre os vértices é de " + vertice1.distancia(vertice2));

        vertice1.eIgual(vertice2);

        vertice2.move(0.0, 0.0);

        vertice1.eIgual(vertice2);

        Console.WriteLine("A distância entre os vértices é de " + vertice1.distancia(vertice2));
    }

}


