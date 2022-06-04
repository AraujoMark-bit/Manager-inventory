using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque.Contract {

    internal interface IContract {

        void Exibir();
        void AddEntry();
        void AddOutput();
    }
}
