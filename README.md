# IdeagenCalc

Calculator to solve math expression given in string format.

Everything works with the assumption that the input has been sanitized and is in legal math format.
Example:
1. The numbers of open/close brackets must match.

    ( 6 + 5 ) is a valid expression
    
    ( 6 + 5 )) is not a valid expression
    
2. Number have only single decimal point

    50.5 is a legal number
    
    50.5.5 is not a legal number
    
Time taken to complete: ~6 hours
