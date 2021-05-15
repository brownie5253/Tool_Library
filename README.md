# Tool_Library
This is a project to create a functioning tool libary system for an organisation to keep track of the tools and members in the system.
It has a login for both staff (user: staff password:today123) and members who can log in after a staff member has added them into the data base which is a Binary search tree.

As a member you can view existing tools which is broken up by 9 tool cateriries, each categry containing multiple tool types. These tool types are an object called tool_collection which contain many individual tool objects. After deciding on a tool the user can both borrow and return tool however they can only hold a maximum of 3 tools. They can check the list of tools they are currently borrowing at any time. The final feture they have avalible is to check the top 3 most borrowed tools in the system which employs a merge sort algorithm to implement this.

For staff the functions avalible are adding new or existing tool pieces, removing pieces of tool, adding and removing members and finding the contact number of a member by searching through the binary search tree to find a matching member.

This project uses OOP heavily as it has many classes which are derived from interfaces. The system has many objects with tool objects housed within multiple toolcollection objects and member objects all housed within the member_ collection BST object. The advatage of that for each of these objects the multiude of functions avalible in their classes can be called on easily.

To run just execute the Program.cs file, no arguments needed
