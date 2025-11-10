# API Mail Service

## Introduction
In this API the user can send and find mail that is stored in the database. 
We can also delete mail sent and stored the in the database. The same goes for users.
With this API we can do CRUD operations on both the users and mail that is stored in the
database.

## Installation

### Database setup
To run this application you will need to ensure
you have PostgreSQL downloaded onto your machine with a database setup through localhost.
The PostgreSQL Database will need a couple tables set up. One table for the user and
one for the mail that we will be running CRUD operations on.

The table structure you will need to build this database on is as follows:

User (id, username, email, password)

Mail (id, from_email, to_email, subject, body, time_sent)

An example of this can be found in this sql file, [JavaDBSetup.sql](JavaDBOblig_oppsett.sql).

The example sql setup file can be used to demonstrate the API's functions as it contains
the entire database setup and test data. Just run the file in PostgreSQL and you are good to go.

### Dependencies
Before running the application, make sure to have the right dependencies installed. The project already comes with
a pre-configured pom.xml file, but sometimes these may have updated versions. The pom.xml file attached to this project
contains these dependencies:

            <dependencies>
                <dependency>
                    <groupId>org.springframework.boot</groupId>
                    <artifactId>spring-boot-starter-web</artifactId>
                </dependency>
                <dependency>
                    <groupId>org.springframework.boot</groupId>
                    <artifactId>spring-boot-starter</artifactId>
                </dependency>
                <dependency>
                    <groupId>org.springframework.boot</groupId>
                    <artifactId>spring-boot-starter-test</artifactId>
                    <scope>test</scope>
                </dependency>
                <dependency>
                    <groupId>org.springframework.boot</groupId>
                    <artifactId>spring-boot-starter-data-jpa</artifactId>
                </dependency>
                <dependency>
                    <groupId>org.postgresql</groupId>
                    <artifactId>postgresql</artifactId>
                    <scope>runtime</scope>
                </dependency>
                <dependency>
                    <groupId>org.springdoc</groupId>
                    <artifactId>springdoc-openapi-starter-webmvc-ui</artifactId>
                    <version>2.3.0</version>
                </dependency>
                <dependency>
                    <groupId>org.projectlombok</groupId>
                    <artifactId>lombok</artifactId>
                </dependency>
            </dependencies>

### Running the API
The API project code is already finished and can be run by clicking the "Run" button in your top right corner.

### Using Swagger (OpenAPI)
Once you have successfully started the application and no problems have occurred, you can now move over
to Swagger (OpenAPI) to test out the APIs different endpoints.

If you are running this in a local environment, you can go to 
Swagger-UI [(http://localhost:8080/swagger-ui/index.html#/)](http://localhost:8080/swagger-ui/index.html#/)
to test out the endpoints.

If you are running this from an external server, makes sure to use the appropriate link with the right IP address.

## How to use

Once the API has been booted up, we can start performing CRUD operations on the application.
First off, we can talk about how we perform these actions on the User table and what parameters
you should send to through the API.

The Get methods used in the /api/user mapping is a method for getting all the users stored in our database, listed up 
with specific information. The information you can expect when running a Get request through our API is the 
users ID, username, email and password. The Get method used in the API is useful for finding information about the users
of the mail server system.

We also have a POST methods for each of the User and Mail controllers. These allow us to create new users and send new mail
that will be stored in the PostgreSQL database. You don't need to fill out all the fields to save a new user or create a
new mail, but the ID created for the user and mail will be automatically created once the user saves execute the action
of the POST method.

Next is the PUT method. For each of the controller classes the Put method lets us change the
already created Users and Mail. You can change most of the information, but not the ID. If you do not enter the right ID,
the program may overwrite another user or mail if the ID exists, but if the ID does not exist, it will not overwrite anything,
and you will receive an error.

Lastly we have a DELETE method for each of the controllers that simply allows us to delete any user or mail from the 
server. We can delete a record from the database by simply typing the ID of that record, and it will be deleted. If it
does not exist it will give you an error telling you why the record could not be deleted.

#### All the different endpoints that are for the User controller class are listed and functions as follows:

- @GetMapping("/{id}") which returns that specific user based on their ID.
- @GetMapping without an ID retrieves a list of all the users of the system. 
- @PostMapping will add another user to the system. There is only one Post method in this API for the user controller. 
- @PutMapping changes the users information, except for the ID. There is only one Put method for the user controller. 
- @DeleteMapping("/{id}") will delete the user specified by ID. There is only one Delete method for the user controller. 
- @GetMapping("/domain/{domain}") retrieves all the users with a specific domain name like for example "example.com".

#### Now for the endpoints of the Mail controller class. They are listed and functions as follows:

- @GetMapping("/{id}") retrieves mail based on its ID.
- @GetMapping retrieves all mail stored in the database.
- @GetMapping("/from/{from}") returns all mail from said user. Example "alice@example.com" will give you all mail from alice. 
- @GetMapping("/to/{to}") returns all mail sent to a specific user. 
- @PostMapping allows us to create new mail. 
- @PutMapping allows us to change mail already sent. 
- @DeleteMapping("/{id}") removes a mail record from the database with that specific ID. 
- @GetMapping("/dto") is a data transfer object used to send and retrieve objects of data to and from the database. When
we create a request towards a database to retrieve many records, a dto allows us to retrieve a lot of data on a single
request, rather than a single request for each record we want to send or retrieve. 
- @GetMapping("/domain/{domain}") lets us retrieve all mail where the sender has for example "example.com" as their domain. 
- @GetMapping("/search") allows us to search for mails containing a certain subject or certain content. If alice@example.com
has sent a mail with the subject "Regarding Project Progress", we can then search for the word "project" and retrieve all
mail containing that word in the subject field. If nothing is written in either of the two fields, all mails will be retrieved.

## Troubleshooting

In case you run into any errors, here is a list of the most common error codes and how to potentially fix or
torubleshoot these:

### Status code: 200 (Ok)
- The action was executed successfully.

### Status code 500 (Internal Error) 
Refers to an error in the code or database, often as a result of invalid data that
does not match the server-side datastructures. When we get the 500 status code, we should assure ourselves that the code
and database are operating on the same tables and columns. Check for naming mismatches.

Sometimes we might see the message in the terminal read out “Column missing” or something similar.
This may refer to a column name not being written exactly the same way on either the server side of things or in the code.
Sometimes the table name can be written differently or not exist at all, and you will get the same error.

The best way to troubleshoot this status code is to go over the API code and database table setup and look for 
mismatches in table and column names.