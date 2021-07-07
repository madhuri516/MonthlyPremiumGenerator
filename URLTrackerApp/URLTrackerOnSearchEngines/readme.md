**URL Tracker On Search Engines**

Overview
---------
This UI application is a development project created solely for selection process of Sympli client. It is a web application created in .Net framework 4.7.2 using .Net Core, MVC and C#. The application intends to create a user interface for end user which provides ability to calculate the position/rank of Sympli URL "www.sympli.com.au" on a search engine upon searching any keyword . Below is a list of all the fields in main form page:

Search Keyword - a textbox
Search URL - a readonly textbox
Search Engine - a single select dropdown list
Pull Rank - a submit button
Upon clicking submit button the application calculates the URL's position and number of URL appearances in search engine and displays the result in tabular format in another(URL Position Results) page.

There is a Back to URLPositionTracker Page link at the bottom which takes the user back to Main form page.

Assumptions
------------
1. It has been assumed that a web application needs to be created as per requirement.

2. As per requirement, the same company URL "www.sympli.com.au" is searched everytime so the search URL field has been hard coded and made read-only.

3. The position of URL is assumed to be returned in the form of string of integers.

4. The number of occurances of URL is assumed to be returned in the form of integer.

5. The application is supposed to return position of "0" as string if URL does not appear at all or doesnot appear in top 100 searches.

6. Since this is a part of assessment so database has not been used, so vaues are either hard-coded or taken from user through form fields.

Usage
-----
Clone the folder from Github repo. Go to URLTrackerApp\URLTrackerOnSearchEngines folder path and launch cmd prompt from there. Enter command "dotnet run" to run the application. 

To calculate the position and number of appearances of URL on any search engine the user needs to enter the serach keywords and select a search engine. On submitting the form by clicking Pull Results button, the application calculates and displays the required results in tabular format.

Roadmap
--------
- This is just an initial simple working application. There are many areas of improvements in the application such as:
- The UI features can be enhanced with more sophisticated controls.
- The URL can be taken from user instead of hard coding if URL is not always "www.sympli.com.au".
- The data entered in form and results obtained can be stored in database for storage, maintainence and comparison of data.
- Instead of a web application, if search keyword and search URL is constant or known always, then a normal console application can be built and put on a schedule to run daily and automatically send result in the form of notification via email or sms.

Resolution Ideas For Issues
----------------------------
Performance
-----------
Since in ideal scenario the application would be more complex and involve database and query management, either an ORM such as Entity Framework should be used for proper data management and handling as well as performnace improvement of data or proper performance tuning should be done with respect to queries and database. Performance can also be improved if linq queries are used to deal with complex data or loops

Availability and Reliability
----------------------------
To maintain high availability and reliability, DR scenario could be implemented where the application is deployed in multiple data centers as a failover component. Load Balancer could be implemented to maintain high load of requests
