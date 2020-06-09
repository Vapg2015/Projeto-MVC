using System;
using System.Collections;
using System.Collections.Generic;
using System.IO; //TextWriter
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml; //Serializacao
using System.Xml.Serialization;  //Serializacao

namespace PROJETO_MVC
{
    class Dados
    {
        private ArrayList Cadastro;
        public Dados()
        {
            Cadastro = new ArrayList();
        }

        public void InserirAluno(Aluno x)
        {
            Cadastro.Add(x);
        }

        public void AlterarAluno(Aluno x, Aluno y)
        {
            int Posicao;

            Posicao = Cadastro.IndexOf(x);

            y.Codigo = x.Codigo;

            Cadastro.Remove(x);
            Cadastro.Insert(Posicao, y);
        }

        public Aluno PesquisarAluno(string Cod)
        {
            foreach(Aluno x in Cadastro)
            {
                if (x.Codigo.ToUpper() == Cod.ToUpper())
                {
                    return x;
                }
            }

            return null;
        }

        public void ExcluirAluno(Aluno x)
        {
            Cadastro.Remove(x);
        }

        public int OrdenarAlunos()
        {
            Cadastro.Sort(new MinhaOrdenacao());

            return Cadastro.Count;
        }

        public class MinhaOrdenacao : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                return ((Aluno)x).Nome.CompareTo(((Aluno)y).Nome);
            }

        }

        public ArrayList ListarAlunos()
        {
            return Cadastro;
        }

        public int SalvarArquivo()
        {
            TextWriter MeuWriter = new StreamWriter(@"C:\Users\vgalv\Desktop\PROJETO MVC\PROJETO MVC\ArquivoAlunos.xml");

            Aluno[] ListaAlunoVetor = (Aluno[])Cadastro.ToArray(typeof(Aluno));

            //Serializacao
            XmlSerializer Serializacao = new XmlSerializer(ListaAlunoVetor.GetType());

            //Serializa usando o TextWriter
            Serializacao.Serialize(MeuWriter, ListaAlunoVetor);

            MeuWriter.Close();

            return Cadastro.Count;
        }

        public int LerArquivo()
        {
            FileStream Arquivo = new FileStream(@"C:\Users\vgalv\Desktop\PROJETO MVC\PROJETO MVC\ArquivoAlunos.xml", FileMode.Open);

            Aluno[] ListaAlunoVetor = (Aluno[])Cadastro.ToArray(typeof(Aluno));

            XmlSerializer Serializacao = new XmlSerializer(ListaAlunoVetor.GetType());

            ListaAlunoVetor = (Aluno[])Serializacao.Deserialize(Arquivo);

            Cadastro.Clear();

            Cadastro.AddRange(ListaAlunoVetor);

            Arquivo.Close();

            return Cadastro.Count;
        }
    }
}
