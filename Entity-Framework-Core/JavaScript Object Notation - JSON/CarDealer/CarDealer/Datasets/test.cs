﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Datasets
{
    public class test
    {
        public static string carsInput =
            "[{\"make\":\"Opel\",\"model\":\"Omega\",\"travelledDistance\":176664996,\"partsId\":[38,102,23,116,46,68,88,104,71,32,114]},{\"make\":\"Opel\",\"model\":\"Astra\",\"travelledDistance\":516628215,\"partsId\":[39,62,72]},{\"make\":\"Opel\",\"model\":\"Astra\",\"travelledDistance\":156191509,\"partsId\":[48,44,112]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"travelledDistance\":347259126,\"partsId\":[36,114,88,115,72,11,50,75,20,54,8]},{\"make\":\"Opel\",\"model\":\"Kadet\",\"travelledDistance\":31737446,\"partsId\":[65,95,90]},{\"make\":\"Opel\",\"model\":\"Vectra\",\"travelledDistance\":238042093,\"partsId\":[40,29,102,73,68,7]},{\"make\":\"Opel\",\"model\":\"Insignia\",\"travelledDistance\":225253817,\"partsId\":[108,8,102,57,23,79,103,70,67,71,46]},{\"make\":\"Opel\",\"model\":\"Astra\",\"travelledDistance\":31468479,\"partsId\":[102,54,15]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"travelledDistance\":282499542,\"partsId\":[46,58,12]},{\"make\":\"Opel\",\"model\":\"Omega\",\"travelledDistance\":111313670,\"partsId\":[22,52,59,59,10,112,99,48,8,62,27]},{\"make\":\"Opel\",\"model\":\"Insignia\",\"travelledDistance\":168539389,\"partsId\":[42,96,45,84,66,6]},{\"make\":\"Opel\",\"model\":\"Vectra\",\"travelledDistance\":433351992,\"partsId\":[90,113,98]},{\"make\":\"Opel\",\"model\":\"Astra\",\"travelledDistance\":349837452,\"partsId\":[117,61,78,111,65,93,34,93,108,96,48]},{\"make\":\"Opel\",\"model\":\"Omega\",\"travelledDistance\":109910837,\"partsId\":[12,68,103]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"travelledDistance\":241891505,\"partsId\":[49,107,94]},{\"make\":\"Opel\",\"model\":\"Insignia\",\"travelledDistance\":339785118,\"partsId\":[34,67,99,88,94,100,103,44,113,57,111]},{\"make\":\"Opel\",\"model\":\"Omega\",\"travelledDistance\":254808828,\"partsId\":[47,5,17]},{\"make\":\"Opel\",\"model\":\"Corsa\",\"travelledDistance\":267253567,\"partsId\":[10,19,46]},{\"make\":\"Opel\",\"model\":\"Omega\",\"travelledDistance\":277250812,\"partsId\":[97,46,59,34,79,2,47,91,25,115,99]},{\"make\":\"BMW\",\"model\":\"F20\",\"travelledDistance\":401291910,\"partsId\":[100,60,78]},{\"make\":\"BMW\",\"model\":\"F25\",\"travelledDistance\":476132712,\"partsId\":[82,63,57,58,108,100]},{\"make\":\"BMW\",\"model\":\"M5 F10\",\"travelledDistance\":140799461,\"partsId\":[96,109,46,61,35,37,4,8,15,72,48]},{\"make\":\"BMW\",\"model\":\"F04\",\"travelledDistance\":418839575,\"partsId\":[6,79,107]},{\"make\":\"BMW\",\"model\":\"E88\",\"travelledDistance\":27453411,\"partsId\":[91,88,16]},{\"make\":\"BMW\",\"model\":\"M Roadster E85\",\"travelledDistance\":475685374,\"partsId\":[28,40,33,20,82,37,71,89,30,22,65]},{\"make\":\"BMW\",\"model\":\"1M Coupe\",\"travelledDistance\":39826890,\"partsId\":[115,69,33,44,104,4]},{\"make\":\"BMW\",\"model\":\"X6 M\",\"travelledDistance\":322292247,\"partsId\":[36,74,85]},{\"make\":\"BMW\",\"model\":\"E67\",\"travelledDistance\":476830509,\"partsId\":[84,84,10,83,7,45,39,35,61,106,38]},{\"make\":\"BMW\",\"model\":\"M6 E63\",\"travelledDistance\":57189891,\"partsId\":[72,79,15]},{\"make\":\"BMW\",\"model\":\"M6 E63\",\"travelledDistance\":69863204,\"partsId\":[114,103,44]},{\"make\":\"BMW\",\"model\":\"F20\",\"travelledDistance\":487897422,\"partsId\":[48,99,41,61,57,91,101,25,95,31,7]},{\"make\":\"BMW\",\"model\":\"F04\",\"travelledDistance\":443756363,\"partsId\":[89,104,43]},{\"make\":\"BMW\",\"model\":\"M5 F10\",\"travelledDistance\":435603343,\"partsId\":[40,103,89]},{\"make\":\"BMW\",\"model\":\"X6 M\",\"travelledDistance\":227443571,\"partsId\":[18,29,116,36,98,5,83,4,114,9,69]},{\"make\":\"BMW\",\"model\":\"F20\",\"travelledDistance\":284809463,\"partsId\":[78,5,23]},{\"make\":\"BMW\",\"model\":\"X6 M\",\"travelledDistance\":183346013,\"partsId\":[5,27,29,42,22,2]},{\"make\":\"BMW\",\"model\":\"F04\",\"travelledDistance\":265166885,\"partsId\":[109,113,79,111,27,115,100,117,32,42,31]},{\"make\":\"BMW\",\"model\":\"F20\",\"travelledDistance\":171765152,\"partsId\":[84,54,75]},{\"make\":\"BMW\",\"model\":\"M6 E63\",\"travelledDistance\":243205800,\"partsId\":[83,53,72]},{\"make\":\"Fiat\",\"model\":\"Panda\",\"travelledDistance\":1591174,\"partsId\":[94,35,63,43,26,29,50,1,32,59,94]},{\"make\":\"Fiat\",\"model\":\"Panda 4x4 Antarctica\",\"travelledDistance\":501838637,\"partsId\":[88,31,44,87,104,70]},{\"make\":\"Fiat\",\"model\":\"500 (2007) Abarth 695 Tributo Maserati\",\"travelledDistance\":73917184,\"partsId\":[65,108,36]},{\"make\":\"Fiat\",\"model\":\"Panda 4x4 Antarctica\",\"travelledDistance\":388951228,\"partsId\":[90,94,69,108,51,58,40,63,71,109,15]},{\"make\":\"Fiat\",\"model\":\"Panda 4x4\",\"travelledDistance\":94291695,\"partsId\":[25,37,40]},{\"make\":\"Fiat\",\"model\":\"Panda\",\"travelledDistance\":271974888,\"partsId\":[21,92,44]},{\"make\":\"Fiat\",\"model\":\"Freemont\",\"travelledDistance\":291375480,\"partsId\":[44,52,52,114,79,80,25,92,115,86,84]},{\"make\":\"Fiat\",\"model\":\"500L\",\"travelledDistance\":363056661,\"partsId\":[30,65,70]},{\"make\":\"Fiat\",\"model\":\"Panda\",\"travelledDistance\":356486400,\"partsId\":[96,61,103]},{\"make\":\"Fiat\",\"model\":\"Freemont\",\"travelledDistance\":46079092,\"partsId\":[67,85,51,41,77,53,74,73,16,9,13]},{\"make\":\"Fiat\",\"model\":\"Panda 4x4\",\"travelledDistance\":506281363,\"partsId\":[37,19,77]},{\"make\":\"Fiat\",\"model\":\"Panda 4x4 Antarctica\",\"travelledDistance\":147310005,\"partsId\":[108,80,28,111,98,24]},{\"make\":\"Fiat\",\"model\":\"500L\",\"travelledDistance\":450106773,\"partsId\":[7,97,100,13,102,22,57,42,2,91,8]},{\"make\":\"Fiat\",\"model\":\"500L\",\"travelledDistance\":418573870,\"partsId\":[4,50,20]},{\"make\":\"Fiat\",\"model\":\"500 (2007) Abarth 695 Tributo Maserati\",\"travelledDistance\":255814652,\"partsId\":[58,22,9]},{\"make\":\"Fiat\",\"model\":\"Panda\",\"travelledDistance\":165915677,\"partsId\":[89,53,84,64,10,32,40,98,23,64,95]},{\"make\":\"Fiat\",\"model\":\"500L\",\"travelledDistance\":414493068,\"partsId\":[61,35,5,44,83,5]},{\"make\":\"Fiat\",\"model\":\"Freemont\",\"travelledDistance\":476416173,\"partsId\":[64,56,70]},{\"make\":\"Fiat\",\"model\":\"Panda 4x4\",\"travelledDistance\":507365630,\"partsId\":[7,24,23,82,1,40,10,86,93,73,85]},{\"make\":\"Fiat\",\"model\":\"500 (2007) Abarth 695 Tributo Maserati\",\"travelledDistance\":250201285,\"partsId\":[104,54,39]},{\"make\":\"Fiat\",\"model\":\"Freemont\",\"travelledDistance\":370538088,\"partsId\":[25,27,100]},{\"make\":\"Fiat\",\"model\":\"500L\",\"travelledDistance\":294377378,\"partsId\":[45,83,34,29,1,47,43,47,66,52,54]},{\"make\":\"Mercedes\",\"model\":\"A 140\",\"travelledDistance\":127050841,\"partsId\":[50,7,13]},{\"make\":\"Mercedes\",\"model\":\"W212\",\"travelledDistance\":352906120,\"partsId\":[41,87,38]},{\"make\":\"Mercedes\",\"model\":\"A 160\",\"travelledDistance\":69932764,\"partsId\":[88,33,115,88,32,55,107,39,90,36,64]},{\"make\":\"Mercedes\",\"model\":\"A 160 CDI\",\"travelledDistance\":2043780,\"partsId\":[77,92,81]},{\"make\":\"Mercedes\",\"model\":\"W212\",\"travelledDistance\":103410558,\"partsId\":[66,102,69,45,67,108]},{\"make\":\"Mercedes\",\"model\":\"W202\",\"travelledDistance\":376376181,\"partsId\":[9,92,63,66,4,20,73,42,5,55,28]},{\"make\":\"Mercedes\",\"model\":\"W211\",\"travelledDistance\":501021413,\"partsId\":[13,103,102]},{\"make\":\"Mercedes\",\"model\":\"A 170 CDI\",\"travelledDistance\":203728907,\"partsId\":[37,77,115]},{\"make\":\"Mercedes\",\"model\":\"W212\",\"travelledDistance\":437173024,\"partsId\":[97,99,113,12,76,114,97,64,56,59,56]},{\"make\":\"Mercedes\",\"model\":\"W124\",\"travelledDistance\":453245765,\"partsId\":[73,33,24,53,59,65]},{\"make\":\"Mercedes\",\"model\":\"W210\",\"travelledDistance\":461671208,\"partsId\":[114,82,56]},{\"make\":\"Mercedes\",\"model\":\"W202\",\"travelledDistance\":402675300,\"partsId\":[18,53,97,67,33,3,3,93,20,60,75]},{\"make\":\"Mercedes\",\"model\":\"W211\",\"travelledDistance\":132956063,\"partsId\":[13,74,73]},{\"make\":\"Mercedes\",\"model\":\"W212\",\"travelledDistance\":278080805,\"partsId\":[57,32,39]},{\"make\":\"Mercedes\",\"model\":\"W203\",\"travelledDistance\":259511953,\"partsId\":[64,19,63,51,87,33,47,103,54,57,117]},{\"make\":\"Mercedes\",\"model\":\"W211\",\"travelledDistance\":130475765,\"partsId\":[60,39,6]},{\"make\":\"Mercedes\",\"model\":\"W210\",\"travelledDistance\":181844305,\"partsId\":[74,40,107]},{\"make\":\"Mercedes\",\"model\":\"W204\",\"travelledDistance\":134106055,\"partsId\":[65,13,88,15,64,42,79,89,13,82,69]},{\"make\":\"Mercedes\",\"model\":\"W124\",\"travelledDistance\":41606319,\"partsId\":[12,84,45]},{\"make\":\"Mercedes\",\"model\":\"W212\",\"travelledDistance\":55397761,\"partsId\":[52,107,106,86,63,104]},{\"make\":\"Ford\",\"model\":\"Fiesta\",\"travelledDistance\":344433379,\"partsId\":[90,16,105,18,50,65,31,89,2,66,22]},{\"make\":\"Ford\",\"model\":\"Pinto\",\"travelledDistance\":288047842,\"partsId\":[87,59,53]},{\"make\":\"Ford\",\"model\":\"Torino\",\"travelledDistance\":450867168,\"partsId\":[93,13,30]},{\"make\":\"Ford\",\"model\":\"Fiesta\",\"travelledDistance\":301180732,\"partsId\":[110,86,63,70,48,42,37,63,60,56,98]},{\"make\":\"Ford\",\"model\":\"Pinto\",\"travelledDistance\":416418181,\"partsId\":[33,39,19,6,96,21]},{\"make\":\"Ford\",\"model\":\"Taurus\",\"travelledDistance\":403810025,\"partsId\":[103,18,110]},{\"make\":\"Ford\",\"model\":\"Fiesta\",\"travelledDistance\":37085116,\"partsId\":[38,50,85,97,76,56,33,28,67,38,117]},{\"make\":\"Ford\",\"model\":\"Torino\",\"travelledDistance\":440155426,\"partsId\":[38,8,45]},{\"make\":\"Ford\",\"model\":\"Pinto\",\"travelledDistance\":248943927,\"partsId\":[81,86,86]},{\"make\":\"Ford\",\"model\":\"GT40\",\"travelledDistance\":85557373,\"partsId\":[3,10,60,37,40,76,94,19,25,48,15]},{\"make\":\"Ford\",\"model\":\"Pinto\",\"travelledDistance\":136428787,\"partsId\":[102,77,6]},{\"make\":\"Ford\",\"model\":\"GT40\",\"travelledDistance\":300191400,\"partsId\":[36,44,105]},{\"make\":\"Ford\",\"model\":\"Fiesta\",\"travelledDistance\":251295244,\"partsId\":[78,28,86,52,79,77,95,94,81,107,25]},{\"make\":\"Ford\",\"model\":\"Torino\",\"travelledDistance\":85841328,\"partsId\":[28,111,79]},{\"make\":\"Ford\",\"model\":\"Fiesta\",\"travelledDistance\":232084221,\"partsId\":[23,6,95,104,61,44]},{\"make\":\"Ford\",\"model\":\"Pinto\",\"travelledDistance\":99638597,\"partsId\":[42,83,59,76,47,20,93,103,12,76,1]},{\"make\":\"Ford\",\"model\":\"Taurus\",\"travelledDistance\":176314890,\"partsId\":[49,79,105]},{\"make\":\"Ford\",\"model\":\"Fiesta\",\"travelledDistance\":470875447,\"partsId\":[53,22,85]},{\"make\":\"Ford\",\"model\":\"Torino\",\"travelledDistance\":25860756,\"partsId\":[3,9,18,50,28,44,55,38,76,116,54]},{\"make\":\"Ford\",\"model\":\"Ranger\",\"travelledDistance\":293626832,\"partsId\":[78,64,67,104,60,86]},{\"make\":\"Ford\",\"model\":\"Pinto\",\"travelledDistance\":240662780,\"partsId\":[32,80,54]},{\"make\":\"Ford\",\"model\":\"Ranger\",\"travelledDistance\":10053919,\"partsId\":[95,91,28,70,78,50,91,74,61,34,91]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":508864707,\"partsId\":[111,87,6]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":431663130,\"partsId\":[61,63,11]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":64266329,\"partsId\":[79,100,7,90,7,56,106,8,110,33,95]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":426059006,\"partsId\":[100,75,79]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":142914233,\"partsId\":[42,59,53]},{\"make\":\"Toyota\",\"model\":\"Corolla\",\"travelledDistance\":356361379,\"partsId\":[75,115,66,34,58,63,39,67,63,10,110]},{\"make\":\"Toyota\",\"model\":\"Yaris\",\"travelledDistance\":285031257,\"partsId\":[28,76,27]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":141313729,\"partsId\":[92,10,18,92,18,42]},{\"make\":\"Toyota\",\"model\":\"Camry Hybrid\",\"travelledDistance\":151868293,\"partsId\":[50,57,3,8,30,53,102,81,60,72,41]},{\"make\":\"Toyota\",\"model\":\"Corolla\",\"travelledDistance\":230556000,\"partsId\":[18,21,3]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":65891391,\"partsId\":[17,31,82]},{\"make\":\"Toyota\",\"model\":\"Corolla\",\"travelledDistance\":172436753,\"partsId\":[62,106,5,53,109,30,15,81,65,2,92]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":328571532,\"partsId\":[89,58,25,72,110,102]},{\"make\":\"Toyota\",\"model\":\"Camry Hybrid\",\"travelledDistance\":217630531,\"partsId\":[88,103,81]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":280666484,\"partsId\":[27,89,91,46,44,93,76,54,61,93,42]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":147379564,\"partsId\":[95,29,13]},{\"make\":\"Toyota\",\"model\":\"Corolla\",\"travelledDistance\":485584239,\"partsId\":[41,71,98]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":78228066,\"partsId\":[75,27,113,73,13,51,19,96,78,87,15]},{\"make\":\"Toyota\",\"model\":\"Corolla\",\"travelledDistance\":196587490,\"partsId\":[54,111,5]},{\"make\":\"Toyota\",\"model\":\"Yaris\",\"travelledDistance\":439493520,\"partsId\":[117,116,36]},{\"make\":\"Toyota\",\"model\":\"Corolla\",\"travelledDistance\":333412512,\"partsId\":[24,58,101,44,94,102,39,46,105,58,46]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":208912076,\"partsId\":[83,28,14]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":174113404,\"partsId\":[70,86,97,113,30,76]},{\"make\":\"Toyota\",\"model\":\"Yaris\",\"travelledDistance\":18776234,\"partsId\":[93,100,7,40,36,52,91,30,86,35,57]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":8676482,\"partsId\":[11,65,79]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":425742267,\"partsId\":[74,68,55]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":424624116,\"partsId\":[23,66,11,42,113,110,79,59,99,18,41]},{\"make\":\"Toyota\",\"model\":\"Yaris\",\"travelledDistance\":17169781,\"partsId\":[31,53,100,94,55,8]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":332788407,\"partsId\":[28,10,20]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":89596390,\"partsId\":[30,93,11,96,95,46,39,87,3,103,35]},{\"make\":\"Toyota\",\"model\":\"Camry Hybrid\",\"travelledDistance\":486872832,\"partsId\":[25,87,116]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":126607020,\"partsId\":[42,16,105]},{\"make\":\"Toyota\",\"model\":\"Camry Hybrid\",\"travelledDistance\":193362513,\"partsId\":[3,66,75,14,66,23,2,18,84,1,21]},{\"make\":\"Toyota\",\"model\":\"Prius\",\"travelledDistance\":191675886,\"partsId\":[48,41,25]},{\"make\":\"Toyota\",\"model\":\"Tacoma\",\"travelledDistance\":157810668,\"partsId\":[19,33,17]},{\"make\":\"Toyota\",\"model\":\"Camry Hybrid\",\"travelledDistance\":397831570,\"partsId\":[111,15,24,117,33,36,40,78,24,81,69]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":94210828,\"partsId\":[102,30,23]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":368986707,\"partsId\":[26,47,36,91,48,20]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":118192217,\"partsId\":[92,49,39,94,46,96,13,103,7,48,47]},{\"make\":\"Nissan\",\"model\":\"370Z\",\"travelledDistance\":59351269,\"partsId\":[101,77,38]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":12420594,\"partsId\":[91,113,77]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":486257730,\"partsId\":[73,56,116,4,21,11,28,19,2,23,64]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":312316612,\"partsId\":[81,86,91,20,56,99]},{\"make\":\"Nissan\",\"model\":\"370Z\",\"travelledDistance\":284500319,\"partsId\":[11,31,62]},{\"make\":\"Nissan\",\"model\":\"370Z\",\"travelledDistance\":91596434,\"partsId\":[15,40,23,108,22,39,62,3,53,110,77]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":457486023,\"partsId\":[17,115,55]},{\"make\":\"Nissan\",\"model\":\"370Z\",\"travelledDistance\":135897329,\"partsId\":[48,4,18]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":393081223,\"partsId\":[101,39,7,97,44,13,41,35,107,6,43]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":197599645,\"partsId\":[112,13,64]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":407562858,\"partsId\":[113,29,20]},{\"make\":\"Nissan\",\"model\":\"370Z\",\"travelledDistance\":363918741,\"partsId\":[31,2,1,93,67,68,34,110,51,94,32]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":326260222,\"partsId\":[15,52,117]},{\"make\":\"Nissan\",\"model\":\"Versa\",\"travelledDistance\":475666874,\"partsId\":[11,102,7,83,57,109]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":179796793,\"partsId\":[50,57,113,67,41,1,1,105,93,9,15]},{\"make\":\"Nissan\",\"model\":\"370Z\",\"travelledDistance\":55268939,\"partsId\":[50,74,63]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":157249056,\"partsId\":[110,14,88]},{\"make\":\"Nissan\",\"model\":\"Rogue\",\"travelledDistance\":114846152,\"partsId\":[10,2,57,58,72,78,4,94,106,24,92]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":424117627,\"partsId\":[117,95,92,66,24,5]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":274678949,\"partsId\":[55,60,92]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":95799498,\"partsId\":[20,21,35,35,15,103,11,47,68,26,74]},{\"make\":\"Nissan\",\"model\":\"Rogue\",\"travelledDistance\":310364796,\"partsId\":[92,82,100]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":125157902,\"partsId\":[82,50,86]},{\"make\":\"Nissan\",\"model\":\"Altima\",\"travelledDistance\":187152855,\"partsId\":[20,64,64,77,59,21,63,111,73,83,2]},{\"make\":\"Nissan\",\"model\":\"Versa\",\"travelledDistance\":440899435,\"partsId\":[34,111,38]},{\"make\":\"Nissan\",\"model\":\"GT-R\",\"travelledDistance\":122310701,\"partsId\":[94,18,8]},{\"make\":\"Nissan\",\"model\":\"Versa\",\"travelledDistance\":317911903,\"partsId\":[36,75,52,107,11,55,36,43,112,49,35]},{\"make\":\"Great Wall\",\"model\":\"H2\",\"travelledDistance\":357701772,\"partsId\":[85,3,81]},{\"make\":\"Great Wall\",\"model\":\"Haval M4\",\"travelledDistance\":515523178,\"partsId\":[95,102,23,70,77,81]},{\"make\":\"Great Wall\",\"model\":\"H2\",\"travelledDistance\":438447396,\"partsId\":[101,46,86,58,10,27,105,94,98,42,73]},{\"make\":\"Great Wall\",\"model\":\"H8\",\"travelledDistance\":261462447,\"partsId\":[66,43,43]},{\"make\":\"Great Wall\",\"model\":\"Steed 3\",\"travelledDistance\":431796268,\"partsId\":[32,92,83]},{\"make\":\"Great Wall\",\"model\":\"Wingle 5\",\"travelledDistance\":495225064,\"partsId\":[65,94,94,114,3,32,57,113,111,39,88]},{\"make\":\"Great Wall\",\"model\":\"Haval M4\",\"travelledDistance\":338663381,\"partsId\":[109,18,56,53,102,23]},{\"make\":\"Great Wall\",\"model\":\"Haval H6\",\"travelledDistance\":515863753,\"partsId\":[110,75,75]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":284369351,\"partsId\":[80,66,70,36,27,30,38,61,55,11,46]},{\"make\":\"Renault\",\"model\":\"Clio IV\",\"travelledDistance\":225782314,\"partsId\":[18,88,105]},{\"make\":\"Renault\",\"model\":\"Duster\",\"travelledDistance\":275222997,\"partsId\":[44,61,68]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":268240617,\"partsId\":[53,67,100,114,31,101,74,103,70,49,71]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":305807332,\"partsId\":[106,49,105]},{\"make\":\"Renault\",\"model\":\"Duster\",\"travelledDistance\":451149098,\"partsId\":[18,42,103]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":147141364,\"partsId\":[88,84,110,27,55,58,80,82,26,68,78]},{\"make\":\"Renault\",\"model\":\"Clio IV\",\"travelledDistance\":410170426,\"partsId\":[39,107,116]},{\"make\":\"Renault\",\"model\":\"Duster\",\"travelledDistance\":198197668,\"partsId\":[98,77,3,56,11,61]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":303853081,\"partsId\":[47,18,50,81,18,42,66,52,41,92,108]},{\"make\":\"Renault\",\"model\":\"Captur\",\"travelledDistance\":104305182,\"partsId\":[113,61,71]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":17909035,\"partsId\":[102,45,36]},{\"make\":\"Renault\",\"model\":\"Espace\",\"travelledDistance\":29567678,\"partsId\":[9,83,94,106,117,90,1,81,32,49,19]},{\"make\":\"Renault\",\"model\":\"Alaskan\",\"travelledDistance\":392193253,\"partsId\":[59,114,15,18,92,66]},{\"make\":\"Renault\",\"model\":\"Captur\",\"travelledDistance\":515034479,\"partsId\":[25,39,2]},{\"make\":\"Renault\",\"model\":\"Espace\",\"travelledDistance\":379189144,\"partsId\":[115,94,98,78,113,10,19,45,51,63,4]},{\"make\":\"Chevy\",\"model\":\"Camaro\",\"travelledDistance\":140281843,\"partsId\":[99,21,9]},{\"make\":\"Chevy\",\"model\":\"Caprice\",\"travelledDistance\":48720733,\"partsId\":[79,59,3]},{\"make\":\"Chevy\",\"model\":\"Camaro\",\"travelledDistance\":472935290,\"partsId\":[41,15,13,18,86,72,79,16,78,13,46]},{\"make\":\"Chevy\",\"model\":\"Caprice\",\"travelledDistance\":401020251,\"partsId\":[59,106,80]},{\"make\":\"Chevy\",\"model\":\"Malibu\",\"travelledDistance\":127614006,\"partsId\":[15,32,11]},{\"make\":\"Chevy\",\"model\":\"Camaro\",\"travelledDistance\":265890224,\"partsId\":[7,1,70,102,78,76,39,41,116,55,14]},{\"make\":\"Chevy\",\"model\":\"Impala\",\"travelledDistance\":156401301,\"partsId\":[5,7,73]},{\"make\":\"Chevy\",\"model\":\"Malibu\",\"travelledDistance\":250044709,\"partsId\":[21,45,58,111,95,111]},{\"make\":\"Chevy\",\"model\":\"Impala\",\"travelledDistance\":19486044,\"partsId\":[70,114,108,105,30,3,83,59,72,31,68]},{\"make\":\"Chevy\",\"model\":\"Camaro\",\"travelledDistance\":152312063,\"partsId\":[75,36,95]},{\"make\":\"Chevy\",\"model\":\"Camaro\",\"travelledDistance\":478411784,\"partsId\":[88,47,74]},{\"make\":\"Chevy\",\"model\":\"Corvette\",\"travelledDistance\":520332790,\"partsId\":[104,49,25,59,62,56,102,34,96,40,25]},{\"make\":\"Chevy\",\"model\":\"Cruze\",\"travelledDistance\":333261359,\"partsId\":[110,99,16,55,5,7]},{\"make\":\"Chevy\",\"model\":\"Corvette\",\"travelledDistance\":314764731,\"partsId\":[27,95,95]},{\"make\":\"Chevy\",\"model\":\"Camaro\",\"travelledDistance\":354394122,\"partsId\":[50,40,43,79,66,55,53,72,25,55,115]},{\"make\":\"Chevy\",\"model\":\"Caprice\",\"travelledDistance\":247321209,\"partsId\":[71,60,56]},{\"make\":\"Chevy\",\"model\":\"Cruze\",\"travelledDistance\":366224374,\"partsId\":[40,30,39]},{\"make\":\"Chevy\",\"model\":\"Caprice\",\"travelledDistance\":338430654,\"partsId\":[20,94,27,92,39,19,49,26,35,58,100]},{\"make\":\"Chevy\",\"model\":\"Matiz\",\"travelledDistance\":274054974,\"partsId\":[99,38,114]},{\"make\":\"Rolls-Royce\",\"model\":\"Phantom\",\"travelledDistance\":208114157,\"partsId\":[36,78,37]},{\"make\":\"Rolls-Royce\",\"model\":\"Phantom Drophead Coupé\",\"travelledDistance\":260653592,\"partsId\":[109,32,91,31,79,93,88,116,95,10,10]},{\"make\":\"Rolls-Royce\",\"model\":\"Phantom\",\"travelledDistance\":225233067,\"partsId\":[40,18,12]},{\"make\":\"Rolls-Royce\",\"model\":\"Ghost\",\"travelledDistance\":496937828,\"partsId\":[62,110,52,72,18,37]},{\"make\":\"Rolls-Royce\",\"model\":\"Dawn\",\"travelledDistance\":202157384,\"partsId\":[89,96,106,80,22,117,82,39,58,72,26]},{\"make\":\"Rolls-Royce\",\"model\":\"Phantom\",\"travelledDistance\":327285667,\"partsId\":[47,78,108]},{\"make\":\"Rolls-Royce\",\"model\":\"Ghost\",\"travelledDistance\":278821902,\"partsId\":[32,93,25]},{\"make\":\"Rolls-Royce\",\"model\":\"Wraith\",\"travelledDistance\":305587766,\"partsId\":[93,27,87,25,61,30,95,7,71,102,15]},{\"make\":\"Rolls-Royce\",\"model\":\"Phantom Drophead Coupé\",\"travelledDistance\":261927306,\"partsId\":[6,74,71,11,103,10]},{\"make\":\"Rolls-Royce\",\"model\":\"Wraith\",\"travelledDistance\":193890679,\"partsId\":[34,98,11]},{\"make\":\"Rolls-Royce\",\"model\":\"Phantom Drophead Coupé\",\"travelledDistance\":483029198,\"partsId\":[96,95,47,96,17,26,108,69,49,47,112]},{\"make\":\"Lamborghini\",\"model\":\"Gallardo\",\"travelledDistance\":145640651,\"partsId\":[65,54,53]},{\"make\":\"Lamborghini\",\"model\":\"Murciélago\",\"travelledDistance\":344136052,\"partsId\":[44,13,17]},{\"make\":\"Lamborghini\",\"model\":\"Diablo\",\"travelledDistance\":379116231,\"partsId\":[97,113,35,97,41,37,100,36,2,70,87]},{\"make\":\"Lamborghini\",\"model\":\"Gallardo\",\"travelledDistance\":437885784,\"partsId\":[101,29,37]},{\"make\":\"Lamborghini\",\"model\":\"Murciélago\",\"travelledDistance\":499808136,\"partsId\":[43,20,51]},{\"make\":\"Lamborghini\",\"model\":\"Gallardo\",\"travelledDistance\":240371960,\"partsId\":[14,84,65,76,94,4,8,112,44,109,75]},{\"make\":\"Lamborghini\",\"model\":\"Diablo\",\"travelledDistance\":400917306,\"partsId\":[36,37,107]},{\"make\":\"Ferrari\",\"model\":\"Daytona\",\"travelledDistance\":316270662,\"partsId\":[113,83,55,115,6,32]},{\"make\":\"Ferrari\",\"model\":\"250 GTO\",\"travelledDistance\":245546172,\"partsId\":[117,24,27,33,28,100,42,107,54,105,95]},{\"make\":\"Ferrari\",\"model\":\"F430\",\"travelledDistance\":397106659,\"partsId\":[38,14,89]},{\"make\":\"Ferrari\",\"model\":\"275\",\"travelledDistance\":448008546,\"partsId\":[7,45,34]},{\"make\":\"Ferrari\",\"model\":\"F430\",\"travelledDistance\":403805820,\"partsId\":[27,88,78,112,70,82,13,111,86,50,48]},{\"make\":\"Ferrari\",\"model\":\"F40\",\"travelledDistance\":106050998,\"partsId\":[59,103,60,8,5,73]},{\"make\":\"Ferrari\",\"model\":\"250 GTO\",\"travelledDistance\":10791694,\"partsId\":[20,76,26]},{\"make\":\"Ferrari\",\"model\":\"Daytona\",\"travelledDistance\":351364846,\"partsId\":[1,16,79,48,103,27,25,99,5,107,34]},{\"make\":\"Ferrari\",\"model\":\"275\",\"travelledDistance\":5436105,\"partsId\":[68,36,18]},{\"make\":\"Ferrari\",\"model\":\"250 GTO\",\"travelledDistance\":455536599,\"partsId\":[113,112,14]},{\"make\":\"Ferrari\",\"model\":\"F40\",\"travelledDistance\":262060470,\"partsId\":[5,15,28,99,7,28,19,79,16,36,14]},{\"make\":\"Ferrari\",\"model\":\"250 GTO\",\"travelledDistance\":328086491,\"partsId\":[56,2,26]},{\"make\":\"Ferrari\",\"model\":\"F430\",\"travelledDistance\":235611505,\"partsId\":[37,17,104]},{\"make\":\"Ferrari\",\"model\":\"Daytona\",\"travelledDistance\":30312194,\"partsId\":[2,96,95,115,94,12,25,116,74,64,101]},{\"make\":\"Ferrari\",\"model\":\"F40\",\"travelledDistance\":69764556,\"partsId\":[66,108,54]},{\"make\":\"Ferrari\",\"model\":\"250 GTO\",\"travelledDistance\":496765811,\"partsId\":[32,98,76,36,90,16]},{\"make\":\"Ferrari\",\"model\":\"275\",\"travelledDistance\":164216748,\"partsId\":[13,79,73,29,54,56,76,97,12,89,50]},{\"make\":\"Ferrari\",\"model\":\"Enzo\",\"travelledDistance\":497163085,\"partsId\":[82,19,17]},{\"make\":\"Ferrari\",\"model\":\"Daytona\",\"travelledDistance\":293676308,\"partsId\":[101,102,103]},{\"make\":\"Alfa Romeo\",\"model\":\"Giulia\",\"travelledDistance\":451741545,\"partsId\":[101,113,89,88,68,19,50,3,98,111,68]},{\"make\":\"Alfa Romeo\",\"model\":\"Giulietta\",\"travelledDistance\":128074332,\"partsId\":[67,43,12,75,33,87]},{\"make\":\"Alfa Romeo\",\"model\":\"AR51\",\"travelledDistance\":452362116,\"partsId\":[60,9,108]},{\"make\":\"Alfa Romeo\",\"model\":\"Alfetta\",\"travelledDistance\":227419636,\"partsId\":[35,30,7,21,14,73,70,100,105,15,59]},{\"make\":\"Alfa Romeo\",\"model\":\"75\",\"travelledDistance\":338929990,\"partsId\":[38,15,81]},{\"make\":\"Alfa Romeo\",\"model\":\"AR51\",\"travelledDistance\":273101528,\"partsId\":[60,8,87]},{\"make\":\"Alfa Romeo\",\"model\":\"156\",\"travelledDistance\":434781563,\"partsId\":[14,30,28,109,111,41,30,94,115,54,46]},{\"make\":\"Alfa Romeo\",\"model\":\"Giulietta\",\"travelledDistance\":436415485,\"partsId\":[60,18,18]},{\"make\":\"Alfa Romeo\",\"model\":\"164\",\"travelledDistance\":385298945,\"partsId\":[43,61,80]},{\"make\":\"Alfa Romeo\",\"model\":\"75\",\"travelledDistance\":512903265,\"partsId\":[37,40,75,36,42,80,35,36,101,52,20]},{\"make\":\"Alfa Romeo\",\"model\":\"Giulietta\",\"travelledDistance\":519844092,\"partsId\":[115,20,48]},{\"make\":\"Alfa Romeo\",\"model\":\"156\",\"travelledDistance\":274003107,\"partsId\":[37,36,32,41,116,66]},{\"make\":\"Alfa Romeo\",\"model\":\"Giulietta\",\"travelledDistance\":193584127,\"partsId\":[85,9,74,62,13,101,105,110,8,56,83]},{\"make\":\"Alfa Romeo\",\"model\":\"75\",\"travelledDistance\":492649694,\"partsId\":[102,63,21]},{\"make\":\"Peugeot\",\"model\":\"206\",\"travelledDistance\":225031436,\"partsId\":[12,105,19]},{\"make\":\"Peugeot\",\"model\":\"405\",\"travelledDistance\":428581244,\"partsId\":[19,57,35,79,42,96,75,96,64,64,91]},{\"make\":\"Peugeot\",\"model\":\"206\",\"travelledDistance\":471512014,\"partsId\":[94,110,71,62,12,81]},{\"make\":\"Peugeot\",\"model\":\"405\",\"travelledDistance\":255575847,\"partsId\":[80,113,52]},{\"make\":\"Peugeot\",\"model\":\"306\",\"travelledDistance\":138733144,\"partsId\":[98,108,26,61,10,113,14,54,3,21,84]},{\"make\":\"Peugeot\",\"model\":\"308\",\"travelledDistance\":235475304,\"partsId\":[4,18,102]},{\"make\":\"Peugeot\",\"model\":\"407\",\"travelledDistance\":497809602,\"partsId\":[98,70,49]},{\"make\":\"Peugeot\",\"model\":\"306\",\"travelledDistance\":343442559,\"partsId\":[73,11,115,84,52,35,6,99,101,101,70]},{\"make\":\"Peugeot\",\"model\":\"308\",\"travelledDistance\":229420070,\"partsId\":[106,59,67]},{\"make\":\"Peugeot\",\"model\":\"405\",\"travelledDistance\":179145987,\"partsId\":[26,101,22]},{\"make\":\"Peugeot\",\"model\":\"306\",\"travelledDistance\":201912836,\"partsId\":[7,113,116,59,37,15,51,107,61,11,65]},{\"make\":\"Peugeot\",\"model\":\"407\",\"travelledDistance\":422154829,\"partsId\":[55,45,93]},{\"make\":\"Peugeot\",\"model\":\"206\",\"travelledDistance\":312468347,\"partsId\":[59,78,48,93,38,83]},{\"make\":\"Peugeot\",\"model\":\"407\",\"travelledDistance\":336906707,\"partsId\":[53,15,42,106,47,112,97,29,33,30,39]},{\"make\":\"Peugeot\",\"model\":\"206\",\"travelledDistance\":310013429,\"partsId\":[26,106,81]},{\"make\":\"Peugeot\",\"model\":\"308\",\"travelledDistance\":454503627,\"partsId\":[64,70,39]},{\"make\":\"Peugeot\",\"model\":\"405\",\"travelledDistance\":225997773,\"partsId\":[76,4,82,33,63,76,109,26,13,24,93]},{\"make\":\"Peugeot\",\"model\":\"306\",\"travelledDistance\":72195908,\"partsId\":[97,114,96,59,74,103]},{\"make\":\"Peugeot\",\"model\":\"405\",\"travelledDistance\":319350232,\"partsId\":[55,78,40]},{\"make\":\"Peugeot\",\"model\":\"308\",\"travelledDistance\":63428253,\"partsId\":[95,97,10,3,107,42,117,58,8,35,50]},{\"make\":\"Peugeot\",\"model\":\"206\",\"travelledDistance\":167257947,\"partsId\":[115,74,7]},{\"make\":\"Peugeot\",\"model\":\"206\",\"travelledDistance\":130139399,\"partsId\":[58,58,42]},{\"make\":\"Citroen\",\"model\":\"Berlingo\",\"travelledDistance\":242536078,\"partsId\":[19,75,24,19,49,3,56,90,18,4,20]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":396754068,\"partsId\":[65,38,88]},{\"make\":\"Citroen\",\"model\":\"Berlingo\",\"travelledDistance\":436804201,\"partsId\":[111,71,116]},{\"make\":\"Citroen\",\"model\":\"C5\",\"travelledDistance\":32203443,\"partsId\":[29,64,79,48,12,107,45,20,104,63,60]},{\"make\":\"Citroen\",\"model\":\"C5\",\"travelledDistance\":347651789,\"partsId\":[64,108,76]},{\"make\":\"Citroen\",\"model\":\"C8\",\"travelledDistance\":48263045,\"partsId\":[7,87,1,53,66,22]},{\"make\":\"Citroen\",\"model\":\"Elysée\",\"travelledDistance\":4120281,\"partsId\":[106,15,63,39,116,57,6,66,78,55,33]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":217089114,\"partsId\":[24,12,43]},{\"make\":\"Citroen\",\"model\":\"C4\",\"travelledDistance\":385550653,\"partsId\":[63,80,64]},{\"make\":\"Citroen\",\"model\":\"C5\",\"travelledDistance\":38829917,\"partsId\":[79,92,54,65,85,31,26,82,111,112,14]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":447103875,\"partsId\":[98,64,6,3,14,18]},{\"make\":\"Citroen\",\"model\":\"C3\",\"travelledDistance\":214064329,\"partsId\":[95,100,87]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":389207601,\"partsId\":[9,17,40,69,64,27,17,116,5,20,34]},{\"make\":\"Citroen\",\"model\":\"C4\",\"travelledDistance\":501689589,\"partsId\":[98,13,109]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":498211182,\"partsId\":[7,47,98]},{\"make\":\"Citroen\",\"model\":\"C5\",\"travelledDistance\":98486390,\"partsId\":[42,107,70,5,43,90,31,78,53,99,18]},{\"make\":\"Citroen\",\"model\":\"C3\",\"travelledDistance\":404111136,\"partsId\":[116,95,79]},{\"make\":\"Citroen\",\"model\":\"C8\",\"travelledDistance\":118984206,\"partsId\":[33,49,78]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":174494239,\"partsId\":[24,31,20,70,86,26,99,113,45,60,47]},{\"make\":\"Citroen\",\"model\":\"C3\",\"travelledDistance\":486926519,\"partsId\":[1,54,41]},{\"make\":\"Citroen\",\"model\":\"Elysée\",\"travelledDistance\":277281794,\"partsId\":[85,41,2,62,74,116]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":130512554,\"partsId\":[50,51,13,95,76,97,13,85,85,113,26]},{\"make\":\"Citroen\",\"model\":\"C4\",\"travelledDistance\":404134333,\"partsId\":[86,18,20]},{\"make\":\"Citroen\",\"model\":\"C3\",\"travelledDistance\":295402694,\"partsId\":[53,62,112]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":339260713,\"partsId\":[113,41,49,56,95,84,115,69,45,84,27]},{\"make\":\"Citroen\",\"model\":\"C5\",\"travelledDistance\":476502389,\"partsId\":[18,43,61,103,45,18]},{\"make\":\"Citroen\",\"model\":\"C1\",\"travelledDistance\":505029588,\"partsId\":[114,58,103]},{\"make\":\"Citroen\",\"model\":\"C8\",\"travelledDistance\":309422851,\"partsId\":[11,79,75,98,99,113,18,3,46,68,3]},{\"make\":\"Seat\",\"model\":\"Toledo\",\"travelledDistance\":144201918,\"partsId\":[73,109,15]},{\"make\":\"Seat\",\"model\":\"Mii\",\"travelledDistance\":304944609,\"partsId\":[91,106,110]},{\"make\":\"Seat\",\"model\":\"Ibiza\",\"travelledDistance\":333280407,\"partsId\":[28,40,53,101,111,117,99,71,35,11,20]},{\"make\":\"Seat\",\"model\":\"Mii\",\"travelledDistance\":508783407,\"partsId\":[8,10,85]},{\"make\":\"Seat\",\"model\":\"Ibiza\",\"travelledDistance\":182688172,\"partsId\":[108,80,44]},{\"make\":\"Seat\",\"model\":\"Mii\",\"travelledDistance\":473519569,\"partsId\":[69,2,51,36,43,68,34,81,109,62,49]},{\"make\":\"Seat\",\"model\":\"Toledo\",\"travelledDistance\":43341591,\"partsId\":[40,112,113]},{\"make\":\"Seat\",\"model\":\"Toledo\",\"travelledDistance\":453385478,\"partsId\":[55,82,20,76,43,91]},{\"make\":\"Seat\",\"model\":\"Ibiza\",\"travelledDistance\":197399178,\"partsId\":[88,102,48,61,112,32,70,84,80,5,68]},{\"make\":\"Seat\",\"model\":\"Mii\",\"travelledDistance\":485157233,\"partsId\":[98,78,33]},{\"make\":\"Seat\",\"model\":\"Toledo\",\"travelledDistance\":266451047,\"partsId\":[31,58,23]},{\"make\":\"Seat\",\"model\":\"Mii\",\"travelledDistance\":306842982,\"partsId\":[42,70,57,104,105,88,23,18,117,9,100]},{\"make\":\"Seat\",\"model\":\"Toledo\",\"travelledDistance\":196618703,\"partsId\":[50,12,75,95,34,75]},{\"make\":\"Seat\",\"model\":\"Ibiza\",\"travelledDistance\":390958489,\"partsId\":[42,53,40]},{\"make\":\"Seat\",\"model\":\"Toledo\",\"travelledDistance\":172222867,\"partsId\":[76,10,96,83,36,87,72,79,37,48,48]},{\"make\":\"Seat\",\"model\":\"Mii\",\"travelledDistance\":20379344,\"partsId\":[51,83,27]},{\"make\":\"Skoda\",\"model\":\"Citigo\",\"travelledDistance\":353678487,\"partsId\":[63,91,71]},{\"make\":\"Skoda\",\"model\":\"Rapid Spaceback\",\"travelledDistance\":477031551,\"partsId\":[73,68,100,111,12,81,109,56,3,37,15]},{\"make\":\"Skoda\",\"model\":\"Citigo\",\"travelledDistance\":326326638,\"partsId\":[59,32,88]},{\"make\":\"Skoda\",\"model\":\"Citigo\",\"travelledDistance\":186951373,\"partsId\":[76,64,103]},{\"make\":\"Skoda\",\"model\":\"Citigo\",\"travelledDistance\":334919977,\"partsId\":[33,1,60,59,37,104,101,29,67,37,46]},{\"make\":\"Skoda\",\"model\":\"Fabia\",\"travelledDistance\":506138915,\"partsId\":[18,52,70]},{\"make\":\"Skoda\",\"model\":\"Citigo\",\"travelledDistance\":46712305,\"partsId\":[98,89,48,88,59,39]},{\"make\":\"Skoda\",\"model\":\"Fabia\",\"travelledDistance\":57662452,\"partsId\":[15,32,14,72,113,1,18,26,106,90,45]},{\"make\":\"Skoda\",\"model\":\"Rapid\",\"travelledDistance\":267561546,\"partsId\":[57,72,65]},{\"make\":\"Skoda\",\"model\":\"Fabia\",\"travelledDistance\":58958961,\"partsId\":[79,31,117]},{\"make\":\"Skoda\",\"model\":\"Fabia\",\"travelledDistance\":231485138,\"partsId\":[97,4,50,84,50,30,13,31,6,36,52]},{\"make\":\"Skoda\",\"model\":\"Rapid\",\"travelledDistance\":490651056,\"partsId\":[2,56,70,86,103,110]},{\"make\":\"Skoda\",\"model\":\"Rapid Spaceback\",\"travelledDistance\":371247268,\"partsId\":[57,87,73]},{\"make\":\"Skoda\",\"model\":\"Fabia\",\"travelledDistance\":520029040,\"partsId\":[73,31,4,54,43,8,62,77,75,31,72]},{\"make\":\"Dacia\",\"model\":\"Logan\",\"travelledDistance\":71570263,\"partsId\":[76,36,57]},{\"make\":\"Dacia\",\"model\":\"Sandero Stepway\",\"travelledDistance\":249776933,\"partsId\":[36,52,95]},{\"make\":\"Dacia\",\"model\":\"Sandero\",\"travelledDistance\":443192096,\"partsId\":[40,50,87,86,10,76,51,52,109,18,106]},{\"make\":\"Dacia\",\"model\":\"Dokker\",\"travelledDistance\":73324963,\"partsId\":[44,39,47]},{\"make\":\"Dacia\",\"model\":\"Sandero\",\"travelledDistance\":451514728,\"partsId\":[94,78,43]},{\"make\":\"Dacia\",\"model\":\"Logan\",\"travelledDistance\":459233576,\"partsId\":[13,34,85,81,9,11,54,21,42,60,50]},{\"make\":\"Dacia\",\"model\":\"Logan\",\"travelledDistance\":84177042,\"partsId\":[61,52,85]},{\"make\":\"Dacia\",\"model\":\"Dokker\",\"travelledDistance\":316948000,\"partsId\":[2,3,93,39,93,85]},{\"make\":\"Dacia\",\"model\":\"Sandero\",\"travelledDistance\":410003689,\"partsId\":[72,32,41,39,88,19,76,42,1,4,69]},{\"make\":\"Dacia\",\"model\":\"Dokker\",\"travelledDistance\":294315564,\"partsId\":[64,84,78]},{\"make\":\"Dacia\",\"model\":\"Logan\",\"travelledDistance\":315644424,\"partsId\":[13,88,53]},{\"make\":\"Dacia\",\"model\":\"Duster\",\"travelledDistance\":423453236,\"partsId\":[100,116,8,2,33,53,101,86,76,26,19]},{\"make\":\"Dacia\",\"model\":\"Sandero Stepway\",\"travelledDistance\":279714744,\"partsId\":[73,10,32,94,86,79]},{\"make\":\"Dacia\",\"model\":\"Duster\",\"travelledDistance\":297581436,\"partsId\":[56,66,79]},{\"make\":\"Dacia\",\"model\":\"Logan\",\"travelledDistance\":231160691,\"partsId\":[14,78,76,20,97,105,6,77,72,63,60]}]";
    }
}
