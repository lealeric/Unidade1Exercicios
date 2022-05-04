using System;

public class Piramide
{
    private int n;
    public Piramide(int N)
    {

        try
        {
            valida(N);
            this.n = N;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }

    static void valida(int n)
        {
            if (n < 1)
            {
                throw new Exception("O tamanho tem que ser no mínimo 1.");
            }
        }

    public void Desenha()
    {
        int i, j;

        for (i = 0; i <= n; i++)
        {
            for (j = 1; j <= n - i; j++)
            {
                Console.Write(" ");
            }

            for (j = 1; j <= i; j++)
            {
                Console.Write(j);
            }

            for (j = i - 1; j >= 1; j--)
            {
                Console.Write(j);
            }

            Console.WriteLine();
        }
    }
    public static void Main (String[] args)
    {
        int n;

        Console.WriteLine("Insira o tamanho da pirâmide.");

        n = Convert.ToInt32(Console.ReadLine());

        Piramide piramide = new Piramide(n);

        piramide.Desenha();
    }
}

