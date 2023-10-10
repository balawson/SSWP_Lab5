# SSWP_Lab5
### Dad Joke API

This repository contains the Project Files for Lab 5. The web API *https://icanhazdadjoke.com/* is a free web API that provides the ability to fetch random "dad jokes", search for "dad jokes", and even submit your own "dad jokes" in JSON or text. This project utilizes the API's ability to fetch random "dad jokes" by creating a console menu in C#. This menu will allow a user to build a list of their favorite jokes, firstly, the menu will display 3 menu options:<br>
**1. Display Random Dad Joke** (once option 1 is selected the user will be presented with a random dad joke, before returning to the menu selection after reading the joke, if the user wishes to "favorite" the joke they can input the letter "f" and then return to the menu)<br>
**2. Display Favorited Jokes** (once option 2 is selected the user will be presented with a list of all the jokes they have previously favorited)<br>
**3. Exit** (once option 3 is selected this will close the program)

### Issues

The main issue I encountered occured here, within the HttpClientService class:<br>

    public HttpClientService()
    {
        _httpClient_ = new HttpClient
        {
            BaseAddress = new Uri("https://icanhazdadjoke.com/")
        };

    }

When running the program, the API would respond with the html content and not the JSON that was needed. After reading the guide in more detail on *https://icanhazdadjoke.com/api*, I realized that default request headers must be added to specifically indicate that we only expect JSON content.<br>
Here are the headers as described in the guide:<br>

 Accepted Accept headers:
* text/html - HTML response (default response format)<br>
* application/json - JSON response<br>
* text/plain - Plain text response<br>

This program requires JSON, so by adding this line of code: _httpClient_.DefaultRequestHeaders.Add("Accept", "application/json");<br>
Like so, <br>

    public HttpClientService()
        {
            _httpClient_ = new HttpClient
            {
                BaseAddress = new Uri("https://icanhazdadjoke.com/")
            };
        
            _httpClient_.DefaultRequestHeaders.Add("Accept", "application/json");
        }

All requests will indicate that JSON content is expected.
