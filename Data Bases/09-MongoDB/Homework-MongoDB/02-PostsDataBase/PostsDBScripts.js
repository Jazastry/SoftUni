use BlogDB
db.createCollection("Posts");
db.createCollection("Authors");
db.Authors.insert([
    {
        "displayName":"Goirge",
        "tweeterAccount":"gigi",
        "linkedInAccount":"GO"
    },
    {
        "displayName":"Samo",
        "tweeterAccount":"soso",
        "linkedInAccount":"SO"
    },
    {
        "displayName":"Faradei",
        "tweeterAccount":"fonfon",
        "linkedInAccount":"FO"
    },    
]);
db.Posts.insert([
        {
            "title":"First Post",
            "content":"This is the content of the post.",
            "creationDate": Date(),
            "category":"First Category",
            "tags":["first","big","interesting"],
            "author_id":ObjectId("54ec9e6d9e06b6f6b1606411")
        },
        {
            "title":"Second Post",
            "content":"This is the content of the post.",
            "creationDate": Date(),
            "category":"Second Category",
            "tags":["second","small","more interesting"],
            "author_id":ObjectId("54ec9e6d9e06b6f6b1606412")
        },
        {
            "title":"Thirth Post",
            "content":"This is the content of the post.",
            "creationDate": Date(),
            "category":"Thirth Category",
            "tags":["thirth","medium","exclusively"],
            "author_id":ObjectId("54ec9e6d9e06b6f6b1606413")
        },        
]);