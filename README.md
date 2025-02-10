# Assignment 1

1. 📝 **Worth:**   6% 

2. 📅 **Due:** February 21, @Midnight

3. 🕑 **Late submissions:** 10% penalty per late day. Maximum of 3 late days allowed.

4. 📥 **Submission:** Upload your `.py` files on [Gradescope](https://www.gradescope.ca/courses/24982)

### ⚠️ Important Notes:

-  ✅ Collaboration is encouraged, but your work must be completed and submitted independently 
-  🚫 The use of generative AI to solve the assignment will be flagged as plagiarism.
-  📚 This assignment should be completed using only the concepts seen in class. 

### 📝 Instructions:

1. Extract the compressed folder and save its content to a secure location on your computer for instance, your course folder `Programming > Assignment1` saved on OneDrive.
2. Open the parent folder `Programming` in PyCharm as usual and start coding.
3. Use the starter files provided **WITHOUT** renaming them.
4. All `.py` files have a multi-line comment at the top that you should complete with your name, section, etc.
5. Any variable or constant set with a fixed value should be defined at the beginning, for example:

```python
"""
Author: ...
Date: ...
...
"""
import math

# Define constants 
GRAVITAION = 9.81    # m/s2

# Define variables 
position_x = 34     # m
position_y = 23     # m

# Calculate other variables...
```


## 🎯 Learning Objectives

- Develop Python scripts using the PyCharm IDE.

- Identify and correct errors in Python code.

- Solve simple arithmetic and logic problems using Python. 

- Declare and use Python variables while following naming conventions.

- Choose the appropriate numeric data types & arithmetic operators based on the problem.

- Utilize the `math` module to perform mathematical operations.

---

### Question 1: Fix Errors 🛠️

Fix the code in the starter file `fix_mistakes.py` so that it behaves the way it ought to (the way the program ought to work is defined in the code).

### Question 2: OMA's 👵🥮

You own a bakery which makes [OMA'S BOTERKOEK](https://www.food.com/recipe/omas-boterkoek-dutch-buttercake-132488) (Grandma's butter-cake)

* You can only buy butter in 1kg containers.

* You can only buy brown sugar in 25kg bags

* You can only buy eggs in 5 dozen containers

* You can only buy flour in 25kg bags

* You can only buy almond extract in 5kg bottles.
* You can only buy baking powder in 1kg bags

Currently, you have no ingredients in stock.

The recipe for one cake is:

* 160 g butter
* 240g brown sugar
* 7.5g almond extract
* 1egg
* 355g flour
* 2.5g baking powder 

 Add comments in the code to keep track of the units of measurements for each variable.

Write a script which uses the number of cakes needed and:

* Calculates how many containers of each ingredient you need to buy
* Prints those values:


**Example**:

```text
To make 100 butter cakes, you need to buy:
16 containers of butter
1 bags of sugar
1 bottle of almond extract
2 cartons of eggs
2 bags of flour
1 containers of baking powder
```

> To ensure your code works, change the values of the variables in the code see if your calculation works properly.  Do this again and again until you are satisfied that your code works for any values

___





### Question 3:  Jac Hacks 🐱‍💻

The Computer Science department is organizing this year's Hackathon and needs your help with some logistics. They are currently assigning workspaces for each team participating in the hackathon. There are workspaces of various sizes:

- Large - accommodates 4 teams 
- Medium - accommodates 2 teams
- Small  - accommodates 1 team 

To optimize space usage, the organizers want to minimize the number of partially filled workspaces. For example if there are 11  teams, they should be assigned 2 large spaces, 1 medium space and 1 small. But if there are 12 teams, they should use 3 large spaces.


If the number of participants doesn't divide evenly by the team size, assume that some teams will have extra members, but no additional team will be formed.

Given the total number of registered participants `num_participants` and the number of participants per team `team_size`, your script must:

- Calculate the number of teams formed
- Calculate the number of large, medium and small workspaces required.
- Print the number of participants, the team size
- Print the number of teams
- Print the number of large, medium and small workspaces


**Output Example**

```text
Num participants:  123
Team size:  3
Total number of teams:  41
Large workspace(s):  10
Medium workspace(s):  0
Small workspace(s):  1
```

> To ensure your code works, change the values of the variables in the code see if your calculation works properly.  Do this again and again until you are satisfied that your code works for any values

___

### Question 4: JAC Parking 🚘

John Abbott College needs your help in estimating the number of parking decals that will be sold this semester for both staff and students. The script should be designed to be as flexible as possible for reuse in future semesters.

For Winter 2025, there are 8,000 full-time students enrolled in the day division, with 2% expected to drive and park at the college. The estimated teacher-to-student ratio is 1:30, among all teachers 65% commute by car.Additionally, there are 378 full-time staff members, 80% of whom drive to work. Since these values may change each semester, the script should be adaptable. 

The John Abbott campus has a fixed number of parking spaces: 

- **346** spots reserved for staff
- **555** designated for students

> This excludes disabled parking, carpooling reserved parking, which can be ignored in this problem. 

Write a script which:

- Determines the number of student and staff parking decals to be sold.
- Computes the occupancy rate (in %) for both the student and staff parking lots (including teachers and staff).
- Rounds up to whole values using the `round()` function
- Prints all decimal values with a precision of 2.

**Example of output**

```text
|----Decals to sell ---|
| Student     |  160  |
| Teacher     |  173  |
| Staff       |  302  |
```

```text
|----Occupancy Rate (%)------|
| Student parking |   28.83% |
| Staff parking   |  137.28% |
```

> To ensure your code works, change the values of the variables in the code see if your calculation works properly.  Do this again and again until you are satisfied that your code works for any values

___

## Rubric

| Criteria   | Expectation                                                  | Points |
| ---------- | ------------------------------------------------------------ | ------ |
| Logic      | Correct translation of a word problem into logical steps to accomplished the required task. The logic must be as generalized as possible, avoiding the use of magical values and hardcoded strings. | 1.5    |
| Variables  | Proper use of variables to break down a problem. Use of meaningful variable names when possible. | 1      |
| Comments   | Proper use of comments to explain the logic of a program. All files contain a header with the student's information and a brief description of the script. | 0.5    |
| Data Types | Proper understanding of numeric data types and correct use of conversion functions. | 1      |
| Operators  | Proper understanding and correct use of arithmetic operators. | 1      |

> The ponderation of each criteria may change for each problem. 
