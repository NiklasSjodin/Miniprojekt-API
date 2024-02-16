![OIG3 v1uHAL3A](https://github.com/NiklasSjodin/Miniprojekt-API/assets/146171251/15b0ed0e-811d-4302-b069-e61d3ef0b865)

# Mini Project API

## Application

- [ ] Store individuals with basic information such as first and last names, and phone numbers.
- [ ] Capability to store multiple interests per person with a title and a short description.
- [ ] Link each person to any number of interests.
- [ ] Store multiple links to websites for each interest, associated with both the person and the interest.

## Create a REST API

**API Requests:**

- [ ] Retrieve all individuals in the system.
- [ ] Retrieve interests and links associated with a specific person.
- [ ] Connect a person to a new interest and add new links.
## GET Requests
- "/persons" - Get all persons in the db.
- "/person/{personId}" - Get all the information about a specific person.
- "person/{personId}/interests" - Get all the specifik persons interests
- "person/{personId}/interests/url - Get all the connected links from the person

## POST Requests
- "/person" - Add a new person to the db.
- "/person/interest" - Add a new interest to the db.
- "/person/{personId}/interest/{interestId}" - Connect a person to an interest
- "person/{personId}/interest/{interestId}/url" - Add a new link to a specific person and interest.

## Class diagram
![Skärmbild 2024-01-07 104434](https://github.com/NiklasSjodin/Miniprojekt-API/assets/146171251/3ae58c04-922d-4c4d-9a20-37c9160df539)
## ER-diagram
![Skärmbild 2024-01-07 112822](https://github.com/NiklasSjodin/Miniprojekt-API/assets/146171251/655ba93b-5464-4c25-a880-9fe3f64a7e82)
