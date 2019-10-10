using System;

//Ce programme servira a décrypter un message crypté grace a un algorithme de décalage
//Auteur : Clément GEYER

class projet_final
{
	static void Main()
	{
		//Déclaration et initialisation des variables
		int decalage = 0;
		int nbr = 0;
		char reponse = ' ';
		char utilisation = ' ';
		bool continuer = true;
		string msg_utilisateur = "";
		string lettre_max = "";
		string message = "";
		string harm = "";
		string crypt = "";

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
				harm = supprimInterdit(message);
				crypt = cryptageChaine(harm, decalage);
				//Puis on écris simplement le message
				Console.WriteLine("Le message crypté est : " + crypt + "\n");
			}
			//S'il veut décrypter de façon brute, le programme rentre dans cette condition
			else if(nbr == 2)
			{
				//Ensuite si l'utilisateur n'a crypter aucun message précédemment, le programme rentre dans cette condition
				if(message == "")
				{
					//Ici on demande a l'utilisateur de saisir le message qu'il veut décrypter ou de taper 'q' s'il n'a aucun message a décrypter
					Console.WriteLine("Veuillez saisir votre message crypté : (Tapez 'q' si vous n'en avez pas) \n");
					msg_utilisateur = Console.ReadLine();
					if(msg_utilisateur == "q")
					{
						//S'il appuie sur 'q', on sors de la condition
						Console.WriteLine("Aucun message crypté, veuillez réessayer." + "\n");
					}
					else
					{
						//S'il saisit son message on remplace la valeur du message crypté par le message que l'utilisateur nous a donné
						crypt = msg_utilisateur;
						Console.WriteLine("Le dernier message crypté est : " + crypt + "\n");
						decryptageBrute(crypt);
					}	
				}
				//Si l'utilisateur a précédemment crypté un message, il sera déjà enregistré dans le programme
				else
				{
					//On lui demande ensuite s'il veut utiliser ce message précédemment enregistré ou en décrypter un autre
					Console.WriteLine("Le dernier message crypter est : " + crypt);
					Console.WriteLine("Voulez-vous utiliser ce message ? \n");
					utilisation = char.Parse(Console.ReadLine());
					//S'il répond 'o' on execute simplement la fonction de décryptage brute
					if(utilisation == 'o')
					{
						decryptageBrute(crypt);
					}
					//Sinon on rentre dans cette condition
					else
					{
						//On demande donc quel message il veut décoder et on le rentre dans un string
						Console.WriteLine("Quel est votre message ? \n");
						message = Console.ReadLine();
						//On execute la fonction d'harmonisation au cas ou l'utilisateur se trompe dans l'insertion du message
						harm = supprimInterdit(message);
						Console.WriteLine("Le message crypté est : " + harm + "\n");
						//Puis on execute la fonction de décryptage
						decryptageBrute(harm);
					}
				}
			}
			//S'il veut décrypter un message par fréquence le programme rentre dans cette condition
			else if(nbr == 3)
			{
				//Ensuite si l'utilisateur n'a crypter aucun message précédemment, le programme rentre dans cette condition
				if(message == "")
				{
					//Ici on demande a l'utilisateur de saisir le message qu'il veut décrypter ou de taper 'q' s'il n'a aucun message a décrypter
					Console.WriteLine("Veuillez saisir votre message crypté : (Tapez 'q' si vous n'en avez pas) \n");
					msg_utilisateur = Console.ReadLine();
					if(msg_utilisateur == "q")
					{
						//S'il appuie sur 'q', on sors de la condition
						Console.WriteLine("Aucun message crypté, veuillez réessayer." + "\n");
					}
					else
					{
						//S'il saisit son message on remplace la valeur du message crypté par le message que l'utilisateur nous a donné et on l'affiche
						crypt = msg_utilisateur;
						Console.WriteLine("Le dernier message crypté est : " + crypt + "\n");
						//Puis on execute les 2 fonctions permettant de faire fonctionner le décryptage fréquence et tout se passera dans la fonction
						lettre_max = occurenceLettreMax(crypt);
						decryptageFrequence(lettre_max, crypt);
					}	
				}
				//Si l'utilisateur a précédemment crypté un message, il sera déjà enregistré dans le programme
				else
				{
					//On lui demande donc s'il veut utiliser le message pré-enregistré ou non
					Console.WriteLine("Le dernier message crypter est : " + crypt + "\n");
					Console.WriteLine("Voulez-vous utiliser ce message ? (o/n) \n");
					utilisation = char.Parse(Console.ReadLine());
					//S'il répond 'o' on execute les fonctions de décryptage fréquence
					if(utilisation == 'o')
					{
						lettre_max = occurenceLettreMax(crypt);
						decryptageFrequence(lettre_max, crypt);
					}
					//Sinon on rentre dans cette condition
					else
					{
						//On demande donc a l'utilisateur le message qu'il veut décoder et on l'insère dans une variable
						Console.WriteLine("Quel est votre message ? \n");
						message = Console.ReadLine();
						//On harmonise la chaîne au cas ou l'utilisateur se trompe
						harm = supprimInterdit(message);
						Console.WriteLine("Le message crypté est : " + harm + "\n");
						//Puis on execute les fonctions de décryptage par fréquence
						lettre_max = occurenceLettreMax(harm);
						decryptageFrequence(lettre_max, harm);
					}
				}	
			}
			//S'il saisit autre chose que 1, 2 ou 3 on lui renvoie un message d'erreur
			else
			{
				Console.WriteLine("Fonction introuvable, veuillez recommencer. \n");
			}
			//Ensuite on demande a l'utilisateur s'il veut continuer ou non de rester dans le programme
			Console.WriteLine("Voulez-vous continuer ? (o/n) \n");
			reponse = char.Parse(Console.ReadLine());
			//S'il repond N on sors du programme, sinon on recommence
			if(reponse == 'n')
			{
				continuer = false;
				Console.WriteLine("Aurevoir \n");
			}
		}
	}


	/*
		supprimInterdit : fonction : string
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
	public static string supprimInterdit(string xMessage)
	{
		//Déclaration des variables
		int i;
		int caractere;
		int longeur;
		string nvl_chaine = "";

		//On prend le nombre de caractères de la chaîne
		longeur = xMessage.Length;

		//Ensuite on effectue une boucle 'for' afin de traiter la chaîne caractère par caractère
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
		cryptageChaine : fonction : string
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
	public static string cryptageChaine(string xHarm, int xDecalage)
	{
		//Déclaration des variables
		int j;
		int k;
		int decalage = 1;
		int nombre;
		string chaine_cryptee = "";

		//On utilise une boucle 'for' afin de traiter caractère par caractère
		for(j=0;j<xHarm.Length;j++)
		{
			nombre = xHarm[j];
			//Si on entre un décalage négatif, le programme rentre dans cette condition
			if(xDecalage < 0)
			{
				//Ici k ira de 0 jusqu'au décalage en enlevant 1 a chaque tour
				for(k=0;k>xDecalage;k--)
				{
					nombre = nombre - decalage;
					//Et si le nombre descend sous le nombre de caractère ASCII de 'a' on remet 'z'
					if(nombre < 97)
					{
						nombre = 122;
					}
				}
			}
			//Si le décalage est positif, le programme rentre dans cette condition
			else
			{
				//Ici k ira de 0 jusqu'au décalage en ajoutant 1 a chaque tour
				for(k=0;k<xDecalage;k++)
				{
					nombre = nombre + decalage;
					//Si le nombre monte plus haut que le nombre du caractère ASCII 'z', on remet 'a'
					if(nombre > 122)
					{
						nombre = 97;
					}
				}
			}
			//Puis on ajoute chaque caractère a la nouvelle chaîne
			chaine_cryptee += (char)(nombre);
		}
		//Puis on retourne la valeur
		return chaine_cryptee;
	}




	/*
		decryptageBrute : fonction : string
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
	public static string decryptageBrute(string xCrypt)
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
			Console.WriteLine("Proposition : " + decryptage);
			Console.WriteLine("Le message est-il compréhensible ? (o/n) \n");
			rep_utilisateur = Console.ReadLine();

			//Si le message est compréhensible on utilise la condition 'if' ci-dessous pour faire passer le booleen en 'true' et sortir
			// de la boucle 'while'
			if(rep_utilisateur == "o")
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
		//Ensuite on retourne la valeur
		return decryptage;
	}



	/*
		nbOcc : fonction : int
		Cette fonction sert a donner le nombre d'occurence d'un caractère dans une chaîne, la fonction sera utilisé dans la
		  fonction de calcul des occurences de chacunes des lettres
		Paramètres :
			xCrypt : string
			xCaractere : char
		Local :
			m : int
			nombre_occurence : int
		Retour :
			nombre_occurence : int
	*/
	public static int nbOcc(char xCaractere, string xCrypt)
	{
		//Déclaration des variables
		int m;
		int nombre_occurence = 0;

		//Cette boucle 'for' sert a parcourir le message crypté en le traitant caractère par caractère
		for(m=0;m<xCrypt.Length;m++)
		{
			//Ici si le caractère de la chaîne cryptée est égale au caractère défini on entre dans la condition
			if(xCrypt[m] == xCaractere)
			{
				//Puis on incrémente la valeur 'nombre_occurence'
				nombre_occurence++;
			}
		}
		//On retourne le nombre d'occurences de la lettre en question
		return nombre_occurence;
	}



	/*
		occurenceLettreMax : fonction : string
		Cette fonction sert a renvoyer une chaîne de caractères ou seront inscrit les lettres avec le maximum d'occurence
		  dans l'ordre
		Paramètres :
			xCrypt : string
		Local :
			n : int
			maxOCC : char
			chMaxOcc : string
		Retour :
			chMaxOcc : string
	*/

	public static string occurenceLettreMax(string xCrypt)
	{
		//Déclaration des variables
		int n = 0;
		char maxOcc = ' ';
		string chMaxOcc = "";

		//Ici tant que la longeur de la chaîne des caractères avec le maximum d'occurence est inférieure ou égale à la longeur
		//de la chaîne cryptée on reste dans la boucle
		while(chMaxOcc.Length <= xCrypt.Length)
		{
			//Avec cette boucle 'for', on parcours la chaîne cryptée
			for(n=0;n<xCrypt.Length;n++)
			{
				//Ici si le nombre d'occurences du caractère de la chaîne cryptée est plus grand que celui du max d'occurence par rapport
				//à la chaîne cryptée et que le caractère n'est pas présent dans la chaîne 'chMaxOcc' on rentre dans la condition
				if(nbOcc(xCrypt[n], xCrypt) > nbOcc(maxOcc, xCrypt) && nbOcc(xCrypt[n], chMaxOcc) == 0)
				{
					//Ensuite on prend le caractère et on l'extrait dans une variable char
					maxOcc = xCrypt[n];
				}
			}
			//A chaque tour on ajoute la valeur du maximum d'occurence dans la chaîne
			chMaxOcc += maxOcc;
			//Et on réinitialise le caractère du maximum d'occurence
			maxOcc = ' ';
		}
		//On finit par retourner la chaîne de caractères avec le maximum d'occurences
		return chMaxOcc;
	}




	/*
		decryptageFrequence : fonction : string
		Cette fonction sert a décrypter une chaîne de caractères par fréquence grâce à une fonction qui cherche le nombre
		  d'occurences de chaque lettres
		Paramètres :
			xCrypt : string
			xLettreMax : string
		Local :
			o : int
			p : int
			q : int
			nombre : int
			decalage : int
			lettre : char
			reponse : bool
			chaine_decryptee : string
		Retour :
			chaine_decryptee : string
	*/
	public static string decryptageFrequence(string xLettreMax, string xCrypt)
	{
		//Déclaration des variables
		int o = 0;
		int p = 0;
		int q = 0;
		int nombre;
		int variable;
		int decalage = 0;
		char lettre;
		bool reponse = false;
		string chaine_decryptee = "";

		//Ici tant que l'utilisateur ne comprend pas le résultat on reste dans la boucle 'while'
		while(reponse == false)
		{
			//Le décalage sert a savoir ou est positionnée le caractère par rapport a 'e' dans l'alphabet
			decalage = xLettreMax[q] - 101;
			//La boucle 'for' sert à parcourir la chaîne cryptée
			for(o=0;o<xCrypt.Length;o++)
			{
				//Ici on prend la valeur ASCII du caractère
				nombre = xCrypt[o];
				//Ici on va gérer le cas dans lequel le décalage serait négatif donc que la lettre avec le nombre d'occurences maximum
				//aie une valeur en dessous de 'e'
				if(decalage < 0)
				{
					//Ici on prend donc la valeur absolue du décalage
					variable = Math.Abs(decalage);
					//Puis dans cette boucle 'for' on calculera le nombre d'incrémentation nécessaires 
					for(p=0;p<variable;p++)
					{
						//On ajoute 1 au la valeur ASCII a chaque tour
						nombre = nombre + 1;
						//Et si la valeur ASCII dépasse 122, on retourne a 97
						if(nombre > 122)
						{
							nombre = 97;
						}
					}
				}
				//Sinon on traite le décalage normalement
				else
				{
					//Dans cette boucle 'for' on calculera le nombre de décrémentation nécessaires
					for(p=0;p<decalage;p++)
					{
						//On enlève 1 au la valeur ASCII a chaque tour
						nombre = nombre - 1;
						//Et si le nombre passe en dessous de la valeur ASCII pour 'a'
						if(nombre < 97)
						{
							//On remplace sa valeur par celle du caractère 'z'
							nombre = 122;
						}
					}
				//Ensuite on change a nouveau la valeur ASCII en char et on ajoute la caractère a la nouvelle chaîne
				}
				chaine_decryptee += (char)(nombre);
			}
			//Ensuite on demande a l'utilisateur si le message est compréhensible ou pas et on récupere la valeur qu'il nous envoie
			Console.WriteLine("Proposition : " + chaine_decryptee);
			Console.WriteLine("Le message est-il compréhensible ? (o/n) \n");
			lettre = char.Parse(Console.ReadLine());
			//Si l'utilisateur répond 'O' qui veut dire OUI, on passe le booléen a 'true', qui nous fait sortir de la boucle 'while'
			if(lettre == 'o')
			{
				reponse = true;
			}
			//Sinon le booléen reste a 'false'
			else
			{
				reponse = false;
				//Et on réinitialise la chaîne pour reprendre dès le début
				chaine_decryptee = chaine_decryptee.Remove(0,chaine_decryptee.Length);
			}
			//A la fin de la boucle on incrémente la valeur de 'q' qui servira a passer au 2eme caractère de la chaîne d'occurence de
			//caractères et ainsi tester une option différente
			q++;
			if(q >= xLettreMax.Length)
			{
				Console.WriteLine("Vous avez dû manquer le résultat, les propositions vont recommencer");
				q = 0;
			}
		}
		//On retourne la chaîne décryptée
		return chaine_decryptee;
	}
}


	

