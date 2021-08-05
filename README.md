# Pokedex

These are the instructions on how to run the API and unit tests. You'll need Visual Studio or Visual Studio Code installed. This assumes the repository has been cloned to a folder named **pokedex**

**Visual Studio Code**
- Click on `File > Open Folder...`
- Select the **pokedex** folder
- To run the API: Press **F5**
- To run the unit tests: Run the `dotnet test` command using the terminal 

**Visual Studio 2019**
- Click on `File > Open > project/Solution...`
- Select **Pokedex.sln** in the **pokedex** folder
- To run the API: Press **F5**
- To run the unit tests: Click on `Test > Run All Tests`

---

**Example requests to test the API**
- http://localhost:5000/pokemon/mewtwo
- http://localhost:5000/pokemon/translated/mewtwo

---

**Things I would add if this was a production API**
- Error logging
- Returning more meaningful statuses/error messages than just 404 NOT FOUND if some other error occurs (specifically with the external requests)
- A caching mechanism
- Rate limiting
