# SampleWebApi
This is a sample web api with angular client app that adds a user's first and last name to the databse. Includes a swagger/UI for documentation and to try out the api endpoints.

The entry point to the project is WebUI (in the presentation layer), running that should launch the client appp in the browser: http://localhost

# Solution details

- Demo API: Includes the a simple Rest api and its components. Component structure as below:
	- Core, common and domain layer has the main business logic, any abstractions, interfaces and entities
	- Infrastructure has Persistence layer - we use SqlLite (InMemory Database for testing), also includes migrations
	- Presentation has WebUI - the entry point into this application which includes a simple client app that uses Angular
	- Includes swagger UI for documentation and some basic web api testing
- Test project contains some unit testing and integration testing for both data storage and WebUI
- Added some unit tests using Jasmine/Karma for the client app

## Pre-requisite to run the project 

- .Net Core 3.1 should be pre-installed
- Entity Framework 3.1.5
- MediatR (v8.0.1)
- Moq (v4.14.4)
- Shouldly (v3.0.2)
- Automapper (version 9.0.0)

# Important Notes on the API usage

- Post /User 
	- Adds the first name and last name of the given request to the user table.
