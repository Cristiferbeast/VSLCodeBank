# Encrer Visual Novel and 2D Dialogue System
The Goals of Encrer is to allow people with limited to no programming knowledge to utalize the simple Inky language to make an entire VN or Dialogue System without any programming

## Inky Basics
Inky is a Markup Language Designed for Use in making Dialogue Trees, its basics are explained in this video. It is extremely simple to work with.
https://youtu.be/s57nf2-OZ6g 

## Inky Dialogue System 8
Inky Dialogue System 8 is the root branch of this project, written by Trever Mock this provided a simple way to connect the core functionality of Inky into Unity
https://github.com/trevermock/ink-dialogue-system 

## Encrer 2D Dialogue System
Encrer 2D is currently on Version 1.0, this version is a pure fork of the original Dialogue System 8 just reduced for easier install and set up into other Unity Projects. 
The changes in this are minimal due to Dialogue System 8 being built for handling this. However it has recieved minor changes allowing for easier set up.

## Encrer VN
The VN varient of Encrer is far further from the original branch, being far more custom created as System 8 was designed for 2D games not for VNs. To build this the base System example was rebuilt into the Encrer VN System.

### Encrer VN v1.0
The first update Encrer has versus System 8 is that it supports up to 6 options as opposed to System 8s, 3 option limit. Encrer also sports a smaller text size which lets it have longer dialogue, this is different from System 8 which prioritizes short dialogue.
Encrer VN also added a new Font tag this being used to change the size of font. 
Encrer VN has a specified method built for controlling the background of a scene. This method can be added to a Inky project using 
    EXTERNAL background(string)
    ~background("rock")
This will let one provide a string to the background command to have it change the background.
Encrer VN also added a similar function to the handling of the portrait tag, replacing the existing handling that existed via System 8. This functionality grants higher freedom and easier access for beginner programmers in changing the portrait without using any code or animation loops.
Encrer also added another External for handling the portrait, giving users the ability to fully disable it should they want from Inky.
    EXTERNAL showportrait(bool)
    ~showportrait(true)
