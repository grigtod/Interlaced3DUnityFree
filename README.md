# Interlaced3DUnityFree

This implementation is not hardware specific. This interlacing method will work for any interlacing purposes. 

If you are targeting Flightdeck tablet:
Don't forget to add the sdeck.jar plugin, otherwise the your tablet won't switch to 3D.

If you decide to use this in an application I have only 1 condition. I would like to be able to play your game/app. You can send me link and key as a twitter message.

If you have a problem using this you can message me on twitter: @grigtod

It still has some problems:
- The cameras are not set up properly so the overall quality is not the best.
- I also suspect that it could be optimized a lot. This uses my second shader ever so I just can't wait to see some shader guru use texture (instead of geometry) to mask the environment. 
- If you reduce the near clipping plane camera distance you might come across some floating point issues.
- You should keep the camera position and rotation centred to the world when you start your app. Once the masking geometry is generated you can rotate and move it around as normal.



