using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace RecoinssoFinal.Logica
{
    internal class Core
    {
        //Mensajes del sistema//        
        string caption = "Mensaje del sistema";
        MessageBoxButton buttonOK = MessageBoxButton.OK;
        MessageBoxImage icon = MessageBoxImage.Information;

        public void messageBox(string mensaje) {
            System.Windows.MessageBox.Show(mensaje, caption, this.buttonOK, icon);
        }
    }


}
