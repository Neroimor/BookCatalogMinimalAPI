# BookCatalogMinimalAPI

Простой C# Minimal API для управления каталогом книг с фильтрами запросов, хранением в памяти, Swagger‑документацией, юнит тестами и CI через GitHub Actions.

---

## Содержание

- [Возможности](#возможности)  
- [Требования](#требования)  
- [Быстрый старт](#быстрый‑старт)  
- [Структура проекта](#структура‑проекта)  
- [Запуск API](#запуск‑api)  
- [Запуск тестов](#запуск‑тестов)  
- [Docker](#docker)  
- [CI/CD](#cicd)  
- [Участие в разработке](#участие‑в‑разработке)  
- [Лицензия](#лицензия)

---

## Возможности

- CRUD‑эндпоинты для сущности `Book` (`POST`, `GET`, `PUT`, `DELETE`)  
- **Endpoint Filters**  
  - **ValidationFilter**: проверяет корректность модели `Book`  
  - **LoggingFilter**: логирует детали запроса через встроенный `ILogger`  
- Хранение в памяти через `ConcurrentDictionary<int, Book>`  
- Авто‑документация Swagger/OpenAPI  
- **Unit & Integration Tests** в проекте `TestAPI/`  
- **GitHub Actions** CI‑workflow в `.github/workflows/`  
- **Dockerfile** для контейнеризации  

---

## Требования

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download) или новее  
- Docker (опционально, для контейнеров)  

---

## Быстрый старт

1. **Клонировать репозиторий**  
   ```bash
   git clone https://github.com/Neroimor/BookCatalogMinimalAPI.git
   cd BookCatalogMinimalAPI
   git checkout development
```
2. **Сборка**
    
    ```bash
    dotnet build
    ```
    
3. **Запуск**
    
    ```bash
    cd BookCatalogAPI
    dotnet run
    ```
    
    - По умолчанию доступно на `https://localhost:5001`
        
    - Swagger UI: `https://localhost:5001/swagger`
        

---

## Структура проекта

```
.
├── .github/
│   └── workflows/           # GitHub Actions CI‑workflow
├── BookCatalogAPI/          # Основной проект Minimal API
│   ├── Filters/
│   │   ├── ValidationFilter.cs
│   │   └── LoggingFilter.cs
│   ├── Models/
│   │   ├── Book.cs
│   │   └── BookQuery.cs
│   ├── Services/
│   │   ├── IBookService.cs
│   │   └── BookService.cs
│   ├── Program.cs           # Регистрация DI и определение эндпоинтов
│   └── BookCatalogAPI.csproj
├── TestAPI/                 # xUnit‑проект с тестами
│   ├── BookServiceTests.cs  # Юнит‑тесты для IBookService
│   ├── EndpointTests.cs     # Интеграционные тесты через TestServer
│   └── TestAPI.csproj
├── Dockerfile               # Описание сборки контейнера
└── README.md                # Этот файл
```

---

## Запуск API

- **Swagger UI**  
    Перейдите по адресу `https://localhost:{PORT}/swagger` для просмотра и тестирования эндпоинтов.
    
- **Эндпоинты**
    
    |Метод|Маршрут|Описание|
    |---|---|---|
    |POST|`/books`|Создать новую книгу|
    |GET|`/books/{id}`|Получить книгу по её ID|
    |PUT|`/books/{id}`|Обновить данные книги по её ID|
    |DELETE|`/books/{id}`|Удалить книгу по её ID|
    

---

## Запуск тестов

Из корня решения выполните:

```bash
cd TestAPI
dotnet test
```

Все юнит‑ и интеграционные тесты запустятся и должны завершиться успешно.

---

## Docker

Соберите и запустите контейнер:

```bash
# Сборка образа
docker build -t bookcatalog-minimalapi .

# Запуск контейнера
docker run -d -p 5000:80 --name bookcatalog bookcatalog-minimalapi
```

Swagger будет доступен по адресу `http://localhost:5000/swagger`.

---

## CI/CD

GitHub Actions workflow (`.github/workflows/ci.yml`) запускается на каждый push и pull‑request в ветку `development`:

- Восстанавливает и собирает оба проекта
    
- Запускает `dotnet test` в `TestAPI/`
    
- Отправляет статус сборки в GitHub
    

Можно дополнить шагами по анализу покрытия, линтингу и т.д.

---

## Участие в разработке

1. Форкните репозиторий
    
2. Создайте ветку:
    
    ```bash
    git checkout -b feature/YourFeature
    ```
    
3. Внесите изменения и закоммитьте
    
4. Запушьте в ваш форк
    
5. Откройте Pull Request в ветку `development`
    

Пожалуйста, убедитесь, что все тесты проходят, и соблюдайте существующий стиль кода.

---

## Лицензия

Проект открыт по лицензии MIT. Подробнее в файле [LICENSE](https://chatgpt.com/c/LICENSE).

```
::contentReference[oaicite:0]{index=0}
```
