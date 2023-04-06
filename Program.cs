using System;
using BibliLib;
using ControleEntree;

namespace GestionLivres
{
    class Program
    {
        static void Main(string[] args)
        {
            // vars
            int command, messageIndex = 0;
            bool loop = true, testParse;
            string[] message = {"", "== Ce n'est pas une commande valide ==", "== L'action a bien été effectué ==", " == L'action n'a pas été effectué ==" };
            // biblio
            Bibliotheque b1 = new Bibliotheque("biblio");
            // livres
            //Livre l1 = new Livre("1", "monLivre", 2004, "poche", "bozo");
            //Livre l2 = new Livre("2", "tonLivre", 2005, "poche", "bozo");
            //Livre l3 = new Livre("3", "test", 2000, "classique", "bozo");
            //Livre l4 = new Livre("4", "azerty", 2010, "poche", "test");
            //Livre l5 = new Livre("5", "qwerty", 2009, "poche", "test2");

            // loop
            do
            {
                // message affiché à chaque tour
                int nbLivre = b1.Cardinal();
                if (nbLivre > 1) Console.WriteLine("Status de la bibliothèque : " + nbLivre + " livres\n");
                else Console.WriteLine("Status de la bibliothèque : " + nbLivre + " livre\n");
                Console.WriteLine("1- Ajouter un livre\n2- Afficher les livres d'un auteur\n3- Afficher les livres d'un éditeur\n4- Supprimer un livre\n5- Supprimer les livres d'un auteur\n6- Afficher la liste des livres\n0- Fermer le programme\n");
                // je reconnais que la ligne au-dessus est beacoup trop longue mais je n'ai pas eu le choix a cause d'un problème de saut de ligne
                
                // demande de saisie
                Console.WriteLine(message[messageIndex]); // affiche un message selon l'action effectuée
                Console.Write("Quelle action souhaitez-vous effectuer ?\nEntrez le numéro d'action : ");
                testParse = int.TryParse(Console.ReadLine(), out command);
                if (testParse)
                {
                    switch (command)
                    {
                        case 0:
                            loop = false;
                            break;
                        case 1:
                            messageIndex = 0;
                            // collecte les données du nouveau livre
                            Console.WriteLine("Veuillez entrer les données du livre");
                            string codeL = Entree.chaine("Code : ");
                            string titreL = Entree.chaine("Titre : ");
                            int anneeL = Entree.entier("Année : ");
                            string editeurL = Entree.chaine("Editeur : ");
                            string auteurL = Entree.chaine("Auteur : ");
                            // effectue l'ajout
                            b1.AjouterLivre(new Livre(codeL, titreL, anneeL, editeurL, auteurL));
                            messageIndex = 2;
                            break;
                        case 2:
                            messageIndex = 0;
                            string auteurSearch = Entree.chaine("Veuillez saisir le nom de l'auteur des livres : ");
                            Console.Clear();
                            b1.AfficheParAuteur(auteurSearch);
                            Console.Write("\nAppuyez sur une touche pour retourner au menu principal"); Console.ReadKey();
                            break;
                        case 3:
                            messageIndex = 0;
                            string editeurSearch = Entree.chaine("Veuillez saisir le nom de l'editeur des livres : ");
                            Console.Clear();
                            b1.AfficheParEditeurs(editeurSearch);
                            Console.Write("\nAppuyez sur une touche pour retourner au menu principal"); Console.ReadKey();
                            break;
                        case 4:
                            messageIndex = 0;
                            string titreSuppr = Entree.chaine("Veuillez saisir le titre du livre : ");
                            Console.Clear();
                            bool confirmTSuppr = b1.SupprimerLivre(titreSuppr);
                            if (confirmTSuppr) messageIndex = 2; else messageIndex = 3;
                            break;
                        case 5:
                            messageIndex = 0;
                            string auteurSuppr = Entree.chaine("Veuillez saisir le nom de l'auteur des livres : ");
                            Console.Clear();
                            bool confirmASuppr = b1.SupprimerLivreAuteur(auteurSuppr);
                            if (confirmASuppr) messageIndex = 2; else messageIndex = 3;
                            break;
                        case 6:
                            messageIndex = 0;
                            Console.Clear();
                            Console.WriteLine(b1);
                            Console.Write("Appuyez sur une touche pour retourner au menu principal"); Console.ReadKey();
                            break;
                        default:
                            messageIndex = 1;
                            break;
                    }
                    Console.Clear();
                }
                else { messageIndex = 1; Console.Clear(); }
                } while (loop);

        }
    }
}
