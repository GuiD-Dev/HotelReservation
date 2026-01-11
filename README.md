# Hotel Reservation

Adapted from: https://github.com/Pablofr10/dotnet-challenges/blob/main/Desafios/reserva-hotel.md

## Scenario
The owner of a group of hotels would like to have a hotel management system built for his hotels. The hotels are located in the main cities and tourist attraction areas in Brazil. Employees are hired at each hotel to perform various functions. At each hotel, guests make reservations for the rooms of their choice and are charged according to the type of room they have booked. Given the above business scenario, create an application to manage reservations.


## Project Stack
- .NET 10
- Entity Framework
- PostgreSQL
- xUnit
- Angular 21


## Functionalities

### CRUD Hotel
- Must contains: address
- Not allow deactivate on update record. Create and specific endpoint to deactivate the hotel. 
### CRUD Hotel Room
- Must contains: number, kind, last cleaning
- Room kinds can be: single room, double room, twin room and suite 
### CRUD Employee
- Must contains: name, code, document, birth day, function
- When delete employee just fill the column deletion_date with now date and filter employees with this field null
### CRUD Customer
- Must contains: name, document, email, phone
- When delete customer just fill the column deletion_date with now date and filter customer with this field null
### CRUD Reservation
- Must contains: number, customer that made reservation, has parking pass, checkin date, checkout date
- The reservation cannot be deleted but change status to canceled. Verify availability before to make reservation
### CRUD Payment
- Must contains: value, payment methods
- The customer can use more than one payment method