// Robot class

// Field for saving id

// Constructor with id as only parameter

// Functions for manipilating transform and rigidbody (mirror c# functions)
// in theese functions use function SendMessage('object name (= 'Robot[id]')', 'function name', 'value') where value only can be
// int, float, double, string and arrays of them (need to be tested).

// export Robot for import in Controller class


var Controller = {

	Init: function(id) {

		// Load script resource file with id as key

		// Save the recource

		// Create a robot usign provided id

		// Run the Init function with a robot object as only parameter
	}

	Run: function(id) {

		// Get the script recource using id as key

		// Run the Run method
	}

    Hello: function(robot)
    {
        window.alert(robot);
        console.log(robot);
        SendMessage('Cube','test','')
    }
};

mergeInto(LibraryManager.library, Controller);