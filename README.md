# Zolom
C# Executable with embedded Python that can be used reflectively to run python code on systems without Python installed

# Usage
`zolom.exe --script:"from random import seed; from random import random; seed(1); print 'getting random number'; print random();"`
`zolom.exe --b64script:"ZnJvbSByYW5kb20gaW1wb3J0IHNlZWQ7IGZyb20gcmFuZG9tIGltcG9ydCByYW5kb207IHNlZWQoMSk7IHByaW50ICdnZXR0aW5nIHJhbmRvbSBudW1iZXInOyBwcmludCByYW5kb20oKTs="`

# Building
Using Visual Studio restore the nuget packages and then click build.

# Adding more modules
Unzip the Lib.zip file and add your modules, rezip the file and embed as a resource, finally recompile and your new lib should be available
