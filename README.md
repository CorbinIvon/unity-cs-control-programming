# unity-cs-control-programming
Enables the users to interface with in-game objects like a control programmer might.

# The Vision
The user is able to manually access in-game objects of type `ControlObject` and manipulate them in a way that a control programmer might. This includes setting the value of a `ControlObject` and reading the value of a `ControlObject`. Other scripts can extend the functionality of `ControlObject` to include more complex behaviors.
We should be able to use something like the Reflection Utility to pull public attributes directly from the `ControlObject` during runtime and display them to the player. The user should also have the option to modify these values during runtime.
This should also work in tandem with the `ProgrammableControllerManager.cs` and the `ProgrammableController.cs` scripts. The `ProgrammableControllerManager.cs` should be able to access the `ControlObject` and modify it during runtime. The `ProgrammableController.cs` should be able to store custom code to interface with the `ControlObject` and modify it during runtime.