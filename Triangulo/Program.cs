using System;

public class Triangulo
{
    private Vertice v1, v2, v3;
    public Triangulo(Vertice v1, Vertice v2, Vertice v3)
    {
        try
        {
            valida(v1, v2, v3);
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }

    static void valida(Vertice v1, Vertice v2, Vertice v3)
    {
        double teste = v1.getX() * (v2.getY() - v3.getY()) +
                        v2.getX() * (v3.getY() - v1.getY()) +
                        v3.getX() * (v1.getY() - v2.getY());

        if (teste == 0)
        {
            throw new Exception("Os vértices não formam um triângulo.");
        }

    }

    public bool eIgual(Triangulo t)
    {
        if (!this.v1.eIgual(t.v1))
        {
            Console.WriteLine("Não são iguais.");
            return false;
        }

        if (!this.v2.eIgual(t.v2))
        {
            Console.WriteLine("Não são iguais.");
            return false;
        }

        if (!this.v3.eIgual(t.v3))
        {
            Console.WriteLine("Não são iguais.");
            return false;
        }

        Console.WriteLine("São iguais.");
        return true;

    }

    public double perimetro()
    {
        double p;

        p = this.v1.distancia(v2) + this.v2.distancia(v3) + this.v3.distancia(v1);

        return p;
    }

    public enum EnumTiposTriangulos
    {
        EQUILATERO,
        ISOSCELES,
        ESCALENO
    };

    public String tipo()
    {
        EnumTiposTriangulos tipo;

        if (this.v1.distancia(v2) == this.v2.distancia(v3) &&
            this.v2.distancia(v3) == this.v3.distancia(v1) &&
            this.v3.distancia(v1) == this.v1.distancia(v2))
        {
            tipo = EnumTiposTriangulos.EQUILATERO;
            return tipo.ToString();
        }

        else if (!(this.v1.distancia(v2) == this.v2.distancia(v3)) &&
                !(this.v2.distancia(v3) == this.v3.distancia(v1)) &&
                !(this.v3.distancia(v1) == this.v1.distancia(v2)))
        {
            tipo = EnumTiposTriangulos.ESCALENO;
            return tipo.ToString();
        }

        else
        {
            tipo = EnumTiposTriangulos.ISOSCELES;
            return tipo.ToString();
        }

        return "";
    }

    public double area()
    {
        double area, a, b, c, s;

        a = this.v1.distancia(v2);
        b = this.v2.distancia(v3);
        c = this.v3.distancia(v1);

        s = (a + b + c) / 2.0;

        area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

        return area;
    }

    public static void Main (String[] args)
    {
        Console.WriteLine("Insira os valores de coordenadas de cada vértice do triângulo:");

        Vertice v1 = new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
        Vertice v2 = new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
        Vertice v3 = new Vertice(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

        Triangulo triangulo = new Triangulo(v1, v2, v3);

        if (triangulo != null)
        {
            Console.Write("O perímetro é de ");
            Console.WriteLine(triangulo.perimetro());
            Console.WriteLine();

            Console.Write("A área é de ");
            Console.WriteLine(triangulo.area());
            Console.WriteLine();

            Console.Write("O triângulo é ");
            Console.WriteLine(triangulo.tipo());
        }

    }
}