# _Hair Salon Website_

#### _A website to store Stylist and Client data, 12/7/2018_

#### By _**Alex Williams**_

## Description

_This website allows the user to input Stylists into the website, and then adding clients to that stylist. In addition, the user may view each stylist and client and see their respective stylists(if the user chose a client), and the respective clients(if the user chose a stylist). The user may also delete Stylists and Clients from the database._

## Specs

1. User can add Stylists, Clients and Specialities to the database.
2. User should then be able to add the clients as a many to one relationship within the database, allowing for the Client to be paired with a Stylist.
3. The User can add many specialities to a stylist, and many stylists to one speciality as a many to many relationship.
4. User can then view Singular/All Clients, Singular/All Stylists, and Singular/All Specialities.
5. Clients and Stylists can both be deleted. When deleting a Stylist, the corresponding Clients will also be deleted automatically.

## Setup/Installation Requirements
Download .NET Core 2.1.3 SDK and .NET Core Runtime 2.0.9 and install them. 

1. Clone this repository:

    * $git clone https://github.com/Zizzs/HairSalon.Solution
2. Setup the Database. Either import the database files given OR create your own database using the following SQL Commands:
    * > CREATE DATABASE hair_salon;
    * > USE hair_salon;
    * > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
    * > CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;
    * > CREATE TABLE specialities (id serial PRIMARY KEY, speciality VARCHAR(255));
    * > CREATE TABLE specialities_stylists (id serial PRIMARY KEY, speciality_id INT, stylist_id INT;

    * > CREATE DATABASE hair_salon_test;
    * > USE hair_salon_test;
    * > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
    * > CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255)), stylist_id INT;
    * > CREATE TABLE specialities (id serial PRIMARY KEY, speciality VARCHAR(255));
    * > CREATE TABLE specialities_stylists (id serial PRIMARY KEY, speciality_id INT, stylist_id INT;
3. Change into the work directory:
    * $cd HairSalon.Solution
4. Open the project in your preferred text editor to modify the files.
5. To run the program, navigate to HairSalon.Solution/HairSalon and use $dotnet build to build the project, and then $dotnet run to start the server that the project will be held.
6. Navigate to localhost:5000 in your browser to view the splashpage.

_This application requires MAMP or a similar server program. Myphpadmin is optional but recommended to manage the database. The database name should be called alex_williams, and the test database should be called alex_williams_test, but these can be changed in the HairSalon.Tests/ModelTests/HairSalonTests.cs and HairSalon/Startup.cs files if you choose to change the database name._

## Known Bugs

_No Known Bugs_

## Support and contact details

_If you have any questions, or suggestions, please email me at Zizzs17@gmail.com or visit my Github repository at https://github.com/Zizzs_

## Technologies Used

_C#, HTML, CSS, .NET, MAMP, and MyPhpAdmin_

### License

*MIT License*

Copyright (c) 2018 **_Alex Williams_**