# 🎾 Tennis Players API — Kata Technique .NET 9

## 📌 Présentation

Cette API a été développée comme démonstration de compétences backend en .NET 9. Elle expose des endpoints REST pour gérer des joueurs de tennis, avec une architecture moderne, testée et conteneurisée.

**Objectifs :**

- Mise en œuvre réaliste des bonnes pratiques de développement d’API
- Architecture propre et maintenable
- CI/CD et déploiement cloud-ready

**Principes clés :**

- 🧱 Architecture Clean (Clean Architecture)
- 🧭 Séparation des responsabilités (CQRS)
- 🧪 Tests unitaires & tests d’intégration automatisés
- 🐳 Conteneurisation Docker
- ☁️ Déploiement sur Azure App Service (image Docker depuis Docker Hub)

---

## 🔧 Stack Technique

- **.NET 9** — Minimal API
- **Swagger** — Documentation interactive
- **Serilog + Seq** — Logging structuré & visualisation
- **Clean Architecture**
- **CQRS + MediatR**
- **Result Pattern** — Gestion des succès/erreurs
- **In-memory caching** — JSON cache
- **Tests** — Unitaires (Domaine) & intégration (end-to-end, sans mocks)
- **Docker** — Conteneurisation
- **Azure App Service** — Déploiement en mode conteneur

---

## 📂 Structure du Projet

```bash
TennisPlayers/
│
├── DOCKER-COMPOSE.yml
├── Dockerfile
├── README.md
│
├── SRC/
│   ├── TennisPlayers.Presentation/      # API Minimal, Swagger, Serilog
│   ├── TennisPlayers.Application/       # Cas d’usage (CQRS), Result pattern
│   ├── TennisPlayers.Domain/            # Modèles métiers, gestion des erreurs
│   └── TennisPlayers.Infrastructure/    # Parsing JSON, cache mémoire
│
└── Tests/
    ├── TennisPlayers.IntegrationTests/  # Tests d’intégration end-to-end
    └── TennisPlayers.UnitTests/         # Tests unitaires (Domaine)
```

---

## 🚀 Récupération du Code

Le code source est disponible sur GitHub :  
🔗 [https://github.com/mohamedamjoud/TennisPlayers.git](https://github.com/mohamedamjoud/TennisPlayers.git)

```bash
git clone https://github.com/mohamedamjoud/TennisPlayers.git
```

---

## 🧪 Lancer les Tests

Pour exécuter les tests unitaires et d’intégration :

```bash
cd TennisPlayers
dotnet test Tests
```

---

## 🐳 Lancer l’Application avec Docker Compose

```bash
docker compose up
```

Accès local :

- 🌐 API : [http://localhost:5032](http://localhost:5032)
- 📚 Swagger : [http://localhost:5032/swagger/index.html](http://localhost:5032/swagger/index.html)
- 📊 Seq (logs) : [http://localhost:8081](http://localhost:8081)

---

## 🐳 Lancer avec l’image Docker Hub

```bash
docker run -d   --name tennis-api   -e ASPNETCORE_ENVIRONMENT=Development   -e ASPNETCORE_HTTP_PORTS=8080   -p 5032:8080   mohamedamjoud/tennis-players-api:latest
```

Accès local :

- 🌐 API : [http://localhost:5032](http://localhost:5032)
- 📚 Swagger : [http://localhost:5032/swagger/index.html](http://localhost:5032/swagger/index.html)
- 📊 Seq (logs) : [http://localhost:8081](http://localhost:8081)

---

## ☁️ API Déployée sur Azure

L’API est accessible sur Azure App Service (mode conteneur) :  
🔗 [https://players-api-gafdfcdua0ecbjak.francecentral-01.azurewebsites.net/swagger/index.html](https://players-api-gafdfcdua0ecbjak.francecentral-01.azurewebsites.net/swagger/index.html)