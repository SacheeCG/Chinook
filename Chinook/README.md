# Chinook

This application is unfinished. Please complete below tasks. Spend max 2 hours.
We would like to have a short written explanation of the changes you made.

1. Move data retrieval methods to separate class / classes (use dependency injection)
2. Favorite / unfavorite tracks. An automatic playlist should be created named "My favorite tracks"
3. The user's playlists should be listed in the left navbar. If a playlist is added (or modified), this should reflect in the left navbar (NavMenu.razor). Preferrably, the left menu should be refreshed without a full page reload.
4. Add tracks to a playlist (existing or new one). The dialog is already created but not yet finished.
5. Search for artist name

When creating a user account, you will see this:
"This app does not currently have a real email sender registered, see these docs for how to configure a real email sender. Normally this would be emailed: Click here to confirm your account."
After you click 'Click here to confirm your account' you should be able to login.

Please put the code in Github. Please put the original code (our code) in the master branch, put your code in a separate branch, and make a pull request to the master branch.


# Comments

1.  I have refactored the data retrieval methods into a service class that inherits from a base service class for the code reusability and modularity by centralizing common functionality in the base service class and extending it in the derived service class.
	2. I have added exception handlings in major functionalities. (need to improve with proper messages and adding logs)
	3. It would be better if I was able to implement the unit tests for the main functionalities, since there are common methods using by the different components.