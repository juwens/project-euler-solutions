##################################################
# Compiling on Windows with Visual Studio Compiler
##################################################

- use the right compiler (x64): "Start -> Visual Studio 2013 -> Visual Studio Tools -> VS2013 x64 Cross Tools Command Prompt"
- "cl /O2 /W3 program.c" (O == optimize, W == warnings)

##################################################
# GCC on Linux and Windows (mingw)
##################################################
- MINGW Tipp in command Prompt: "set PATH=%PATH%;C:\MinGw\bin\"
- "gcc -O2 -Wall -march=amd64 program.c"