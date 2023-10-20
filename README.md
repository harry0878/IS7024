
# YumSafe  
Design Document By:  

Das, Harimohan  

Huang, Qinghua  

Pokuri, Navya  

Menoky, Roneena  

Chunchu, Hima Sri  

## Introduction  

Welcome to **YumSafe**, your go-to site for staying informed about food safety and restaurant inspection data in your area.  

Hungry for knowledge about the cleanliness and safety of your favorite eateries? Craving the latest restaurant inspection reports? You've come to the right place!  

On **YumSafe** you can,  

- Search for a particular restaurant and their inspection ratings
- Get the list of top-rated restaurants in the area
- Look for restaurant ratings by specific area

  
Explore the world of food safety, access the latest inspection results, and make informed choices for your next dining adventure. **YumSafe** is here to satisfy your craving for reliable restaurant information.  

Hungry for more? Just ask!

## Data Feeds  

- https://datasf.org/opendata/
- https://data.cityofchicago.org/Health-Human-Services/Food-Inspections/4ijn-s7e5
- https://www.dallasopendata.com/Services/Restaurant-and-Food-Establishment-Inspections-Octo/dri5-wcct
- https://data.cincinnati-oh.gov/Thriving-Neighborhoods/Cincinnati-Food-Safety-Program/rg6p-b3h3

## Functional Requirements  

### Requirement 100.0: Restaurant Information Retrieval  

#### Scenario  

As a user, I want to be able to search for specific restaurants and retrieve detailed information about their inspections, violations, and ratings.  

#### Dependencies  

Data feeds from Cincinnati.gov are available and accessible.  

#### Assumptions  

Data provided by Cincinnati.gov is regularly updated and accurate.  

#### Examples  

1.1  

**Given** a feed of restaurant inspection data is available  
**When** I search for the restaurant "ABC Grill"  
**Then** I should receive detailed information about inspections, violations, and ratings for "ABC Grill".  

1.2  

**Given** a feed of restaurant inspection data is available  
**When** I search for the restaurant "XYZ Cafe"  
**Then** I should receive detailed information about inspections, violations, and ratings for "XYZ Cafe".

1.3  

**Given** a feed of restaurant inspection data is available  
**When** I search for a non-existent restaurant "Random Restaurant"  
**Then** I should receive zero results (an empty list).  

### Requirement 101: Filtering Data Based on User-Specified Criteria  

#### Scenario  

As a user, I want the ability to filter restaurant inspection data based on specific criteria, such as location, cuisine type, inspection ratings, and violation categories. This feature will enable me to find restaurants that meet my preferences and dietary requirements.  

#### Dependencies  

Data feeds from Cincinnati.gov are available and accessible.  

#### Assumptions  

Data provided by Cincinnati.gov includes detailed information about restaurant locations, cuisine types, inspection ratings, and violation categories. 
 
#### Examples  

1.1  
**Given** a feed of restaurant inspection data is available  
**When** I search for restaurants in the "Downtown" area  
**Then** I should receive a list of restaurants located in the downtown area, including detailed inspection data for each restaurant.  

1.2  
**Given** a feed of restaurant inspection data is available  
**When** I filter restaurants by cuisine type and select "Italian"  
**Then** I should receive a list of Italian restaurants in Cincinnati, along with their inspection ratings and violation details.

1.3  
**Given** a feed of restaurant inspection data is available  
**When** I filter restaurants by inspection rating and choose "Excellent" (rating >= 90%)  
**Then** I should receive a list of restaurants in Cincinnati with excellent inspection ratings, along with their detailed inspection data.

1.4  
**Given** a feed of restaurant inspection data is available  
**When** I filter restaurants by violation category and select "Hygiene Violations"  
**Then** I should receive a list of restaurants in Cincinnati that have been cited for hygiene violations, along with the specific violations and inspection details.  

## Roles  
Frontend Developer: Harimohan Das, Roneena Menoky, Quinghua Huang  
Integration Developer: Hima Sri Chunchu, Navya Pokuri, Harimohan Das

## Weekly Meeting  
Friday at 4:30 PM at Lindner



