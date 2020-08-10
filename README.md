# Zolom
C# Executable with embedded Python that can be used reflectively to run python code on systems without Python installed

# Usage
`zolom.exe "from random import seed; from random import random; seed(1); print 'getting random number'; print random();"`

# Building
Using Visual Studio restore the nuget packages and then click build.
