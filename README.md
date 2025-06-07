# word-finder

Word Finder Challenge:

Problem Description
The core task involves implementing a WordFinder class capable of searching a character matrix for words from a provided stream. Words can appear horizontally (left to right) or vertically (top to bottom).

Example:

Consider the following 5x5 character matrix:

```
A B C D C
F G W I O
C H I L L
P Q N S D
U V D X Y
```

Given the word stream: **COLD**, **WIND**, **SNOW**, **CHILL**

The WordFinder should identify:

**COLD** (found vertically, starting from 'C' in the first row, last column)  
**WIND** (found vertically, starting from 'W' in the second row, third column)  
**CHILL** (found horizontally, starting from 'C' in the third row, first column)
