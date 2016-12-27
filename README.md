mbpm2git
===
mbpm2git is a command line tool that converts *.xep* or *.xel* file into text file to be used with git or any other version control system.

Overview
---
Metastorm BPM 7 procedures and libraries files are stored in zip format files with .xep or .xel extension. 
This format is unsuitable to track changes or to be used with a version control system like git.
mbpm2git automates the workflow and extracts the content in text and xml files ready to be committed to git.  

Install
---
- Copy the bin directory in *Programs Files* folder renaming it mbpm2git (`C:\Program Files\mbpm2git`)
- Add the folder to the system's path with **setx** command (`setx /m path "%path%;C:\Program Files\mbpm2git"`)

Use
---
**`mbpm2git.exe -i`***`xep/xel-file`***`-o`***`output-directory`***`[-f] [-c]`**

Options:
```
  -i, --input        Required. Input file to read
  -o, --output       Required. Output path to write
  -f, --formatxml    Format xml file
  -c, --copy         Copy xep or xel file
  --help             Display this help screen.
```

License
---
The license of the project is the [MIT](LICENSE).