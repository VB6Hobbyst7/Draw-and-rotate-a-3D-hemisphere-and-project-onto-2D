# Draw-and-rotate-a-3D-hemisphere-and-project-onto-2D
The point of this program is to draw a 3D hemisphere; to rotate it and then project that.

I think this project could help beginners because this is where the elementary formulas are used.
The principle of projection consists in pretending to be looking at an object through a (transparent) film (layer or window). The eye sees what arrives on the window. This is illustrated in the uploaded images, I am using a 3D online tool from Matheretter.de.

You can zoom by increasing the camera position or decreasing the window position. If it happens that the window is too low, i.e. part of the object is behind the window, this part will not be drawn.

A lot of vectors are used to fill the surface. All of these vectors need to be rotated and drawn. Therefore, I decided to make the calculation procedure asynchronous. Since it is then cumbersome to draw in the PictureBox, and the Graphics.DrawLine function reached its limits anyway, I integrated SkiaSharp. Now, I can rotate the hemisphere with a delay of a few hundredths of a millisecond. 

If you open the project with Visual Studio, please download the SkiaSharp package in Visual Studio's own Nuget Package Manager. I couldn't upload that many files here on GitHub. 
