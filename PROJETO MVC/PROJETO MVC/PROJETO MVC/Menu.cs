using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PROJETO_MVC
{
    class Menu
    {
        private string CodPesquisa;

        private Operacoes MinhaOperacao;
        private Dados MeusDados;

        public Menu(Operacoes O, Dados D)
        {
            MinhaOperacao = O;
            MeusDados = D;
        }

        public void MostraMenu()
        {
            int Opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("Sistema de cadastro de alunos.");
                Console.WriteLine("==============================");

                Console.WriteLine("1 - Inserir;");
                Console.WriteLine("2 - Alterar;");
                Console.WriteLine("3 - Excluir;");
                Console.WriteLine("4 - Pesquisar;");
                Console.WriteLine("5 - Listar;");
                Console.WriteLine("6 - Ordenar;");
                Console.WriteLine("7 - Salvar dados em arquivo .xml");
                Console.WriteLine("8 - Ler dados em arquivo .xml");
                Console.WriteLine("9 - Sair");

                Console.Write("\nOpção: ");
                Opcao = int.Parse(Console.ReadLine());

                switch (Opcao)
                {
                    case 1:
                        do
                        {
                            Console.Clear();

                            Console.WriteLine("Cadastramento de aluno.");
                            Console.WriteLine("=======================\n");

                            MinhaOperacao.Inserir(new Aluno(), MeusDados);

                            Console.WriteLine("\nInserir outro registro? (ESC para cancelar)...");
                        } while (Console.ReadKey().Key != ConsoleKey.Escape);
                        break;
                    case 2:
                        Console.Clear();

                        Console.WriteLine("Alteração de dados de aluno no cadastro.");
                        Console.WriteLine("========================================\n");

                        Console.Write("Código: ");
                        CodPesquisa = Console.ReadLine();

                        MinhaOperacao.Alterar(CodPesquisa, new Aluno(), new Aluno(), MeusDados);

                        break;
                    case 3:
                        Console.Clear();

                        Console.WriteLine("Exclusão de aluno no cadastro.");
                        Console.WriteLine("==============================\n");

                        Console.Write("Código: ");
                        CodPesquisa = Console.ReadLine();

                        MinhaOperacao.Excluir(CodPesquisa, new Aluno(), MeusDados);

                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("Pesquisa no cadastro de alunos.");
                        Console.WriteLine("===============================\n");

                        Console.Write("Código: ");
                        CodPesquisa = Console.ReadLine();

                        MinhaOperacao.Pesquisar(CodPesquisa, new Aluno(), MeusDados);

                        break;
                    case 5:
                        Console.Clear();

                        Console.WriteLine("Listagem geral do cadastro de alunos.");
                        Console.WriteLine("=====================================\n");

                        MinhaOperacao.Listar(MeusDados);

                        break;
                    case 6:
                        Console.Clear();

                        Console.WriteLine("Ordenação de registros do cadastro de alunos.");
                        Console.WriteLine("=============================================\n");

                        MinhaOperacao.Ordenar(MeusDados);

                        break;
                    case 7:
                        Console.Clear();

                        Console.WriteLine("Salvar arquivo em .xml.");
                        Console.WriteLine("=======================\n");

                        MinhaOperacao.SalvarXML(MeusDados);

                        break;
                    case 8:
                        Console.Clear();

                        Console.WriteLine("Carregar arquivo em .xml.");
                        Console.WriteLine("=========================\n");

                        MinhaOperacao.LerXML(MeusDados);

                        break;
                    case 9:
                        Console.WriteLine("\nSaida do sistema...");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.Write("Opção inválida!!!");
                        Thread.Sleep(2000);
                        break;
                }
            } while (Opcao != 9);
        }
    }
}
