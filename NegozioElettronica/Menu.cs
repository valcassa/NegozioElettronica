using NegozioElettronica.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
     

    class Menu
    {
        internal static void Start()
        {   

            bool continuare = true; 
            do
            {
                Console.WriteLine("**** NEGOZIO ELETTRONICA ****");

                Console.WriteLine("1 - Visualizza tutti i prodotti");
                Console.WriteLine("2 - Visualizza tutti i cellulari");
                Console.WriteLine("3 - Visualizza tutti i pc");
                Console.WriteLine("4 - Visualizza tutte le tv");
                Console.WriteLine("5 - Inserisci nuovo prodotto");//un unico metodo di inserimenti che chiede quale entità modificare o tre metodi separati)
                Console.WriteLine("6 - Modifica prodotto");//un unico metodo di inserimenti che chiede quale entità modificare o tre metodi separati)
                Console.WriteLine("7 - Elimina prodotto");  //un unico metodo di eliminazione che chiede quale entità modificare o tre metodi separati)
                Console.WriteLine("8 - Ordina cellulari per memoria"); //x- filtrare i cellulari per memoria superiore a quella scelta
                Console.WriteLine("9 - Ordina pc per sistema operativo");    //- filtrare i pc per sistema operativo scelto dall'utente
                Console.WriteLine("10 - Ordina tv per dimensione schermo");    //- filtrare le tv per pollici uguali a quelli scelti dell'utente
                Console.WriteLine("0 - Esci dal programma");

                Console.WriteLine();


                 string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        DealManager.ShowProducts();
                        break;
                    case "2":
                        DealManager.ShowMobile();
                        break;
                    case "3":
                        DealManager.ShowLaptop();
                        break;
                    case "4":
                        DealManager.ShowTv();
                        break;
                    case "5":
                        DealManager.InsertProducts();
                        break;
                    case "6":
                        DealManager.UpdateProducts();
                        break;

                    case "7":
                        DealManager.DeleteProducts();
                        break;

                    case "8":
                        DealManager.ShowbyMemory();
                        break;

                    case "9":
                        DealManager.ShowbySO();
                        break;

                    case "10":
                        DealManager.ShowbySize();
                        break;

                    case "0":
                        Console.WriteLine("Grazie per averci scelto");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
    }
}