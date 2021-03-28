# Sports Management (For Football Lovers)

- [x] Sports Management is a Restful API application, which will be used by team managers to manage their team.

- [x] Implemented using .Net Core 5.0 Web Api.

- [x] Follows clean code architecture with CQRS pattern and Mediator design pattern. 

- [x] Secured by JWT token based authentication.
  
- [x] Basic unit tests are implemented using XUnit and Moq.

- [x] In-memory data store which maintains list of managers, players, teams and fixtures.

- [x] Supports a bunch of endpoints like Create, Read, Update and Delete.

### TO RUN THE APPLICATION, 

>1. PULL THE REPOSITORY
>
>2. RUN THE 'SportsManagement.API' PROJECT
>
>3. LANDING PAGE IS SWAGGER UI, WHICH WILL LIST ALL THE ENDPOINTS
>
>4. ALL THE ENDPOINTS ARE SECURED WHICH CAN ONLY BE ACCESSED USING VALID JWT TOKEN
>
>5. LOGIN USING '/api/auth' USING USERNAME = 'ole' AND PASSWORD = 'ole' [USERNAME AND PASSWORD IS FIRST NAME OF MANAGERS IN LOWER CASE]
>
>6. GRAB THE JWT TOKEN FROM THE RESPONSE OF '/api/auth'
>
>7. SEND THE JWT TOKEN AS 'Authorization: Bearer {TOKEN}' FOR ALL THE CONSECUTIVE REQUESTS
