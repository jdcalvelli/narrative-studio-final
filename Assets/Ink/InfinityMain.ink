//DAY 1 FILES
INCLUDE Day1_Baha_JV
INCLUDE Day1_Baha_Ducksly
    //POST-LISTENING, PRIVATE CONVOS
INCLUDE Day_PrivateConvoChoice
INCLUDE Day1_Dover_Baha
INCLUDE Day1_Dover_JV
INCLUDE Day1_Dover_Ducksly

//DAY 2 FILES
INCLUDE Day2_Start
    //POST-LISTENING, PRIVATE CONVOS

//DAY 3 FILES
INCLUDE Day3_Start






    //POST-LISTENING, PRIVATE CONVOS




//THEY SENT US TO INFINITY MAIN

//GLOBAL VARIABLES

//uncomment lines here to test knots stored in different files due to our use of DONE. 
-> Day1_Start
// -> Day1_Baha_JV
// -> Day1_Baha_Ducksly

    
=== Day1_Start ===
Heeeeeey Dover, what's up? Can you patch me in to Baha? He's probably on the Bridge. #JV

//If connected, link to Day1_Baha_JV
//NOTE: #JV is a speech tag to mark who is saying which words during dialogue. Might be helpful if we need need to reference the tag in code. They should not appear in dialogue text in Fungus, but will appear in the Ink editor. 

Bonjour Dover, might you be so kind as to connect me with Captain Baha? Urgent business. Statistically, he's on the Bridge at this hour. #Ducksly

// -> Day1_Baha_Ducksly
-> DONE //NOTE: DONE and END are effectively the same in that they finish the story. Ideally, we want to call a new knot. 

=== Day1_PrivateConvoChoice ===

-> DONE