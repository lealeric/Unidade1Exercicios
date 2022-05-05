using System;

public class Cadastro
{
    private String nome;
    private long cpf;
    private DateTime dataDeNascimento;
    private float rendaMensal;
    private char estadoCivil;
    private int dependentes;

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

    static void validaNascimento(DateTime dataNasc)
    {
        TimeSpan diferenca  = DateTime.Now - dataNasc;
        int idade = Convert.ToInt32(diferenca.TotalDays / 365.25);

        if (idade < 18)
        {
            throw new Exception("Cliente abaixo de 18 anos.");
        }
    }

    static void validaRenda(String renda)
    {
        if (!renda[renda.Length - 3].Equals(','))
        {
            throw new Exception("Valor fora da formatação XXXXX,XX .");
        }
        else
        {
            String[] sub = renda.Split(',');

            if (sub[1].Length != 2)
            {
                throw new Exception("Valor fora da formatação XXXXX,XX .");
            }
        }
    }

    static void validaEstadoCivil(char c)
    {
        if (c != 'C' && c != 'S' && c != 'D' && c != 'V')
        {
            throw new Exception("Valor inválido.");

        }
    }

    static void validaDependentes(int n)
    {
        if (n < 0 || n > 10)
        {
            throw new Exception("Valor inválido.");
        }
    }

    private enum EstadoCivil
    {
        CASADO, SOLTEIRO, DIVORCIADO, VIÚVO
    }

    private String tipoRelacionamento(char estCiv)
    {
        String estado = "";

        if (estCiv == 'C') { estado = EstadoCivil.CASADO.ToString(); }
        else if(estCiv == 'S') { estado = EstadoCivil.SOLTEIRO.ToString(); }
        else if (estCiv == 'D') { estado = EstadoCivil.DIVORCIADO.ToString(); }
        else if (estCiv == 'V') { estado = EstadoCivil.VIÚVO.ToString(); }

        return estado;
    }

    private bool incluiCadastro()
    {
        bool res;
        String nomeEntrada, cpfEntrada, dataDeNascimentoEntrada, rendaMensalEntrada, estadoCivilEntrada, dependentesEntrada;
        do
        {
            Console.WriteLine("Insira o nome:");
            nomeEntrada = Console.ReadLine();
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
            Console.WriteLine("Insira o CPF:");
            cpfEntrada = Console.ReadLine();
            try
            {
                validaCpf(cpfEntrada);
                this.cpf = Convert.ToInt64(cpfEntrada);
                res = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira a data de nascimento: (YYYY MM DD)");
            dataDeNascimentoEntrada = Console.ReadLine();
            try
            {
                DateTime data = DateTime.Parse(dataDeNascimentoEntrada);
                validaNascimento(data);
                this.dataDeNascimento = data;
                res = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            try
            {
                Console.WriteLine("Insira a renda: ");
                rendaMensalEntrada = Console.ReadLine();
                validaRenda(rendaMensalEntrada);

                rendaMensalEntrada = rendaMensalEntrada.Replace(',', '.');
                this.rendaMensal = float.Parse(rendaMensalEntrada);
                res = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        do
        {
            Console.WriteLine("Insira o estado civil: ");
            estadoCivilEntrada = Console.ReadLine();
            try
            {
                char estCivil = Convert.ToChar(estadoCivilEntrada.ToUpper());
                validaEstadoCivil(estCivil);
                this.estadoCivil = estCivil;
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
            dependentesEntrada = Console.ReadLine();
            try
            {
                int dep = Convert.ToInt32(dependentesEntrada);
                validaDependentes(dep);
                this.dependentes = dep;
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                res = false;
            }
        } while (!res);

        return res;
    }

    public String imprime()
    {
        String saida;

        saida = String.Format("Nome:                {0}\n" +
                              "CPF:                 {1}\n" +
                              "Data de Nascimento:  {2}\n" +
                              "Renda mensal:        {3}\n" +
                              "Estado civil:        {4}\n" +
                              "Dependentes:         {5}",
                              this.nome, this.cpf.ToString(), this.dataDeNascimento.ToString("dd/MM/yyyy"), this.rendaMensal.ToString("C", new System.Globalization.CultureInfo("pt-BR")),
                              this.tipoRelacionamento(this.estadoCivil), this.dependentes.ToString());
                                

        return saida;
    }

    public static void Main(String[] args)
    {
        Cadastro cadastro = new Cadastro();

        Console.WriteLine(cadastro.imprime());
    }

}