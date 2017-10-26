# Favorites Configuration 

The Favorites module is made up of three distinct parts, favorites
listing, favorites toggle and favorites toggle skin object.

## Favorites Listing

This module is a simple list of the favorites a user has selected. From
this module a user can navigate to one of their favorite pages or they
can remove a page from their list.

### Listing Options

#### Common

-   Header Template - html that will be shown once before the list of
    links are shown
-   Body Template - html that will be repeated for each favorite item in
    the list and will contain tokens to represent the link
    -   [IMAGEURL] - url to the site images folder
    -   [TITLE] - this is a safe page title which displays the page
        title if it contains text, otherwise it displays the page name
    -   [NAME] - displays the page name
    -   [URL] - the page url
    -   [LINKNAME] - shows a link to the page using the safe title as
        the link title (tool tip) and the page name as the link text
    -   [LINKTITLE] - shows a link to the page using the safe title as
        the link title (tool tip) and the page title as the link text
    -   [LINK] - functionally equivalent to [LINKNAME]
    -   [DELETEACTION] - shows the delete link so the favorite can be
        removed from the list

-   Footer Template - html that will be shown once after the list of
    links are shown
-   Empty Html - html that will show if the user has no favorites in
    their list
-   Unathenticated Html - html that will show if the user is not logged
    in or anonymous user

## Favorites Toggle

This module allows the user to toggle the current page as a favorite.
The specific action of the toggle depends on whether this page is
already a favorite or not. If it is, then the user can remove this page
from their favorites. If it isn't already a favorite, then the user can
add it to their favorites. This module is essentially identical to the
favorites skin object, except it has an options screen so you can easily
change the look of the links and of course it will need to be added to
every page you want the toggle option.

### Toggle Options

#### Common

-   Add Message - message displayed when a page can be added to the
    favorites list
-   Remove Message - message displayed when a page can be removed from
    the favorites list

In either message you can use only the [IMAGEURL] token

## Favorites Toggle Skin Object

The skin object contains the same functionality that the favorites
toggle module includes except it's in the form of a skin object so you
can quickly add it to a skin definition and have it appear on any pages
that use that skin.

To add the skin object to a skin, you will need to add two elements to
the skin ascx file.

​1. Add the reference to the ToggleSkinObject 

	<%@ Register TagPrefix="dnn" TagName="FAVORITES\_TOGGLE" Src="~/DesktopModules/DNNStuff - Favorites/ToggleSkinObject.ascx" %>


​2. Add a call to the skin object within the html section of the skin
ascx file in the location you wish it to appear onscreen. If you wish to
customize the look of the toggle button

	<dnn:FAVORITES_TOGGLE runat="server" id="dnnFAVORITES" cssclass="CommandButton" />

### Skin Object Options

-   cssclass - css classname you wish to use for styling the link,
    defaults to CommandButton
-   addmessage - optional message displayed when the page can be
    added to the list
    - defaults to AddMessage.Text in ToggleSkinObject.ascx.resx
```<img border=0 align=absmiddle src='[IMAGEURL]/add.gif'> Add To Favs```

-   removemessage - optional message displayed when the page can
    be removed from the list
    - defaults to RemoveMessage.Text in ToggleSkinObject.ascx.resx
```<img border=0 align=absmiddle src='[IMAGEURL]/delete.gif'> Remove From Favs```

