# Tennis

Getting Started
Clone the repository: git clone https://github.com/Will3y/Tennis.git
Navigate to the project directory: "cd tennis"
Restore the project dependencies: "dotnet restore"
Run the application: "dotnet run"

API Endpoints

Get All Players
Retrieves all players sorted from the best to the worst player.

HTTP Method: GET
Endpoint: "/players"
Example : https://localhost:5001/players

Get Player By ID
Retrieves a player by their ID.

HTTP Method: GET
Endpoint: "/players/{id}"
Example : https://localhost:5001/players/1

Get Statistics
 - Retrieves the following statistics:
 - Country with the highest ratio of matches won
 - Average BMI of all players
 - Median height of all players

HTTP Method: GET
Endpoint: "/stats"
Example : https://localhost:5001/stats


This project includes unit tests. To run the tests, execute the following command bash : "dotnet test"
