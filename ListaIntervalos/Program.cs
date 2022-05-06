using System;

public class ListaIntervalo
{
    private SortedSet<Intervalo> intervalos;

    public ListaIntervalo(Intervalo intervalo)
    {
        this.intervalos = new SortedSet<Intervalo> { intervalo };
    }

    static void valida(SortedSet<Intervalo> listaIntervalos, Intervalo intervalo)
    {
        if (listaIntervalos.Count > 1)
        {
            foreach (Intervalo intervaloLista in listaIntervalos)
            {
                if (intervalo.temIntersecao(intervaloLista))
                {
                    throw new Exception("O intervalo não pode ser inserido pois tem interseção com outro intervalo.");
                }
            }
        }
    }

    public bool add()
    {
        String resposta;
        bool ret = false;

        do
        {
            DateTime dataHoraInicio, dataHoraFim;

            Console.WriteLine("Insira a primeira data e hora: (yyyy MM dd HH:mm:ss)");
            dataHoraInicio = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Insira a segunda data e hora: (yyyy MM dd HH:mm:ss)");
            dataHoraFim = Convert.ToDateTime(Console.ReadLine());

            Intervalo intervalo = new Intervalo(dataHoraInicio, dataHoraFim);

            try
            {
                valida(intervalos, intervalo);
                intervalos.Add(intervalo);
                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ret = false;
            }

            Console.WriteLine("Deseja inserir outro instervalo: (S/N)");
            resposta = Console.ReadLine();

        } while (String.Equals(resposta, "S", StringComparison.OrdinalIgnoreCase));

        return ret;
    }

    public void imprime()
    {
        foreach (Intervalo intervalo in intervalos)
        {
            Console.WriteLine(intervalo.ToString());
        }
    }

    public static void Main(String[] args)
    {
        DateTime dataHoraInicio, dataHoraFim;

        Console.WriteLine("Insira a primeira data e hora: (yyyy MM dd HH:mm:ss)");
        dataHoraInicio = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Insira a segunda data e hora: (yyyy MM dd HH:mm:ss)");
        dataHoraFim = Convert.ToDateTime(Console.ReadLine());

        Intervalo intervalo = new Intervalo(dataHoraInicio, dataHoraFim);
        ListaIntervalo lista = new ListaIntervalo(intervalo);


    }
}
