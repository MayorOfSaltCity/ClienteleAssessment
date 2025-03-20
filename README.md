# C# Assessment

This repository contains solutions to the tasks outlined in the assessment. Below are the instructions on how to run and validate each task. The tasks involve writing C# code to solve different problems using threading, database CRUD operations with Entity Framework, and consuming a REST API.

## Table of Contents

1. [Task 1: Multithreading Factorial Calculation](#task-1-multithreading-factorial-calculation)
2. [Task 2: CRUD Operations with Entity Framework](#task-2-crud-operations-with-entity-framework)
3. [Task 3: Consuming Public REST API (Weather Application)](#task-3-consuming-public-rest-api-weather-application)

---

## Task 1: Multithreading Factorial Calculation

### Overview:
This task involves creating a C# program that uses multiple threads to calculate the factorial of different numbers concurrently. The solution ensures thread safety and proper synchronization when dealing with shared resources.

### Features:
- Utilizes **multiple threads** to calculate the factorial of different numbers.
- Ensures **thread safety** and **proper synchronization** using locking mechanisms (e.g., `lock` keyword, `Monitor`).
- Handles concurrent processing efficiently.

### Instructions to Validate:
1. **Unit Tests**: Unit tests are included to verify the correctness of the factorial calculations.
   - To run the unit tests:
     - Open the solution in **Visual Studio**.
     - Run the tests using **Test Explorer** or via the **dotnet CLI**:
       ```bash
       dotnet test
       ```

2. **Console Application**: The console application is provided to demonstrate the multithreading behavior. To run it:
   - Navigate to the project directory.
   - Execute the program using:
     ```bash
     dotnet run
     ```
   - The console will output the factorial results for multiple numbers calculated concurrently.

---

## Task 2: CRUD Operations with Entity Framework

### Overview:
This task involves creating a C# application that connects to an SQLite database using **Entity Framework**. It implements basic **CRUD** (Create, Read, Update, Delete) operations for a **Customer** entity with properties like **CustomerID**, **Name**, **Email**, and **PhoneNumber**.

### Features:
- **Create** a new customer record.
- **Read** a customer's information.
- **Update** customer details.
- **Delete** a customer record.
- **Entity Framework Core** is used for database interaction.
- **SQLite** is used as the database.

### Instructions to Validate:
1. **Database Setup**:
   - Ensure that the **SQLite** database is properly set up.
   - The application will automatically create the SQLite database if it doesn't already exist when you run the application for the first time.
   
2. To run the application and test CRUD operations:
   - Open the solution in **Visual Studio**.
   - Run the application (press **F5** or use **dotnet run** from the terminal).
   - The console application will interact with the SQLite database and perform CRUD operations based on user input.

---

## Task 3: Consuming Public REST API (Weather Application)

### Overview:
This task involves writing a C# console application that consumes a **public REST API** (e.g., **OpenWeatherMap API**) to fetch the current weather information for a given city. The application displays the weather data on the console.

### Features:
- Consumes a **public REST API** (OpenWeatherMap).
- Fetches **current weather data** for a specified city.
- Displays data such as temperature, weather description, humidity, etc.

### Instructions to Validate:
1. **API Key**: To use the **OpenWeatherMap API**, you must obtain a free API key. You can get it [here](https://openweathermap.org/api).
   - Replace `your_api_key` in the application with the actual API key.

2. **Running the Application**:
   - Open the solution in **Visual Studio** or use the **dotnet CLI**.
   - Execute the program using the following command:
     ```bash
     dotnet run
     ```
   - The application will prompt for a city name. Enter a valid city (e.g., "London") and it will display the current weather data.
   
3. **Expected Output**: The console will show:
   - Temperature (in Kelvin, Celsius, or Fahrenheit depending on your configuration).
   - Weather description (e.g., "clear sky", "cloudy").
   - Humidity, wind speed, and other weather-related information.

---

## Additional Information

### Dependencies:
- **Task 1**: No external dependencies, uses basic C# threading constructs.
- **Task 2**: **Entity Framework Core** for database operations with **SQLite**.
- **Task 3**: **HttpClient** to call the OpenWeatherMap API.

### Requirements:
- .NET Core SDK 5.0 or higher.
- Visual Studio or any other IDE that supports .NET Core development.
- For Task 2 (CRUD operations), make sure that you have access to an SQLite database.
- For Task 3, you will need a valid **API key** from **OpenWeatherMap** to fetch weather data.

---

## Conclusion

This repository contains solutions to the assessment tasks, providing multithreading functionality, CRUD operations with Entity Framework, and consuming a REST API for a weather application. The provided instructions will help you validate and run each task effectively. Feel free to reach out with any questions or issues!
