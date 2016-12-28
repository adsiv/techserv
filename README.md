# techserv
old intranet site

This is an intranet site I created a few years ago for a tech department to use. It's (presumably) still being used as a resource for employees of my old tech department to store hardware and propietary software installation instructions, manage links to various other intranet pages and network resources, track available used inventory to save time returning calls to customers and various other tools.  All sensetive information has been removed.


default.aspx

Main page, displays dynamic links created from the secure/techserv.s3db database.


documentsearch.aspx

Utility for tech department to search for files on network drives based on custom sorting procedure.


frame.aspx

Page created to display various .html pages in an iframe with a variable appended to the url.


hardwarelist.aspx and secure/managehardwarelist.aspx

Pages to display an often changing list of hardware available to purchase by our clients. Hardware data stored in secure/techserv.s3db.


usedhardwarelist.aspx and secure/manageusedhardwarelist.aspx

Pages to display hardware returned from clients, with information on condition and current pricing.


secure/managelinks.aspx

Page to manage links displayed on default.aspx.


secure/updatenotification.aspx

Page to add custom notice to default.aspx.


secure/techserv.s3db

Sqlite database used to store all settings on site.
