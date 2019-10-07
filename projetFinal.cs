using System;

//Ce programme servira a décrypter un message crypté grace a un algorithme de décalage
//Auteur : Clément GEYER

class projet_final
{
	static void Main()
	{
		//Déclaration et initialisation des variables
		int decalage = 0;
		int occurence = 0;
		int nbr = 0;
		char reponse = ' ';
		bool continuer = true;
		string msg_utilisateur = "";
		string lettre_max = "";
		string chaine_decryptee = "";
		string message = "";
		string harm = "";
		string crypt = "";
		string decrypt_brute = "";

		//Menu
		while(continuer == true)
		{
			//Demande a l'utilisateur ce qu'il veut faire
			Console.WriteLine("Que voulez-vous faire ? (1: Crypter un message; 2: Décrypter façon brute; 3: Décrypter par fréquence. \n");
			nbr = int.Parse(Console.ReadLine());
			//S'il veut crypter un message, le programme rentre dans cette condition
			if(nbr == 1)
			{
				//Il demande a l'utilisateur d'entrer son message puis le décalage qu'il veut appliquer au message
				Console.WriteLine("Quel est votre message ? \n");
				message = Console.ReadLine();
				Console.WriteLine("Quel est le décalage souhaité ? \n");
				decalage = int.Parse(Console.ReadLine());
				//Ensuite on appelle les fonctions d'harmonisation et de cryptage qui servent a supprimer les caractères interdits et crypter le message
				harm = supprim_interdit(message);
				crypt = cryptage_chaine(harm, decalage);
				//Puis on écris simplement le message
				Console.WriteLine("Le message crypté est : " + crypt + "\n");
			}
			//S'il veut décrypter de façon brute, le programme rentre dans cette condition
			else if(nbr == 2)
			{
				//Ensuite si l'utilisateur n'a crypter aucun message précédemment, le programme rentre dans cette condition
				if(message == "")
				{
					//Ici on demande a l'utilisateur de saisir le message qu'il veut décrypter ou de taper Q s'il n'a aucun message a décrypter
					Console.WriteLine("Veuillez saisir votre message crypté : (Q si vous n'en avez pas) \n");
					msg_utilisateur = Console.ReadLine();
					if(msg_utilisateur == "Q")
					{
						//S'il appuie sur Q, on sors de la condition
						Console.WriteLine("Aucun message crypté, veuillez réessayer." + "\n");
					}
					else
					{
						//S'il saisit son message on remplace la valeur du message crypté par le message que l'utilisateur nous a donné et on l'affiche
						crypt = msg_utilisateur;
						Console.WriteLine("Le dernier message crypté est : " + crypt + "\n");
						//Puis on execute la fonction de décryptage brute où se passera le décryptage
						decryptage_brute(crypt);
					}	
				}
				//Si l'utilisateur a précédemment crypté un message, il sera déjà enregistré dans le programme
				else
				{
					Console.WriteLine("Le dernier message crypter est : " + crypt + "\n");
					//Donc ici on execute simplement la fonction de décryptage brute
					decryptage_brute(crypt);
				}
			}
			//S'il veut décrypter un message par fréquence le programme rentre dans cette condition
			else if(nbr == 3)
			{
				//Ensuite si l'utilisateur n'a crypter aucun message précédemment, le programme rentre dans cette condition
				if(message == "")
				{
					//Ici on demande a l'utilisateur de saisir le message qu'il veut décrypter ou de taper Q s'il n'a aucun message a décrypter
					Console.WriteLine("Veuillez saisir votre message crypté : (Q si vous n'en avez pas) \n");
					msg_utilisateur = Console.ReadLine();
					if(msg_utilisateur == "Q")
					{
						//S'il appuie sur Q, on sors de la condition
						Console.WriteLine("Aucun message crypté, veuillez réessayer." + "\n");
					}
					else
					{
						//S'il saisit son message on remplace la valeur du message crypté par le message que l'utilisateur nous a donné et on l'affiche
						crypt = msg_utilisateur;
						Console.WriteLine("Le dernier message crypté est : " + crypt + "\n");
						//Puis on execute les 2 fonctions permettant de faire fonctionner le décryptage fréquence et tout se passera dans la fonction
						lettre_max = lettreMax(crypt);
						decryptageFrequence(lettre_max, crypt);
					}	
				}
				//Si l'utilisateur a précédemment crypté un message, il sera déjà enregistré dans le programme
				else
				{
					Console.WriteLine("Le dernier message crypter est : " + crypt + "\n");
					//On execute donc les 2 fonctions permettant de faire fonctionner le décryptage fréquence
					lettre_max = lettreMax(crypt);
					decryptageFrequence(lettre_max, crypt);
				}	
			}
			//S'il saisit autre chose que 1, 2 ou 3 on lui renvoie un message d'erreur
			else
			{
				Console.WriteLine("Fonction introuvable, veuillez recommencer. \n");
			}
			//Ensuite on demande a l'utilisateur s'il veut continuer ou non de rester dans le programme
			Console.WriteLine("Voulez-vous continuer ? (O/N) \n");
			reponse = char.Parse(Console.ReadLine());
			//S'il repond N on sors du programme, sinon on recommence
			if(reponse == 'N')
			{
				continuer = false;
				Console.WriteLine("Aurevoir \n");
			}
		}
	}


	/*
		supprim_interdit : fonction : string
		Cette fonction sert a harmoniser les caractères; les laisser s'ils sont en minuscule, les mettre en minuscule s'ils sont en majuscule
		 et les supprimer s'ils sont autres que des lettres.
		Paramètres :
			xMessage : string
		Local :
			i : int
			caractere : int
			longeur : int
			nvl_chaine : string
		Retour :
			nvl_chaine : string
	*/
	public static string supprim_interdit(string xMessage)
	{
		//Déclaration des variables
		int i;
		int caractere;
		int longeur;
		string nvl_chaine = "";

		//On prend le nombre de caractères de la chaîne
		longeur = xMessage.Length;

		//Ensuite on effectue une boucle 'pour' afin de traiter la chaîne caractère par caractère
		for(i=0;i<longeur;i++)
		{
			//Ici on utilise une conversion explicite avec le (int) car on a une conversion type en numérique
			caractere = (int)(xMessage[i]);

			//Ensuite on effectue une condition 'if', la première condition cherche les caractères en minuscule
			if(caractere > 96 && caractere < 123)
			{
				//Les caractères en minuscule sont donc introduits dans la nouvelle chaîne
				nvl_chaine += (char)(caractere);
			}
			//La deuxième condition cherche les caractères en majuscule
			else if(caractere > 64 && caractere < 91)
			{
				//Les caractères en majuscule sont transformés en minuscule grace au code ASCII
				nvl_chaine += (char)(caractere + 32);
			}
			else
			{
				//Tous les autres caractères sont supprimés
				caractere = 0;
			}
		}
		return nvl_chaine;
	}




	/*
		cryptage_chaine : fonction : string
		Cette fonction sert a crypter la chaîne de caractère harmonisée
		Paramètres :
			xHarm : string
			xDecalage : int
		Local :
			i : int
			caractere : int
			longeur : int
			reste : int
			chaine_cryptee : string
		Retour :
			chaine_cryptee : string
	*/
	public static string cryptage_chaine(string xHarm, int xDecalage)
	{
		//Déclaration des variables
		int j;
		int k;
		int decalage;
		int nombre;
		int longeur;
		int caractere;
		int reste;
		string chaine_cryptee = "";

		//On prend le nombre de caractères de la chaîne
		longeur = xHarm.Length;

		//On utilise une boucle 'pour' afin de traiter caractère par caractère
		for(j=0;j<longeur;j++)
		{
			nombre = xHarm[j];
			if(xDecalage < 0)
			{
				decalage = 1;
				for(k=0;k>xDecalage;k--)
				{
					nombre = nombre - decalage;
					if(nombre < 97)
					{
						nombre = 122;
					}
				}
			}
			else
			{
				decalage = 1;
				for(k=0;k<xDecalage;k++)
				{
					nombre = nombre + decalage;
					if(nombre > 122)
					{
						nombre = 97;
					}
				}
			}
			chaine_cryptee += (char)(nombre);
		}
		return chaine_cryptee;
	}




	/*
		decryptage_brute : fonction : string
		Cette fonction sert a décryptée le message crypté de façon 'brutale', c'est a dire en testant de changer le message lettre
		 par lettre jusqu'à ce que l'utilisateur puisse comprendre le message
		Paramètres :
			xCrypt : string
		Local :
			k : int
			l : int
			reste : int
			caractere : int
			reponse : bool
			rep_utilisateur : string
			decryptage : string
		Retour :
			decryptage : string
	*/
	public static string decryptage_brute(string xCrypt)
	{
		//Déclaration des variables
		int k;
		int l = 1;
		int reste;
		int caractere;
		bool reponse = false;
		string rep_utilisateur;
		string decryptage = "";

		//On utilise une boucle 'while' afin de proposer un décryptage a l'utilisateur jusqu'à ce que le programme trouve la bonne solution
		while(reponse == false)
		{
			//On utilise le même principe de la boucle 'for' que dans la fonction 'cryptage_chaine' mais pour le décryptage
			for(k=0;k<xCrypt.Length;k++)
			{
				//Ici on utilise une conversion explicite avec le (int) car on a une conversion type en numérique
				caractere = (int)(xCrypt[k]);
				//Ensuite la condition 'if' va traiter le moments ou les caractères dépasseront 'z' et recommencera a 'a'
				if(caractere > 122 - l)
				{
					//On utilise le même systeme de reste que dans le cryptage et ensuite on ajoute le caractère a la nouvelle chaîne
					reste = 122 - caractere;
					decryptage += (char)(96 + l - reste);
				}
				else
				{
					//Ici le cas de toutes les lettres sauf 'z'
					decryptage += (char)(caractere + l);
				}
			}

			//Puis on écris la chaîne proposée et on demande a l'utilisateur si le message est compréhensible
			Console.WriteLine("Proposition " + decryptage);
			Console.WriteLine("Le message est-il compréhensible ? (O/N) \n");
			rep_utilisateur = Console.ReadLine();

			//Si le message est compréhensible on utilise la condition 'if' ci-dessous pour faire passer le booleen en 'true' et sortir
			// de la boucle 'while'
			if(rep_utilisateur == "O")
			{
				reponse = true;
			}
			//Si l'utilisateur ne comprend pas le message, on efface ce qu'il y a dans la chaîne et on recommence le processus
			else
			{
				decryptage = decryptage.Remove(0,xCrypt.Length);
			}
			l++;
		}
		return decryptage;
	}


	public static int nbOcc(char xCaractere, string xCrypt)
	{
		//Déclaration des variables
		int i;
		int nombre_occurence = 0;
		for(i=0;i<xCrypt.Length;i++)
		{
			if(xCrypt[i] == xCaractere)
			{
				nombre_occurence++;
			}
		}
		return nombre_occurence;
	}


	public static string lettreMax(string xCrypt)
	{
		int i = 0;
		int reponse = 0;
		char maxOcc = ' ';
		string chMaxOcc = "";
		while(chMaxOcc.Length < xCrypt.Length)
		{
			for(i=0;i<xCrypt.Length;i++)
			{
				if(nbOcc(xCrypt[i], xCrypt) > nbOcc(maxOcc, xCrypt) && nbOcc(xCrypt[i], chMaxOcc) == 0)
				{
					maxOcc = xCrypt[i];
				}
			}
			chMaxOcc += maxOcc;
			maxOcc = ' ';
		}
		return chMaxOcc;
		
	}

	public static string decryptageFrequence(string xLettreMax, string xCrypt)
	{
		int j = 0;
		int k = 0;
		int l = 0;
		char lettre;
		int nombre;
		int decalage = 0;
		int reste = 0;
		bool reponse = false;
		string chaine_decryptee = "";
		while(reponse == false)
		{
			decalage = xLettreMax[l] - 101;
			for(j=0;j<xCrypt.Length;j++)
			{
				nombre = xCrypt[j];
				for(k=0;k<decalage;k++)
				{
					nombre = nombre - 1;
					if(nombre < 97)
					{
						nombre = 122;
					}
				}
				chaine_decryptee += (char)(nombre);
			}
			Console.WriteLine("Proposition : " + chaine_decryptee);
			Console.WriteLine("Le message est-il compréhensible ? (O/N) \n");
			lettre = char.Parse(Console.ReadLine());
			if(lettre == 'O')
			{
				reponse = true;
			} 
			else
			{
				reponse = false;
				chaine_decryptee = chaine_decryptee.Remove(0,chaine_decryptee.Length);
			}
			l++;
		}
		return chaine_decryptee;
	}
}


	

