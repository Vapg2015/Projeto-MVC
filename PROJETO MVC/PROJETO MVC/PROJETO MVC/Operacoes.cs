using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PROJETO_MVC
{
    class Operacoes
    {
        public void Inserir(Aluno MeuAluno, Dados MeusDados)
        {
            MeuAluno.LeDados();

            MeusDados.InserirAluno(MeuAluno);
        }

        public void Listar(Dados MeusDados)
        {
            ArrayList Lista;

            Lista = MeusDados.ListarAlunos();

            foreach(Aluno x in Lista)
            {
                x.MostraDados();
            }

            Console.ReadKey();
        }

        public void Pesquisar(string CodPesquisa, Aluno MeuAluno, Dados MeusDados)
        {
            MeuAluno = MeusDados.PesquisarAluno(CodPesquisa);

            if(MeuAluno != null)
            {
                MeuAluno.MostraDados();
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado!!!");
            }
            Console.ReadKey();
        }

        public void Excluir(string CodPesquisa, Aluno MeuAluno, Dados MeusDados)
        {
            MeuAluno = MeusDados.PesquisarAluno(CodPesquisa);

            if (MeuAluno != null)
            {
                MeuAluno.MostraDados();

                MeusDados.ExcluirAluno(MeuAluno);

                Console.Write("Aluno excluido!!!");
            }
            else
            {
                Console.Write("Aluno não encontrado no cadastro de alunos!!!");
            }
            Console.ReadKey();
        }

        public void Alterar(string CodPesquisa, Aluno MeuAluno, Aluno MeuAlunoAlterado, Dados MeusDados)
        {
            MeuAluno = MeusDados.PesquisarAluno(CodPesquisa);

            if (MeuAluno != null)
            {
                MeuAluno.MostraDados();

                Console.WriteLine("Dados de atualização:\n");

                MeuAlunoAlterado.LeDados(false);

                MeusDados.AlterarAluno(MeuAluno, MeuAlunoAlterado);

                Console.Write("Dados alterados!!!");
            }
            else
            {
                Console.Write("Aluno não encontrado no cadastro de alunos!!!");
            }
            Console.ReadKey();
        }

        public void Ordenar(Dados MeusDados)
        {
            int Registros;

            Registros = MeusDados.OrdenarAlunos();

            Console.Write("Total de registros: {0}", Registros);

            Console.ReadKey();
        }

        public void SalvarXML(Dados MeusDados)
        {
            int TotReg;

            TotReg = MeusDados.SalvarArquivo();

            Console.WriteLine("Arquivo XML gerado com sucesso!!!");
            Console.WriteLine("Total de registros: {0}", TotReg);

            Console.ReadKey();
        }

        public void LerXML(Dados MeusDados)
        {
            int TotReg;

            TotReg = MeusDados.LerArquivo();

            Console.WriteLine("Arquivo XML carregado com sucesso!!!");
            Console.WriteLine("Total de registros: {0}", TotReg);

            Console.ReadKey();
        }
    }
}
