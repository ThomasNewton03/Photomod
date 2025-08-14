To download the Unity project:

For this project, ensure that you have Unity Engine downloaded on your device. Additionally, make sure that you have downloaded the Yaw VR configuration software which is available at https://www.yawvr.com/downloads.
To access the Unity project, go into the terminal on your device and navigate to the folder where you wish to store the project, and then paste the following command: git clone https://github.com/ThomasNewton03/Photomod.git. Then, go into Unity Hub and go to Add -> Add project from disk, find the folder named "Photomod", and select the folder named "YawVR" before opening the project. The project may take a few minutes to load in Unity.

To connect the project to the Yaw VR Yaw2 chair:

Connect the chair to the router via an ethernet cable. To turn on the chair, switch on the red switch located just above the ethernet port. Once the chair has been switched on, it should light up on the sides. To connect your device to the chair, you must first connect your device to the same WiFi network as the chair- the password is located on the router. Once your device is connected to the WiFi, go into Unity and click on the YawController component shown in the hierarchy on the left-hand side of the page. Then, in the inspector on the right-hand side, navigate the IP address and insert the chair's IP address which is 192.168.0.100. Ensure that the the udp client port is set to 50020 and the connect type is set to debug_connect_to_ip. Finally, open the Yaw VR application on your device. If the connection has been successful, the chair should appear under "found devices on network". Click on this to move forward.

To run the application:

Once your device has connected to the chair, you can run the application. To start the application click "Start" in the Yaw VR app, and then go into Unity and click the play button at the top of the screen. To pause the application click the play button in Unity again and the chair will stop rotating. Alternatively, if you've finished you can click "Stop" in the Yaw VR app and the chair will come to a halt. If you click "Start" again, the chair will return to its default position before running through the text file.




Program Description:

The YawRotation.cs script takes the standardRoute.txt file, which stores the chair's rotational data. Each line in this file contains the line number, the chair's rotational direction (left/right), the angle of orientation, the angular speed (deg/sec), and the wait duration time between each rotation. In the Start method, this file is read in and stored as a list so that each line can be randomised.

The randomisation of each route takes place in the Shuffle method, which randomises the order of the rotations sequentially by swapping each line with a random line in the file. To stop the program from randomising the ordering, the call to Shuffle() in line 20 can be commented out.

The Execute method on line 36 controls each rotation in the text file by isolating each of the individual parameters: lineNumber, direction, degrees, speed, and duration. The program controls the chair's rotation by using these parameters to control its direction and speed, whilst simultaneously comparing its current orientation with its target orientation (the degrees variable). Once it has reached its target orientation, the chair pauses for the duration of its wait time before executing the next rotation. To prevent the risk of the chair rotating too quickly, the function ensures that the speed is no greater than 50, otherwise it will set its speed to 10. To log each command, the LogFile method is called after each rotation; this method writes each rotation into the consoleLog.txt file with the corresponding date and time.
