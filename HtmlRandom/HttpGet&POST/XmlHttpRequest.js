console.log('Hello world');

//
function DoIt() {
    console.log('Stage Change....!');
    console.log(`readyStage is =>${this.readyState}`);
}


//instatiate the object that will make and recive the request
var request = new XMLHttpRequest();

//tell the request obj what to do when the response is recive
//request.onreadystatechange = DoIt;

request.onreadystatechange = () => {
    console.log(`readyStage is =>${request.readyState}`);

    if (request.readyState == 4) { // firts, check that the request is finish
        // check that th request was successfull
        if (request.status == 200) {
            console.log('Status 200!.....');
            console.log(`${request.responseText}`);
            console.log(`${request.response}`);
            console.log(`${JSON.parse(request.response).value.joke}`);
        }
    }
}

//open a conection to the site
//specify the endpoint! (url/controller/action)
//Http method, full, url to the endpoint,  async?
request.open('GET', 'http://api.icndb.com/jokes/random', true);
//send the request
request.send();


// NOW for POST request
var request2 = XMLHttpRequest();

request2.onreadystatechange = () => {
    console.log(`readyStage is =>${request.readyState}`);

    if (request2.readyState == 4) { // firts, check that the request is finish
        // check that th request was successfull
        if (request2.status == 200) {
            console.log('Status 200!.....');
            console.log(`${request2.responseText}`);
            console.log(`${request2.response}`);
            var player = JSON.parse(request2.response);
        }
    }
}

request.setRequestHeader("Content-Type", "application/json");
//add other header here


//create the player to send in the body
var player = {
    fname: "Baby"
}

request2.open('POST', '<URL>', true); ///URL is for the view 

request2.send(JSON.stringify(player));

















function loadDoc() {
    var sender = new XMLHttpRequest();

    sender.open('POST', 'https://jsonplaceholder.typicode.com/posts');
    sender.setRequestHeader("Content-type", "application/json; charset=UTF-8");

    var body = {
        title: 'Donde',
        body: 'Hello',
        userId: 34,
    };

    sender.send(JSON.stringify(body));

}