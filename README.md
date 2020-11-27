# DTBug
DenseTurd's in game debugger


DTBug is a console for the game window in unity, allowing Debug.Logs, warnings, etc to be displayed over the game. 
Can be useful if screen real estate is tight like it is on my laptop; or debugging on target devices.
If not set up correctly unity will crash, hopefully I can work out why and have it revert to the default LogHandler to inform the user of the error instead.


Setup:

The default text used is text mesh pro, so youll need the text mesh pro package imported into your project, unless you set up a different text prefab.

If you want to use the scroll bar you'll need a canvas in your scene.

Drag the DTBug prefab into the heirarchy.

Nice job ;)

If you get issues check all the public fields in the prefabs and DTBug are assigned.


The components the DTBug uses (Formatter, Console) require simple interface implementation if you want to create something that suits your needs better.
