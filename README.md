# RegistryJump
Provides an easy-to-use GUI for jumping directly to a specific hive inside the Windows Registry.

![Main Window](https://github.com/sokooltools/registryjump/images/image1.png?raw=true "This is the main window.")
### Options
RegistryJump.exe can also be called directly from the command line.

<p>For example:</p>
<p style="Font-family:courier; Font-size:.75em;">&nbsp;"full\path\to\RegistryJump.exe" "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"</p>
<p>or</p>
<p style="Font-family:courier; Font-size:.75em;">&nbsp;"full\path\to\RegistryJump.exe" "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"</p>
<p>or</p>
<p style="Font-family:courier; Font-size:.75em;">&nbsp;"full\path\to\RegistryJump.exe" "[HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders]"</p>

<hr/>
<div>RegistryJump.exe</div>
<div>Author : Ronn A. Sokol</div>
<div>Company: SokoolTools</div>
<div>History: Initial Release March 1, 2006</div>
<hr/>
   
   
This application allows you to quickly jump directly to a node in the registry using 1 of 3 methods:

 1. Entering a registry key directly in the GUI (i.e., by launching the executable).
 2. Selecting the key from up to 20 previously visited "recent" keys from the combobox in the GUI.
 3. Passing in the registry key as a parameter to the executable in commandline mode.

HOW TO USE:

If RegistryJump.exe is missing, open this solution and build the assembly. 

The executable (assembly) will automatically be placed into the following directory:

	"C:\Program Files (x86)\DevTools\RegistryJump"


Create a shortcut to the exe on your desktop if you'd like:

	"%ProgramFiles(x86)%\DevTools\RegistryJump\RegistryJump.exe"
	
	Launch the exe or double-click the shortcut to open the GUI.
	
	Enter or paste a registry key into the combobox and then click the "OK" button.
	
	(You can optionally click the "Browse..." button to open the registry to the key that was last opened manually or by RegistryJump.)
	
	
Create a shortcut to jump to a particular registry hive by simply passing a parameter to RegistryJump:

	For example: "C:\Program Files (x86)\DevTools\RegistryJump\RegistryJump.exe" "HKEY_LOCAL_MACHINE\SOFTWARE\ACCESSNET"
	
	(Now double-click the shortcut and you will be taken directly to that hive in the registry!)


SPECIAL NOTES:

To make it easier to use - enclosing 'spaces', 'double-quotes', 'square brackets' and 'backslashes' 
are automatically trimmed from the string as well as whitespace surrounding the internal "\"s.

	For example, all these work the same:

		"HKEY_LOCAL_MACHINE\SOFTWARE\ACCESSNET  ] "
	or
		[HKEY_LOCAL_MACHINE \ SOFTWARE\ ACCESSNET\]
	or
		[HKEY_LOCAL_MACHINE\SOFTWARE\ACCESSNET]
		
	
You can specify the registry root key using any of the registry shortcuts (HKCR, HKCU, HKLM, HKU, HKCC) as well.
																					  
	For example:																	 
																					   
		"HKLM\SOFTWARE\ACCESSNET"													    
	can be used in place of: 
		"HKEY_LOCAL_MACHINE\SOFTWARE\ACCESSNET"
		
Anytime you launch RegistryJump (command line or via the GUI), the 20 most recent registry keys visited are recorded and displayed in the combobox.

You can easily delete individual recent items by dropping down the combobox using the <ALT> <Arrow> keys and then pressing the deleteKey on the keyboard.
Of course you can delete all the recent items by simply deleting the "RegistryJump.recent" file located in the executable's directory.

ADDING REGISTRY JUMP SHORTCUT TO YOUR APPLICATIONS

Note that in all cases below when there isn't any text selected in the respective UI, the RegistryJump.exe (UI) will be launched instead.

*** Internet Explorer ******************************************************************

	You can also add a right-click context menu shortcut to IE by following these steps:
	
	1) Double-click the file "registryjump.reg" to automatically update the registry.
	   (Note that you first have to edit the .reg file if you placed registryjump.exe in a folder other than the default)
	
	2) To test in IE, simply select any registry key 'text' found on any page.
	
	3) Right-click the mouse and choose the menuitem "Open key with RegistryJump".
	
	Note: You can easily test this operation by opening the included file "registryjump.test.htm" using your browser.

*** Visual Studio ******************************************************************

	1) Open Visual Studio.
	
	2) Select "External Tools..." from the "Tools" menu in the main menubar.
	
	3) Click the "Add" button on the "External Tools" dialog.
	
	4) Enter "Registy &Jump" into the "Title" textbox.
	
	5) Enter "C:\Program Files (x86)\DevTools\RegistryJump\RegistryJump.exe" into the "Command" textbox
	   or browse to it by clicking the "..." button to its right.
	   
	6) Enter "$(CurText)" into the "Arguments" textbox.
	
	7) Click the "OK" button on the "External Tools" dialog. 


*** TextPad ******************************************************************

	To jump right to the registry key from the text you have selected within TextPad, simply add RegistryJump
	as a 'Tool' within TextPad as described here: 

	1) Open TextPad.

	2) Select the "Preferences..." menuitem from the "Configure" menu on the menubar.

	3) Click the "Tools" node within the treeview on the left of the Preferences dialog.

	4) Click the "Add" dropdown combo on the upper right and select "Program..."

	5) Navigate to and select "RegistryJump.exe" from the "C:\Program Files (x86)\DevTools\RegistryJump\" folder.

	6) Click the "Apply" button on the Preferences dialog.

	7) Expand the "Tools" node in the treeview and select 'RegistryJump'.

	8) Change the word '$File' in the "Parameters:" textbox to '$Sel'

	9) Press the "OK" button.

	From here on out all you need to do is select the text corresponding to the registry key within TextPad 
	    and then select the "RegistryJump" menuitem from the Tools menu and you're off!

*** NotePad++ ******************************************************************
