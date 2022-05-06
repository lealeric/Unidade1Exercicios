using System;

public class Cadastro
{
    String nome;
    long cpf;
    DateTime dataDeNascimento;
    float rendaMensal;
    char estadoCivil;
    int depententes;

    public Cadastro()
    {
        this.incluiCadastro();
    }

    static void validaNome(String s)
    {
        if (s.Length < 5)
        {
            throw new Exception("Nome muito curto.");
        }
    }

    static void validaCpf(String s)
    {
        if (s.Length != 11)
        {
            throw new Exception("CPF inválido.");
        }
    }

    static void validaNascimento(DateTime data)
    {
        TimeSpan diferenca = DateTime.Now - data;

        int anos = (int)(diferenca.TotalDays / 365.25);

        if (anos < 18)
        {
            throw new Exception("Cliente menor de 18 anos.");
        }
    }

    static void validaRenda(String s)
    {
        if (s[s.Length - 3] != ',')
        {
            throw new Exception("Valor não está no formato XXXXX,XX.");
        }
        else
        {
            String[] sub = s.Split(',');
            if (sub[1].Length != 2)
            {
                throw new Exception("Valor não está no formato XXXXX,XX.");
            }
        }
    }

    static void validaEstado(char c)
    {
        if (c != 'C' && c != 'S' && c != 'D' && c != 'V')
        {
            throw new Exception("Valor inválido.");
        }
    }

    static void validaDependente(int n)
    {
        if (n < 0 || n > 10)
        {
            throw new Exception("Valor inválido.");
        }
    }

    private enum tipoEstadoCivil
    {
        CASADO,
        SOLTEIRO,
        DIVORCIADO,
        VIÚVO
    }

    private String retornaEstadoCivil(char c)
    {
        String ret = "";

        if (c == 'C') { ret = tipoEstadoCivil.CASADO.ToString(); }
        else if (c == 'S') { ret = tipoEstadoCivil.SOLTEIRO.ToString(); }
        else if (c == 'D') { ret = tipoEstadoCivil.DIVORCIADO.ToString(); }
        else if (c == 'V') { ret = tipoEstadoCivil.VIÚVO.ToString(); }


        return ret;
    }

    private void incluiCadastro()
    {
        bool res;

        do
        {
            Console.WriteLine("Insira o nome: ");
            String nomeEntrada = Console.ReadLine();

            try
            {
                validaNome(nomeEntrada);
                this.nome = nomeEntrada;
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira o CPF: ");
            String cpfEntrada = Console.ReadLine();

            try
            {
                validaCpf(cpfEntrada);
                this.cpf = Convert.ToInt64(cpfEntrada);
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira a data de nascimento: (YYYY MM DD)");
            String dataDeNascimentoEntrada = Console.ReadLine();

            try
            {
                DateTime data = DateTime.Parse(dataDeNascimentoEntrada);
                validaNascimento(data);
                this.dataDeNascimento = data;
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira a renda mensal: ");
            String renda = Console.ReadLine();

            try
            {
                validaRenda(renda);
                renda = renda.Replace(',', '.');

                this.rendaMensal = float.Parse(renda);
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira o Estado Civil: (c,s,v,d)");
            String estadoCivilEntrada = Console.ReadLine();

            try
            {
                char estado = Convert.ToChar(estadoCivilEntrada.ToUpper());
                validaEstado(estado);

                this.estadoCivil = estado;
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira o número de dependentes: ");
            String dependentesEntrada = Console.ReadLine();

            try
            {
                int dep = Convert.ToInt32(dependentesEntrada);
                validaDependente(dep);

                this.depententes = dep;
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);
    }

    public String imprime()
    {
        String saida = "";

        saida = String.Format("Nome:                    {0}\n" +
                      "CPF:                     {1}\n" +
                      "Data de nascimentio:     {2}\n" +
                      "Renda mensal:            {3}\n" +
                      "Estado civil:            {4}\n" +
                      "Dependentes:             {5}\n", this.nome, this.cpf.ToString(), this.dataDeNascimento.ToString("dd/MM/yyyy"),
                      this.rendaMensal.ToString("C", new System.Globalization.CultureInfo("pt-BR")), this.retornaEstadoCivil(this.estadoCivil), this.depententes.ToString()
                      );

        return saida;
    }

    static void Main(String[] args)
    {
        Cadastro cadastro = new Cadastro();

        Console.WriteLine(cadastro.imprime());
    }
}