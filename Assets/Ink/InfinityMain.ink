//DAY 1 FILES
//Starts with Day1_Start in InfinityMain.ink
INCLUDE Day1_Baha_JV
INCLUDE Day1_Baha_Ducksly
    //POST-LISTENING, PRIVATE CONVOS
INCLUDE Day1_PrivateConvoChoice
INCLUDE Day1_Dover_Baha
INCLUDE Day1_Dover_JV
INCLUDE Day1_Dover_Ducksly

//DAY 2 FILES
INCLUDE Day2_Start
INCLUDE Day2_JV_Baha
INCLUDE Day2_JV_Ducksly
    //POST-LISTENING, PRIVATE CONVOS
INCLUDE Day2_PrivateConvoChoice
INCLUDE Day2_Dover_Baha
INCLUDE Day2_Dover_JV
INCLUDE Day2_Dover_Ducksly

//DAY 3 FILES
INCLUDE Day3_Start
INCLUDE Day3_Ducksly_Baha
INCLUDE Day3_Ducksly_JV
 //POST-LISTENING, PRIVATE CONVOS
INCLUDE Day3_PrivateConvoChoice
INCLUDE Day3_Dover_Baha
INCLUDE Day3_Dover_JV
INCLUDE Day3_Dover_Ducksly

//FINALE
INCLUDE Finale_1

//Playtesting (INCLUDE A PLAYTESTING SCRIPT)
INCLUDE Playtesting_1





//THEY SENT US TO INFINITY MAIN

//GLOBAL VARIABLES

//uncomment lines here to test knots stored in different files.
    //this is due to our use of -> DONE at the end of each file. 
//KNOT TESTING
//DAY 1
-> Day1_Start
// -> Day1_Baha_JV
// -> Day1_Baha_Ducksly
// -> Day1_PrivateConvoChoice
// -> Day1_Dover_Baha
// -> Day1_Dover_JV
// -> Day1_Dover_Ducksly

//DAY 2
// -> Day2_Start
// -> Day2_JV_Baha
// -> Day2_JV_Ducksly
// -> Day2_PrivateConvoChoice
// -> Day2_Dover_Baha
// -> Day2_Dover_JV
// -> Day2_Day_Ducksly

//DAY 3
// -> Day3_Start
// -> Day3_Ducksly_Baha
// -> Day3_Ducksly_JV
// -> Day3_PrivateConvoChoice
// -> Day3_Dover_Baha
// -> Day3_Dover_JV
// -> Day3_Dover_Ducksly

// FINALE
// -> Finale_1

// OTHER 
// -> Playtesting_1

    
=== Day1_Start ===
Heeeeeey Dover, what's up? Can you patch me in to Baha? He's probably on the Bridge. #JV

//If connected, link to Day1_Baha_JV
//NOTE: #JV is a speech tag to mark who is saying which words during dialogue. Might be helpful if we need need to reference the tag in code. They should not appear in dialogue text in Fungus, but will appear in the Ink editor. 

Bonjour Dover, might you be so kind as to connect me with Captain Baha? Urgent business. Statistically, he's on the Bridge at this hour. #Ducksly

// -> Day1_Baha_Ducksly
-> DONE //NOTE: DONE and END are effectively the same in that they finish the story. Ideally, we want to call a new knot. 