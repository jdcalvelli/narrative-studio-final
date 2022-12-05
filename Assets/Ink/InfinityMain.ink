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
INCLUDE Day1_Start
INCLUDE Testing1
INCLUDE Testing2




//THEY SENT US TO INFINITY MAIN

//GLOBAL VARIABLES___________________________

//SCENE VISITATION BOOLS
VAR day1_scenechoice = ""

VAR current_location = "" //will change the printed name of the location with temporary variables located in relevant scenes.

//CHARACTER RELATIONSHIP (Scale of 1 - 5, 1 being negative and 5 being positive) 
VAR B_JV_rel = 3

//___________________________________________
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