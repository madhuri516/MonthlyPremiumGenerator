MonthlyPremiumGenerator Application
-----------------------------------------------

Overview
---------

This UI application is a development project created solely for selection process of TAL client. It is a web form application created in .Net framework 4.7.2 using Asp.Net and C#. The application intends to create a user interface for end user which provides ability to choose various options from Occupation field and calculate and display the monthly premium as per selected and entered values. Below is a list of all the felds:
1. Name
2. Age
3. Date of Birth
4. Occupation
5. Death – Sum Insured
The change in the occupation dropdown field triggers the premium calculation.

The UI provides a below list of occupations:
Occupation   Rating
----------   -------------

Cleaner      Light Manual

Doctor       Professional

Author       White Collar

Farmer       Heavy Manual

Mechanic     Heavy Manual

Florist      Light Manual

Occupation Rating:
Rating         Factor
------------   -------
Professional   1.0

White Collar   1.25

Light Manual   1.50

Heavy Manual   1.75


Assumptions
------------
1. It has been assumed that a web form application needs to be created as per requirement. 

2. As per requirement, for any given individual the monthly premium is calculated using the below formula
Death Premium = (Death Cover amount * Occupation Rating Factor * Age) /1000 * 12

3. All input fields are mandatory. Errors show up in application only after selecting dropdown at the end to calculate and display premium.

4. Occupation Rating Factor is constant for each occupation and is hardcoded in the application.

Usage
------
To generate the monthly premium user needs to enter/select all the mandatory fields. On selecting occupation dropdown with appropriate occupation, the application calculates and displays the monthly premium on the screen. 

Roadmap
--------
This is just an initial simple working application. There are many areas of improvements in the application such as:
1. The UI features can be enhanced with more sophisticated controls.
2. The Occupation Rating Factor can be made dynamic instead of hardcoding in application.
3. Features(functions) can be decoupled to reduce dependency.








 