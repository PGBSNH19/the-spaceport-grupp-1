# Project 3 - The spaceport

For the procedures used in this project see : [Procedures](Procedures.md)

For the documentation by the team see: [Documentation/readme.md](Documentation/readme.md)

# The spaceport

When traveling across space you once in a while need to take a break, and park you spaceship, you do that at a spaceport. The thing is just that spaceports are just like any parking lot on earth controlled by an evil parking company, the biggest of these is SpacePark!

## Your assignment

You are a developer team at SpacePark and your assignment is to develop an application which register parking's and close the sparceport when it's full (and open when there is room, and only for spaceships which fits in).

All parking's should be registered in a database, which is created using Entity Framework Core and code first. All queries to the database should be done using Entity Frameworks fluent API.

The twist to this is that this is an **exclusive** spaceport and ONLY famous space travelers which have been part of a Starwars movie can use the spaceport. The travlers should identify them self when arriving, be able to pay before they can leave the parking lot and get an invoice in the end. 

You can test if the user has been part of Starwars by using the Starwars Web API: [swapi.co](https://swapi.co/), you are not allowed to cache the data from the API, which mean that you will need to request the API each time you need to fetch data.

A recommendation (but no requirement) is to use the Nuget package [RestSharp](http://restsharp.org/). You will need to implement the classes to be used by the build-in ORM in RestSharp.

```c#
var client = new RestClient("https://swapi.co/api/");
var request = new RestRequest("people/", DataFormat.Json);
var peopleResponse = client.Get<Swreponse>(request);

Console.WriteLine(peopleResponse.Data.Count);
foreach (var p in peopleResponse.Data.Results)
{
    Console.WriteLine(p.Name);
}
```

The travlers only use starships which have been part of a Starwars movie (see the endpoint /starships). They should be able to select their starship on arrival in the application.

All request to the Starwars API should (unlike the example above) be made asynchronous. 

And remember to create unit tests, where possible.

## Given

Some files are given in this repository.

**Documentation**

The folder initially only contains one file called *readme.md*, this file is more or less empty.

In this folder should you place digital representations of all documentation you do. Screenshots, photos (of CRC cards, mindmaps, diagrams).

Please make a link and descriptive text in the *readme.md* using the [markdown](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet) notation:

```markdown
# Our train project
What we have done can be explained by this mindmap.
![Mindmap of spaceport](mindmap.jpg)
Bla bla bla bla
```

**Source**

The source folder is more or less empty, it just contains one file a Visual Studio solution file, called TheSpaceport.sln.

Please open this and add projects to it.