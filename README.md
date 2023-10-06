## ThirukuralAPI 
Thirukural API Created based on .NET webapi.
The api given response body only tamil language. In future i will give other language.
The class,variable and method i try to write my native language(Tamil) it's working i love it.
In this case i use the postman tool to run the webapi.
Thirukural have 1330 song but currently i give 130 songs in future other song i will give.
Thirukural have 13 chaptergroups(இயல்) and 133 chapters(அதிகாரம்), 1330 kural(குறள்)

## The First API is 
API : "https://gowrishankar.bsite.net/api/Values/GetIyal",
Method : GET,

## The Second API is
API : "https://gowrishankar.bsite.net/api/Values/GetAthikaram",
Method : GET,

## The third API is 
API 
    : "https://gowrishankar.bsite.net/api/Values/GetThirukuralAll",
Method 
    : GET

## The forth API is
API : "https://gowrishankar.bsite.net/api/Values/Search",
Method : POST,
Request Body :
```
{
    //"அதிகாரம்":"வான்சிறப்பு"
    //"இயல்":"பாயிரவியல்"
    //"குறள் எண்":"130"
    "உள்ளீடு":"தார்"
}
```
