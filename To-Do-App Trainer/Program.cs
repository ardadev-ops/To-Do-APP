
// This function takes no parameters and returns nothing.
// It simply prints a menu to the console.
static void PrintMenu()
{
    Console.WriteLine("===============================");
    Console.WriteLine("Awesome Todo App v0.1");
    Console.WriteLine("1. Add a todo");
    Console.WriteLine("2. List todos");
    Console.WriteLine("3. Remove a todo");
    Console.WriteLine("4. Exit");
}

// Function to add a new Todo to the list passed via the parameter
static void AddTodo(List<String> todos)
{
    // Create a second list to be able to print newly created ToDo's at the
    // end of the function. This lives only for the duration of the function
    List<String> newTodos = new List<String>();

    // While loop to be able to add multiple todos
    while (true)
    {
        // Ask the user to add a new todo and wait for input
        Console.Write("New ToDo (X for exit): ");
        string newTodo = Console.ReadLine();

        // if the string read from the console is X or x, break the while loop
        if (newTodo.ToLower() == "x")
        {
            break;
        }

        // Add the new todo to the todos variable passed via the parameter
        todos.Add(newTodo);

        // ALSO add the new todo to the NewTodos list (to print it afterwards)
        newTodos.Add(newTodo);
    }

    // Print all newly added todos
    ListTodos(newTodos, true);
}

// Function to list all todos given as parameter
static void ListTodos(List<String> todos, bool newTodos)
{
    // print a different string to the console depending on the newTodos parameter.
    // If the function is called form main for all todos it should print "current todos"
    // If called from the AddTodo, it should print "new todos"
    if (newTodos == true)
    {
        Console.WriteLine("Here are all your new todos:");

    }
    else
    {
        Console.WriteLine("Here are all your current todos:");

    }

    // Iterate over all todos
    // 1. Initialize integer with 0
    // 2. Execute loop for as long as i is smaller than the size(length) of the list
    // 3. After executing the loop, increment the index i by 1
    for (int i = 0; i < todos.Count; i++)
    {
        // Print the number of the todo together with the todo itself
        Console.WriteLine($"{i}. {todos[i]}");
    }
}

static void DeleteTodo(List<String> todos)
{
    // First output all Todos
    ListTodos(todos, false);

    // Now let the user input all the indices to remove seperated by ","
    Console.Write("Which items (by index) you want to delete? (seperate by ',')");

    // After the ReadLine(), "line" now contains a single string
    // Example: "3,___1,___5_" (_ represent spaces)
    String line = Console.ReadLine();

    // We now split the line on every "," and put the results into an Array
    // Example: 3  ___1  ___5_
    String[] splitItems = line.Split(",");

    // We now create the list which will finally contain all the indices
    // of todos to be removed as int (empty after initialization)
    List<int> indices = new List<int>();

    // Iterate over all splitItems
    for (int i = 0; i < splitItems.Length; i++)
    {
        // Add to the indices int list:
        // 1. splitItems[i].Trim() makes "___5_" result in "5" by removing all white spaces
        // 2. Int32.Parse makes an "5" string a 5 int
        // 3. indices.Add adds the 5 to the list
        indices.Add(Int32.Parse(splitItems[i].Trim()));
    }

    // Now we sort all the indices
    // This is necessary when removing multiple items at once
    indices.Sort();

    // Iterating backwards over the indices (to remove) prevents
    // removing the wrong todos as after every delete at n, all elements
    // n+1 shift one to the left thus the indices afterwards would be invalid
    for (int i = indices.Count - 1; i >= 0; i--)
    {
        // Create a local variable which represents the index of the todo list we want to remove
        // Remember: indices is the list of indices of the todo list we want to remove
        // i is only the index pointing at indices pointing at todoIndex
        // Example: 
        // i -> indices -> todos
        // todos[1] = Wasabi
        // indices[0] = 1 
        // i = 0
        // todos[indices[i]] = Wasabi
        int todoIndex = indices[i];

        // Output the todo and its index
        Console.WriteLine($"Deleting element {todos[todoIndex]} at {todoIndex}");

        // Finally remove the todo at the correct index
        todos.RemoveAt(todoIndex);
    }

}

// Wait for user input and return it as an integer.
static int ReadChoice()
{
    Console.Write("Your choice: ");
    return Int32.Parse(Console.ReadLine());
}

// We create a list of string to represent our todos.
// A list is a collection of a certain type (between < and >).
// Thus it can contain any number of items of that type.
// For initializing a list, we use the `new` keyword followed by a () at the end.
List<String> todos = new List<String>();

// We define a variable "running" to control the main loop in the program
bool running = true;

// Main loop of the program. This runs as long as the variable "running" is true
// which will be the case until the user decides to exit the program.
while (running)
{
    // Step 1: Print the menu to the console
    PrintMenu();

    // Step 2: Read the users choice from the console
    int choice = ReadChoice();

    // Print an empty line before executing the sub program
    Console.WriteLine("");

    // Step 3: Handle the users choice
    switch (choice)
    {
        case 1:
            // Call the Sub-Program (Function) to add a new todo
            AddTodo(todos);
            break;
        case 2:
            // Call the Sub-Program (Function) to list all todos
            ListTodos(todos, false);
            break;
        case 3:
            // Call the Sub-Program (Function) to remove a todo
            DeleteTodo(todos);
            break;
        case 4:
            // Switch running to false which will end the main loop
            running = false;
            break;
        default:
            // Invalid number chosen - Print error message
            Console.WriteLine($"Invalid choice {choice}");
            break;
    }
    // Insert an empty line at the end of each iteration of the main loop
    Console.WriteLine("");
}


Console.WriteLine("Thanks for using our Software - Goodbye!");