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
    class Program
    {
        static void Main(string[] args)
        {
            Menu MeuMenu = new Menu(new Operacoes(), new Dados());

            MeuMenu.MostraMenu();
        }
    }
}
