using System;

//Ce programme servira a décrypter un message crypté grace a un algorithme de décalage
//Auteur : Clément GEYER

class projet_final
{
	static void Main()
	{
		//Déclaration des variables
		int decalage = 0;
		int occurence = 0;
		int nbr = 0;
		int nbr2 = 0;
		int nbr3 = 0;
		char reponse = ' ';
		bool continuer = true;
		string lettre_max = "";
		string chaine_decryptee = "";
		string message = "";
		string harm = "";
		string crypt = "";
		string decrypt_brute = "";

		//Initalisation par l'utilisateur

		while(continuer == true)
		{
			Console.WriteLine("Que voulez-vous faire ? (1: Crypter un message; 2: Décrypter façon brute; 3: Décrypter par fréquence.");
			nbr = int.Parse(Console.ReadLine());
			if(nbr == 1)
			{
				Console.WriteLine("Quel est votre message ?");
				message = Console.ReadLine();
				Console.WriteLine("Quel est le décalage souhaité ?");
				decalage = int.Parse(Console.ReadLine());
				harm = supprim_interdit(message);
				crypt = cryptage_chaine(harm, decalage);
				Console.WriteLine("Le message crypté est : " + crypt);
			}
			else if(nbr == 2)
			{
				Console.WriteLine("Le dernier message crypter est : " + crypt);
				Console.WriteLine("Voulez-vous tenter de le décrypter ? (1: OUI; 2: NON)");
				nbr2 = int.Parse(Console.ReadLine());
				while(nbr2 < 1 || nbr2 > 2)
				{
					if(nbr2 == 1)
					{
						harm = supprim_interdit(message);
						crypt = cryptage_chaine(harm, decalage);
						decrypt_brute = decryptage_brute(crypt);
					}
					else
					{
						Console.WriteLine("Aurevoir");
					}
				}
			}
			else if(nbr == 3)
			{
				Console.WriteLine("Le dernier message crypter est : " + crypt);
				Console.WriteLine("Voulez-vous tenter de le décrypter ? (1: OUI; 2: NON)");
				nbr3 = int.Parse(Console.ReadLine());
				while(nbr3 < 1 || nbr3 > 2)
				{
					if(nbr3 == 1)
					{
						harm = supprim_interdit(message);
						crypt = cryptage_chaine(harm, decalage);
						lettre_max = lettreMax(crypt);
						chaine_decryptee = decryptageFrequence(lettre_max, crypt);
					}
					else
					{
						Console.WriteLine("Aurevoir");
					}
				}
			}
			else
			{
				Console.WriteLine("Fonction introuvable, veuillez recommencer.");
			}
			Console.WriteLine("Voulez-vous continuer ? (O/N)");
			reponse = char.Parse(Console.ReadLine());
			if(reponse == 'N')
			{
				continuer = false;
				Console.WriteLine("Aurevoir");
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
			Console.WriteLine(decryptage);
			Console.WriteLine("Le message est-il compréhensible ? (O/N)");
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
		Console.WriteLine("La chaine max est : " + chMaxOcc);
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
			Console.WriteLine(chaine_decryptee);
			Console.WriteLine("compréhensible ?");
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


	

