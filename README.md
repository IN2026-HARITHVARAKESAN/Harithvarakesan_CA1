## Todo List
The ToDoAPP is a utility to help its users keep track of their tasks and timelines. With this app, each individual user, who has a unique login, can store and view the tasks listed by them along with target date.

## Design :
### Models :
- User :
	- User Id (String)
	- Password (String)
	- Name (String)
- Task :
	- Id (String)
	- Heading (String)
	- Description (String)
	- Status (Enum)
		- Completed
		- Pending
		- NotYetStarted
	- TargetDate (DateTime)
	- Recurrence (Enum)
		- Daily
		- Monthly
		- Annually
	- UserId (String)

### Flow :
User Create Account -> Login -> Dashboard -> Menu -> CRUD Task -> View Upcoming Task -> Share Task

### Structure:
- Controller :
	- AccessManager (Login & SignUp operation)
	- TaskManager (CRUD operation)
		- Add New Task
		- Edit Exiting Task
		- Remove Existing Task
		- View Task (with filter option)
	- InputGetter
	- InputValidator 
	- Utility (Helper functions)
	- JsonHandler
- View :
	- MenuDisplay (Display menus that a user can perform and navigate to other other functions in Controller)
- DataBase :
	- User - Consist users list and details.
	- Task - Task details with user id as a foreign key.


### Functionalities :
- User Authentication
- Add New Task
- Edit Exiting Task
- Remove Existing Task
- View Task (with filter option)
- Stores datas in Json file