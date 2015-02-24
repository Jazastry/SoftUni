use MessagesDB

db.createCollection("Messages");

db.Messages.insert([

    {

        "text":"Message One",

        "date": Date(),

        "user":

            {

                "username":"Zahari",

                "fullName":"Zahari Zahariev",

                "website":"www.zahri.com" 

            }

    },

        {

        "text":"Message Two",

        "date": Date(),

        "user":

            {

                "username":"Gosho",

                "fullName":"Gosho Goshev",

                "website":"www.goshko.com"

            }

    },

        {

        "text":"Message Three",

        "date": Date(),

        "user":

            {

                "username":"Minka",

                "fullName":"Minka Minkova",

                "website":"www.minka.com"

            }

    },

        {

        "text":"Message Four",

        "date": Date(),

        "user":

            {

                "username":"Pesho",

                "fullName":"Pesho Peshev",

                "website":"www.pesho.com"

            }

    },

]);

db.createCollection("Users");

db.Users.insert([

{

    "username":"Pesho",

    "fullName":"Pesho Peshev",

    "website":"www.pesho.com"

},

{

    "username":"Minka",

    "fullName":"Minka Minkova",

    "website":"www.minka.com"

},

{

    "username":"Gosho",

    "fullName":"Gosho Goshev",

    "website":"www.goshko.com"

},

{

    "username":"Zahari",

    "fullName":"Zahari Zahariev",

    "website":"www.zahri.com"

}]);


// to backup database run mongodump on running mongod instance
// it will backup all databases in running mongod
// --out points to the direstory where you want to place backups
// mongodump --out \data\backup\

// delete backuped database
//use <name of your database>
db.dropDatabase();

// to restore put path to directory in witch are mongo .exe files in 
// your invironment variables -> PATH variable 
// open cmd in folder containing backups and run
// monrogestore <path to your folder containing .bson backup files>







