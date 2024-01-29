#Проект интернет-магазина с использованием технологий ASP.NET CORE / MVC, LINQ, HTML, CSS, JS, Bootstrap, MS SQL Server, Entity Framework

Это приложение разработано на базе ASP.NET Core Framework и состоит из двух основных частей: веб-приложения и базы данных. Оба компонента взаимодействуют с использованием Entity Framework (EF), который предоставляет доступ к данным. Классы и зависимости внедряются с помощью механизма внедрения зависимостей (DI).

База данных основана на Microsoft SQL Server 2022 и имеет два контекста: один для управления продуктами и заказами, а другой для управления авторизацией и регистрацией с помощью ASP.NET Identity.

Веб-приложение построено на шаблоне Model-View-Controller (MVC). Модели данных, используемые для взаимодействия с базой данных, сопоставляются с представлениями с помощью автомаппера. Для создания пользовательских интерфейсов используются Razor страницы и фреймворк Bootstrap. Приложение имеет административный и пользовательский интерфейс.

Администратор в приложении имеет права для добавления, удаления и изменения товаров, просмотра всех заказов и обновления их состояния, а также для управления пользователями, включая изменение адреса электронной почты, пароля и прав доступа. Пользователи имеют доступ к просмотру информации о товаре, поиску по названию, оформлению заказа, оставлению отзывов и добавлению товаров в избранное. Незарегистрированным пользователям не разрешается совершать покупки.

Для тестирования функциональности разных пользовательских ролей, можно использовать следующие данные: электронная почта администратора - "admin@example.com", пароль администратора - "Admin123456!".

В приложении использована библиотека Serilog для упрощения процесса отладки.

Вы можете запускать приложение с использованием своей IDE, например, Visual Studio или Visual Studio Code. Также можно использовать готовый образ на hub.docker.com - zoronbet/onlineshopwebapp. Или использовать готовый Docker-Compose файл ниже для создания контейнеров и запуска приложения в контейнеризованной среде. Перед использованием убедитесь, что верно установлен и настроен Docker.

docker-compose.yml
----------------------------------------------------------------------------------
version: '3.4'

services:

  onlineshopwebapp:
  
    container_name: online_shop_app_mvc
    
    image: zoronbet/onlineshopwebapp
    
    ports:
    
        - 80:80
        
        - 443:443
        
    depends_on:
    
        - mssqlserver
        
    restart: unless-stopped
    
    
  mssqlserver:
  
    container_name: online_shop_app_db
    
    image: mcr.microsoft.com/mssql/server:2022-latest
    
    environment:
    
        ACCEPT_EULA: "Y"
        
        MSSQL_SA_PASSWORD: "Strong!Passw0rd"
        
    restart: unless-stopped
