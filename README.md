# VSLCodeBank
A Collection of Methods and Programs Built for VSL Projects
VSL has created a custom code bank for use in Signalis, this code bank can help with using methods that are easier to reference then doing the command normally through C#.

TEXTURE FIND
This Method returns the texture of an object, and can be invoked with the following,

![image](https://user-images.githubusercontent.com/121412458/236696685-3a675375-7736-4a14-8156-b21aa63a3882.png)

The code by which the Method runs is the following. Resulting in a easier accessibility of the method for newer programmers, as well as reducing the number of lines required to write it from 3 to 1 which can help make large programs which use lots of texture calls run more efficiently. 

![image](https://user-images.githubusercontent.com/121412458/236696678-71056a43-d495-4258-941e-352cc74affe9.png)

TextureFind is used heavily within the SURS Database to write easier calls. If you are writing an add on for SURS from base please use the TextureFind Method to ensure compatibility and readability of your code.

SURS IMAGE CALL
SURSImageCall is a method where one can input a filename as a string and if that file exists within the SURS Library it will convert the file into a 2D Texture. This is the Method that SURS is based around and all SURS Extensions use. When writing a SURS Extension be sure to use this method to ensure compatibility and readability of your code.
It is written in a fairly simple matter, 

![image](https://user-images.githubusercontent.com/121412458/236696637-9ce936f2-44da-4a9c-bc5c-a482751b7ff7.png) 

It finds a file, creates a new 2DTexture, then loads that image file onto the 2DTexture, then returns the texture as the results of the method.

SUMA MODEL CALL
SUMA is a SURS Extensions that expands the concepts of SURS into being used for a model. This results in the ability for modders to port in new models that previously did not exist in the game 
SUMA features greater debugging then SURS thus why it is a heavier code. SUMAModelCall is the first iteration of SUMA and can be used to load a file into the game, this can be done by providing the  GameObject version of the method with the main file string, and then the string name of the file that is being loaded. Then after this version of the Method is complete it can be fed back into the MeshRenderer version to create a mesh for that model.

![image](https://user-images.githubusercontent.com/121412458/236696822-89812989-617b-4ea4-b028-36b3d7a0d99e.png)

