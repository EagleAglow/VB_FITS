# VB_FITS

A Visual Basic (in Visual Studio 2022) programming exercise, for a viewer for FITS (Flexible Image Transport System) astronomical files.

![ScreenShot](/Form.png)

This is a work in (occasional) progress, with limited testing. Some potential problems are flagged below, but there certain to be more.

To view a FITS file, click the "Open File" button, and wait...  Some files are quite complex, and will take some tens of seconds to process.

After the file loads, the first textbox shows the filename.  If you edit any header lines, you can save the file with the "Save File" button.
The original file will be overwritten, or (if you modify the filename) a new file will be created.
Changing the path to the file has not been tested!

The listbox below the filename lists the file HDUs (HDU = "Header Data Unit").  The small listbox to the right shows the image number (for
HDUs that seem to have an image or layers of images).  Changing images may take a few seconds.

The bottom of the form shows the "card" text for the selected HDU and shows any selected image on the right.  The image may be resized,
panned, zoomed.  When you click a "card", three textboxes will be filled in, for the "key", its "value", and a "comment" (if any).  You can 
edit those, and use the "Save Edit" button.

New items (that is, new key/value pairs) can be added to the cards.  For keys of "HISTORY" and "COMMENT", leave the value field blank.
At the moment, there is no provision for deleting a card.

Note that changing some keys will break the FITS format.  Also, more complicated files seem to have non-standard cards.  Use this feature
with caution!

With VS2022, the steps to get from GIT would be: "Clone a repository", "Browse a repository", and for "Open from GitHUb",
put in: EagleAglow/VB_FITS, then "Clone". Open: VB_FITS.sln and then build it...