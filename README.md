# SUGDE 18/01/2017
###Rule Your Solutions With the Sitecore Rules Engine
Repository for my presentation at SUGDE 18 January 2017

---

Slides: [https://github.com/cassidydotdk/sugde/blob/master/Rule%20your%20solutions.pptx
](https://github.com/cassidydotdk/sugde/blob/master/Rule%20your%20solutions.pptx)

##Setup notes:

(very bare-bones, not really a production setup)

- Clone the repo
- Use SIM (or whatever) to setup a **NEW** 8.2u2 instance, map it to "sugde.local".
- Edit `/App_Config/Include/Unicorn/z.UnicornDataStore.config`, match the targetDataStore to your local folders
- Build project (probably needs VS2015)
- Right-click "Website" and publish it to your local Sitecore instance
- Sync Unicorn (sugde.local/unicorn.aspx -> sync)

Note: Unicorn will throw a couple of error/warnings. This is fine.

Profit! :-)

#WARNING
**DO NOT SYNC THIS TO ANYTHING BUT AN EMPTY INSTANCE.** The Unicorn configuration has `/sitecore` as it's root item, and controls the _entire_ "master" database. Fair warning :-)
