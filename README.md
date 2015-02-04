# Interlaced3DUnityFree

This implementation is not hardware specific. This interlacing method will work for any interlacing purposes. 

If you are targeting Flightdeck tablet:
Don't forget to add the sdeck.jar plugin, otherwise your tablet won't switch to 3D.

If you decide to use this in an application I have only 1 condition. I would like a link to your application/trailer etc. 

If you have some issues when using this you can message me on twitter: @grigtod

Warning:
Both the eye cameras and the "InterlacedCam" should start in the centre of the world. You can move and rotate them after the blocking geometry is created.

New:
Enable "Combine filter geometry" for each camera to increase performance. I left the original code for testing purposes...

Known Issues:
- If you reduce the near clipping plane camera distance you might come across some floating point issues.
- You should keep the camera position and rotation centred to the world when you start your app. Once the masking geometry is generated you can rotate and move it around as normal.



