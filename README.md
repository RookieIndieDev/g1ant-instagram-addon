# G1ANT-instagram

Instagram Addon for G1ANT Studio.

# How to use:

## `open` command:
1. This command opens the instagram app on a connected android device. 
2. This command require two parameters: `pword` for the user's password and `email` the e-mail ID to be used for logging in.
3. This command needs to be called before any of the other commands can be called. 

## `makepost` command
1. This command makes a post with an image from the gallery with a user specified caption.
2. This command requires an argument `imagenumber`, this specifies which image to select, i.e., nth numbered image in the gallery, for example a value of 5 would select the fifth image. It takes an optional argument `caption`, this is used as caption text for the post, if empty, no caption is applied. 

## `senddm` command
1. This command makes the bot send a message to the specified recipient.
2. This command requires two arguments `content` and `recipient`, `content` is for the contents of the message, `recipient` contains who should recieve the message. 

**Note:** To use this addon, Appium needs to be installed. Instructions on how to install Appium [here](http://appium.io/docs/en/about-appium/getting-started/).

# Acknowledgements

Uses code from the [G1ANT Repository](https://github.com/g1ant-robot)

 