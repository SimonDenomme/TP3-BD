# Cas d'utilisations

<!-- !!!À OUVRIR AVEC VISUAL STUDIO CODE!!! -->

<!-- 1. Clic droit sur le fichier -->
<!-- 2. Ouvrir l'aperçu -->

```plantuml
left to right direction

:Administrateur système: as admin

rectangle "WCF" {
	admin --> (InscrireParticipants)
	admin --> (InscrireMembresCO)
	admin --> (InscrirePaiement)
}
rectangle "Code First" {
	admin --> (InscrireMembresCP)
	admin --> (InscrireArticleSoumis)
	admin --> (AssignerArticles)
	admin --> (EnregisterNotesEvaluation)
	admin --> (RapportArticleEnOrdreDeNote)
	admin --> (ProduireProgramme)
	admin --> (InscrireVersionRévisée)
}

```

```plantuml
hide circles
hide methods

rectangle "Abstraction" {
	class "Participant" as p {
		Id: Integer
		Prenom: String
		Nom: String
		Email: String
		Affiliation: String
		DateDeCréation: Date
		Frais: Real
	}

	class "Membre du comité organisationnel" as mco {
		Id: Integer
		CodeUtilisateur: String
		MotDePasse: String
		Role: String
	}

	class "Membre du comité programme" as mcp {
    	Id: Integer
  	}

	class "Conférence" as c {
	}
	
	class "Article" as a {
		Id: Integer
		Titre: String
		DateSoumis: Date
		URL: String
		Version: Integer
	}

	class "Note" as n {
		Id: Integer
		Pointage: Integer
		ArticleId: Integer
		MembreCoId: Integer
	}


	c "1" o-- "*" a
	c "1" o-- "*" p

	mco -> p
	mcp -> p

	a "1" o-- "*" n
	a "*" o-- "*" p
}

```