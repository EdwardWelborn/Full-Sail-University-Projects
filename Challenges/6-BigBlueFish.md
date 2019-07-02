###### *DVP1 - Coding Challenges*
---

# BigBlueFish
An array excercise that gathers information about a particular fish  

There are multiple ways to do this. Consider each and choose the most appropriate based on the needs of the application.

#### Your code should:
> * Create two arrays: colors and lengths (see below) 
> * Display a menu of colors for the user to select from
> * Validate each user input, requesting it again if necessary
> * Use a method to identify the biggest fish of that color
> * Display results to the user


**Note**: *This challenge should be self contained within its own 'BigBlueFish' class, making it neccessary only to call it from the menu. Doing so allows for flexibility within the larger application should updates need to be made in the future.* 

##### Colors Array (strings):
> * Contains twelve entries with at least four different colors
> * Must contain repeat colors
> 	* Example: { blue, blue, green, red, blue, yellow, ... }

##### Length Array (floats):
> * Contains twelve entries without repeating lengths
> * Not in ascending or descending order
> 	* Example: { 2.6, 18.2, 6.87, 9.2, 15, 1.7, ... }


##### Example:

```
  ___ _      ___ _          ___ _    _    
 | _ |_)__ _| _ ) |_  _ ___| __(_)__| |_  
 | _ \ / _` | _ \ | || / -_) _|| (_-< ' \ 
 |___/_\__, |___/_|\_,_\___|_| |_/__/_||_|
       |___/                              
======================================================================
======================================================================

Welcome to BigBlueFish:
Looking for the biggest fish matching a certain color?

Please select a color of fish...

	[1] Red
	[2] Blue
	[3] Yellow
	[4] Green	
	
Selection: _2

Woa! Looks like the biggest blue fish is 18.2 inches

======================================================================
Press any key to return to the main menu: _
```
---
### Extra Challenge (optional)
Finding the biggest fish is most impressive. Here's another idea that can really make this program shine...

> * Allow users to search for biggest OR smallest fish

---