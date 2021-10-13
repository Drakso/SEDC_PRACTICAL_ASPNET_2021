# OpenSource Ideas App

## Phase 1
* Create an architecture for an ASP.NET Core MVC app for posting anonymous ideas. The architecture can be any architecture that you choose
* An IDEA in the app should contain:
  * Id
  * Title
  * Description
  * UniqueCode
  * DateCreated
* Create only the folders, projects and domain classes only
* **BONUS**: Add it on GitHub

## Phase 2
* Create a database connection using Entity Framework
* Setup context with Dependency Injection
* Add repository for the IDEA model
* Check to see if a database is created by creating migration and updating the database
> Remember: You need to install the neccecary nugets

> Note: If you are using localDB like I did, open the Server Explorer and add the "(localdb)\MSSQLLocalDB" as a server to find your database

## Phase 3
* CReate a service layer for the IDEA entity that uses the repositories to:
  * Add
  * Remove
  * Update
  * Delete 
* Implement mapping ( Any way you see fit. EX: Automapper, your own mapper etc )
* Register all services, repositories and context with Dependency Injection

## Phase 4
* Crate a UI that allows a user to:
  * See all ideas
  * Delete an idea
  * Add a new idea

## Bonus tasks
* Implement users and connect ideas to users
  * Login and register page
  * No authentication yet, just login, register and redirecting to ideas page
* Implement validations
  * User can't leave any field empty for an idea
  * Dates should be atuomatically aded
  * Title should be longer than 3 characters
* Implement exception handling
  * Handling of planend exceptions such as failed validation
  * Handling of unplanned exceptions ( general exception )
  * Return error page
 * Implement logging in a file with some library
 * Implement some form of authentication of users
