WeatherReport
This console app retrieves weather data from a Web API for the user-supplied location, then offers the user several options for displaying the available data, including:

*	Current conditions
*	14-day forecast
*	Previous 14-days of weather data
*	Email forecast to a user-provided email address
*	Change cities and get weather information for the new locale. 
*	Store last city used to a JSON file and defaults to that city on next run of the app

Program Requirements: 
*	This application requires an internet connection, since it uses data from a Web API
*	Uses Newtonsoft JSON, which will need to be installed to run the app

Code Louisville Requirements Featured:
*	You must create at least one class, then create at least one object of that class and populate it with data. You must use or display the data in your application.
	(multiple classes have been created and used. The WeatherReport object gets populated with data from the WebAPI, and the data gets displayed in the app an in email)

*	Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application.
	(Multiple functions/methods are used, several of which return values)

*	Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program
	(The app runs inside a master loop that generates the menu and allows the user to continue using the app until they decide to exit)
	
*	Connect to an external/3rd party API and read data into your app
	(connects via internet to the Visual Crossings weather web API and reads weather data into the app)

*	Visualize data in a graph, chart, or other visual representation of data
	(displays weather forecast / history in a table on screen, and in an HTML/CSS-formatted table in email)

*	Implement a regular expression (regex) to ensure a field either a phone number or an email address is always stored and displayed in the same format
	(regex is used to validate the format of the user's email address)

*	Read data from an external file, such as text, JSON, CSV, etc and use that data in your application
	(The last used city is saved to a JSON file. That file is read when the app starts and defaults to the city saved in the file)



