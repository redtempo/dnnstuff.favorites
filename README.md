<mark>IMPORTANT: This project is not being maintained going forward. If you are interested in taking over this repo, please open an issue and I'll make arrangements for the transfer</mark>

# Favorites Module for DNN (DotNetNuke)

A DNN module that allows a user to maintain a list of their favorite pages

## Minimum DNN Version

Current releases support DNN 7.2.0 and later

## Releases

[Releases](https://github.com/redtempo/dnnstuff.favorites/releases)

## Documentation

[Documentation](https://redtempo.github.io/dnnstuff.favorites/)

## Building Extension Package

To build a package for installing with the DNN extension installer do the following:

Drop to a command line and go into the build folder

Run `build.bat [version] [configuration]`

where:

* version is the version formatted as major.minor.patch (ie. 01.04.05)
* configuration is the build configuration to use (Debug or Release)

Example:

* `build.bat 01.04.05 Release` will created a release build with version 01.04.05

All builds are written into the Build\Deploy folder
