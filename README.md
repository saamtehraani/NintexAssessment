# Frontend Developer - Programming Task

## Description

The programming task is about creating a small application which simulates a flight search web application. The
application gets some input from the user, makes a web service call and displays result to the user.
In the application, you need to collect following information from the user:

## Built With

* Departure airport code: a three-character string. Characters can be any alphanumeric value and does not have to be a valid airport code. This field does not need to support auto complete or suggestion.
* Arrival airport code: a three-character string. Characters can be any alphanumeric value and does not have to be a valid airport code. This field does not need to support auto complete or suggestion.
* Departure date: a date only field.
* Return date: a date only field.

Collected information should then be submitted to the web service. The web service is a fake REST service which returns JSON. The web service will search for flights and sends down the simulated result as a collection of JSON objects. You need to list all flights and for each of them you need to display the following information:

* Airline logo
* Airline name
* Outbound flight duration
* Inbound flight duration
* Total amount in USD

Bonus: Implement search or filtering capability

### Important Notes:

* Please use the Angular framework to develop your web application.
* Show us your HTML and CSS skills. The application should look clean, intuitive, modern and beautiful.
* You are free to choose the layout and design your views as you prefer.
* Wherever possible, perform validation.
* Wherever possible, code must be unit tested and/or integration tested.
* Application should be developed assuming it will later be used for different languages and cultures.
* For submissions, please DO NOT host your code as public. You can however host it as private git repository if you prefer or send us via email

### Web service technical information:

* Web service url: http://nmflightapi.azurewebsites.net/api/flight
* Sample Request (Query String):

```
DepartureAirportCode = MEL
ArrivalAirportCode = LHR
DepartureDate = 2019-12-24T00:00:00+11:00
ReturnDate = 2020-01-03T00:00:00+11:00
```

Note: The service returns the same response irrespective of the query parameters
