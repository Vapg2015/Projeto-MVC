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
    public class Aluno
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Aluno() //Construtor
        {
            Codigo = Guid.NewGuid().ToString().Substring(9, 4).ToUpper(); //Guid - Geracao de um numero unico aleatorio .
        }

        public void LeDados(bool MostraCodigo = true)
        {
            if (MostraCodigo)
                Console.WriteLine("Código: {0}", Codigo);

            Console.Write("Nome do aluno: ");
            Nome = Console.ReadLine();
            Console.Write("Telefone     : ");
            Telefone = Console.ReadLine();
            Console.Write("Email        : ");
            Email = Console.ReadLine();
        }

        public void MostraDados()
        {
            Console.WriteLine("Nome do aluno: {0} ({1})", Nome, Codigo);
            Console.WriteLine("Telefone     : {0}", Telefone);
            Console.WriteLine("Email        : {0}\n", Email);
        }
    }
}
