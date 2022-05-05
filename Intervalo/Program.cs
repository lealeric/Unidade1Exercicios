using System;
public class Intervalo
{
    private DateTime dataHoraInicio;
    private DateTime dataHoraFim;

    public Intervalo(DateTime inicio, DateTime fim)
    {
        try
        {
            valida(inicio, fim);
            this.dataHoraInicio = inicio;
            this.dataHoraFim = fim;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        
    }

    static void valida(DateTime inicio, DateTime fim)
    {
        if (inicio > fim)
        {
            throw new InvalidOperationException("A data/hora inicial está depois da data/fora final!");
        }

    }

    public DateTime getDataHoraInicio()
    {
        return dataHoraInicio;
    }

    public DateTime getDataHoraFim()
    {
        return dataHoraFim;
    }

    public bool temIntersecao(Intervalo i1)
    {
        if (this.dataHoraInicio >= i1.dataHoraInicio && 
            this.dataHoraFim <= i1.dataHoraFim)
        {
            return true;
        }

        return false;
    }

    public bool eIgual(Intervalo i1)
    {
        if (this.dataHoraInicio == i1.dataHoraInicio &&
            this.dataHoraFim == i1.dataHoraFim)
        {
            return true;
        }

        return false;
    }

    public String duracao()
    {
        TimeSpan duracao;

        duracao = this.dataHoraFim - this.dataHoraInicio;

        return String.Format("O intervalo entre as datas é de: {0} dias, {1} horas, {2} minutos, {3} segundos.",
                            duracao.Days, duracao.Hours, duracao.Minutes, duracao.Seconds);
    }

    public static void Main (String[] args)
    {

        Intervalo intervalo1, intervalo2;
        DateTime d1, d2, d3, d4;

        Console.WriteLine("Insira a primeira data e hora: (yyyy MM dd HH:mm:ss)");
        d1 = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Insira a segunda data e hora: (yyyy MM dd HH:mm:ss)");
        d2 = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Insira a terceira data e hora: (yyyy MM dd HH:mm:ss)");
        d3 = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Insira a quarta data e hora: (yyyy MM dd HH:mm:ss)");
        d4 = Convert.ToDateTime(Console.ReadLine());

        intervalo1 = new Intervalo(d1, d2);
        intervalo2 = new Intervalo(d3, d4);

        Console.WriteLine(intervalo1.temIntersecao(intervalo2));

        Console.WriteLine(intervalo1.eIgual(intervalo2));

        Console.WriteLine(intervalo1.duracao());
    }
}