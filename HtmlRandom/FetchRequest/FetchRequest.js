console.log('hello world');

fetch('http://api.icndb.com/jokes/random/3')
    // .then(res =>{ res.json()
    // console.log('the frits then statenment');
    // return res.json();
    // })
    .then(r => r.json())
    .then(res => {
        console.log(res.value.joke);
        console.log('The second then statement');
    });

//the lambda above is the equivalent of ....
var func = function(res) {
    return res.json();
}


//now lets get something from our api
fetch('URL')
    .then(res => {
        if (res.status == 200) {
            console.log(`The respose is ${res.status}, and the status text this ${res.statusText}`)

        } else {
            console.log('Error')
        }
    })

.then(res => console.log(res))
    .catch(err => console.log('there was an error'))
    .finally(console.log('this is finall'));




var player = {
        fname: 'Guille',
        lname: 'delgado',
    }
    // Post in fetch
fetch('URL', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(player)
    })
    .them(res => res.json())
    .then(res => console.log(`the return ${res.fname}`))